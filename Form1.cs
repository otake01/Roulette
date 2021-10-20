using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System;
using System.Media;

namespace Roulette
{
    public partial class Roulette : Form
    {
        private int datacount = 0; //グラフ入力欄の数
        private bool rotationflg = false; //回転フラグ(true=回転,false=停止)
        private int stopcount = 0; //stopボタンを押してからの経過時間
        private int stoptime = 0;

        private System.Timers.Timer timer;
        private readonly int ONE_SEC = 1000; // 1秒(ミリ秒)
        private readonly int MAX_FRAME = 60; // 最大フレーム
        private readonly int STOP_EXTENSION_MAX_TIME = 30; //ストップ最大延長フレーム
        private readonly int STOP_EXTENSION_MIN_TIME = 1; //ストップ最小延長フレーム

        private Bitmap org = null;
        private readonly int YAZIRUSI_PIC_X = 128; //画像サイズ(X方向)
        private readonly int YAZIRUSI_PIC_Y = 128; //画像サイズ(Y方向)

        private readonly float MAX_ANGLE = 360;
        private float ang = 0; //現在の角度
        private float rot_time = 1; //矢印1周にかかる時間(秒)

        private SoundPlayer player = null;
        private readonly string ROULETTE_SE_PATH = "sozai/roulette.wav"; //回転中に鳴るSEファイルの場所

        private readonly string YAZIRUSI_PATH = "sozai/yazirusi.png"; //矢印画像の場所

        public Roulette()
        {
            InitializeComponent();
        }

        //初期化
        private void Form1_Load(object sender, EventArgs e)
        {
            //グラフ初期化
            ch_roulette.Series.Clear();
            ch_roulette.ChartAreas.Clear();
            ch_roulette.Titles.Clear();

            ch_roulette.BackColor = SystemColors.Control;

            string chart_area1 = "Area1";
            ch_roulette.ChartAreas.Add(new ChartArea(chart_area1));
            ch_roulette.ChartAreas[chart_area1].BackColor = SystemColors.Control;

            //グラフの種類を円に
            string legend1 = "Graph1";
            ch_roulette.Series.Add(legend1);
            ch_roulette.Series[legend1].ChartType = SeriesChartType.Pie;

            ch_roulette.Series[legend1].BorderColor = Color.Black;
            ch_roulette.Legends[0].Enabled = false;
            DataPoint dp = new DataPoint(100, 100);
            ch_roulette.Series[legend1].Points.Add(dp);

            //グラフのタイトル設定
            string titles1 = "Title1";
            ch_roulette.Titles.Add(titles1);
            ch_roulette.Titles[titles1].Text = "";

            //waveファイルを予め読み込む
            player = new SoundPlayer(ROULETTE_SE_PATH);
            
            //グラフの矢印画像初期化
            pi_arrow.Parent = ch_roulette;
            pi_arrow.BackColor = Color.Transparent;
            pi_arrow.ImageLocation = YAZIRUSI_PATH;

            // オリジナルBitmapの取得
            Bitmap bmp = new Bitmap(YAZIRUSI_PATH);
            org = new Bitmap(bmp, YAZIRUSI_PIC_X, YAZIRUSI_PIC_Y);
            bmp.Dispose();

            // オリジナルBitmapをpictureBoxに設定
            pi_arrow.Image = org;

            //項目数に初期値を設定
            num_rottime.Text = "1";

            //タイマーの設定
            timer = new System.Timers.Timer(ONE_SEC / MAX_FRAME);
            // タイマーの処理
            timer.Elapsed += (t_sender, t_e) =>
            {
                //回転角度計算
                if (ang > MAX_ANGLE)
                {
                    ang = ang - MAX_ANGLE;
                }
                ang += (( MAX_ANGLE / rot_time ) / MAX_FRAME) * 2;

                // ビットマップ(Bitmap)を回転する
                pi_arrow.Image = RotateBitmap(org, ang, YAZIRUSI_PIC_X / 2, YAZIRUSI_PIC_Y / 2);

                //ストップボタンを押してからの処理
                if (!rotationflg)
                {
                    //ストップボタンを押してから一定時間経過後に回転を止める
                    if (stopcount < stoptime )
                    {
                        stopcount = stopcount + 1;
                    }
                    else
                    {
                        Invoke(new SetFocusDelegate(ControlEnable));
                        timer.Stop();
                    }
                }
            };

            ItemCountChange();

        }

        private void num_itemcount_ValueChanged(object sender, EventArgs e)
        {
            ItemCountChange();
        }

        public void ItemCountChange()
        {
            int inputcount = (int)num_itemcount.Value;
            //if(int.TryParse(num_itemcount.Value, out inputcount))
            {
                //項目数に変化があった時のみ処理
                if (inputcount > 0 && inputcount != datacount)
                {
                    //グラフリセット
                    ch_roulette.Series.Clear();
                    string legend1 = "Graph1";
                    ch_roulette.Series.Add(legend1);
                    ch_roulette.Series[legend1].ChartType = SeriesChartType.Pie;
                    ch_roulette.Series[legend1].BorderColor = Color.Black;
                    ch_roulette.Legends[0].Enabled = false;
                    DataPoint dp = new DataPoint(100, 100);
                    ch_roulette.Series[legend1].Points.Add(dp);

                    //グラフ名と割合入力欄の削除
                    //グラフ名
                    for (int i = 0; i < datacount; i++)
                    {
                        Control[] namelist = this.pa_item.Controls.Find("tb_itemname" + i.ToString(), true);

                        if (namelist.Length == 0)
                            continue;

                        this.pa_item.Controls.Remove(namelist[0]);
                    }

                    //割合
                    for (int i = 0; i < datacount; i++)
                    {
                        Control[] numlist = this.pa_item.Controls.Find("num_ratio" + i.ToString(), true);

                        if (numlist.Length == 0)
                            continue;

                        this.pa_item.Controls.Remove(numlist[0]);
                    }

                    //グラフ名と割合入力欄生成
                    NumericUpDown[] num_num = new NumericUpDown[inputcount];
                    TextBox[] tb_name = new TextBox[inputcount];
                    for (int i = 0; i < inputcount; i++)
                    {
                        //グラフ名
                        tb_name[i] = new TextBox();
                        tb_name[i].Location = new Point(0, 5 + (31 * i));
                        tb_name[i].Size = new Size(55, 31);
                        tb_name[i].Name = "tb_itemname" + i.ToString();
                        tb_name[i].Leave += new EventHandler(text_Leave);
                        tb_name[i].TextAlign = HorizontalAlignment.Right;
                        tb_name[i].MaxLength = 20;
                        this.pa_item.Controls.Add(tb_name[i]);

                        //割合
                        num_num[i] = new NumericUpDown();
                        num_num[i].Location = new Point(65, 5 + (31 * i));
                        num_num[i].Size = new Size(55, 31);
                        num_num[i].Name = "num_ratio" + i.ToString();
                        num_num[i].ValueChanged += new EventHandler(text_Leave);
                        num_num[i].TextAlign = HorizontalAlignment.Right;
                        num_num[i].Maximum = 50;
                        num_num[i].Minimum = 1;
                        this.pa_item.Controls.Add(num_num[i]);
                    }
                    datacount = inputcount;

                    GraphChange();
                }
            }
        }

        private void text_Leave(object sender, EventArgs e)
        {
            GraphChange();
        }

        public void GraphChange()
        {
            int[] values = new int[0];
            string[] names = new string[0];

            //入力内容取得
            for (int i = 0; i < datacount; i++)
            {
                Control[] numlist = this.pa_item.Controls.Find("num_ratio" + i.ToString(), true);
                Control[] namelist = this.pa_item.Controls.Find("tb_itemname" + i.ToString(), true);

                if (numlist.Length == 0)
                    continue;

                NumericUpDown num = (NumericUpDown)this.pa_item.Controls.Find("num_ratio" + i.ToString(), true)[0];

                int inputcount = (int)num.Value;
                //if (int.TryParse(numlist[0].Text, out inputcount))
                {
                    Array.Resize(ref values, values.Length + 1);
                    values[values.Length - 1] = inputcount;

                    Array.Resize(ref names, names.Length + 1);
                    if (namelist.Length == 0)
                    {
                        names[names.Length - 1] = "";
                    }
                    else
                    {
                        names[names.Length - 1] = namelist[0].Text;
                    }

                }
            }

            if (values.Length != 0)
            {
                //グラフに入力内容を反映
                ch_roulette.Series.Clear();
                string legend1 = "Graph1";
                ch_roulette.Series.Add(legend1);
                ch_roulette.Series[legend1].ChartType = SeriesChartType.Pie;
                ch_roulette.Series[legend1].BorderColor = Color.Black;
                ch_roulette.Legends[0].Enabled = false;
                // 各項目の値を加算して合計(全体の大きさ)を算出
                double total = 0.0;
                foreach (double d in values)
                {
                    total += d;
                }
                // データをシリーズにセット
                for (int i = 0; i < values.Length; i++)
                {
                    double rate = (values[i] / total) * 100.0;  // 割合を算出
                    DataPoint dp = new DataPoint(rate, rate);
                    dp.Label = names[i];
                    ch_roulette.Series[legend1].Points.Add(dp);
                }
            }
        }

        private void bu_start_Click(object sender, EventArgs e)
        {
            if (rotationflg)
            {
                rotationflg = false;
                stopcount = 0;
                Random random = new Random();
                stoptime = random.Next(STOP_EXTENSION_MIN_TIME, STOP_EXTENSION_MAX_TIME);
                bu_start.Enabled = false;
            }
            else
            {
                // タイマーを開始する
                timer.Start();
                rotationflg = true;
                bu_start.Text = "Stop!"; //ボタンのテキスト変更
                //stopするまで項目を入力できないようにする
                tb_title.Enabled = false;
                num_itemcount.Enabled = false;
                num_rottime.Enabled = false;

                for (int i = 0; i < datacount; i++)
                {
                    Control[] numlist = this.pa_item.Controls.Find("num_ratio" + i.ToString(), true);
                    Control[] namelist = this.pa_item.Controls.Find("tb_itemname" + i.ToString(), true);

                    if (numlist.Length == 0)
                        continue;

                    numlist[0].Enabled = false;
                    namelist[0].Enabled = false;
                }

                //ルーレット音開始
                PlaySound();
            }
        }

        private void tb_title_Leave(object sender, EventArgs e)
        {
            //グラフのタイトル表示
            ch_roulette.Titles[0].Text = tb_title.Text;
        }

        private void num_rottime_ValueChanged(object sender, EventArgs e)
        {
            //回転速度変更
            float inputcount = (float)num_rottime.Value;
            //if (float.TryParse(num_rottime.Text, out inputcount))
            {
                if (inputcount >= 0.1)
                {
                    rot_time = inputcount;
                }
                else
                {
                    num_rottime.Text = "0.1";
                    rot_time = 0.1f;
                }
            }
        }

        private void Form_Click(object sender, EventArgs e)
        {
            //フォーカスを外す
            ActiveControl = null;
        }

        delegate void SetFocusDelegate();

        public void ControlEnable()
        {
            bu_start.Enabled = true;
            bu_start.Text = "Start!"; //ボタンのテキスト変更

            //項目を入力できるようにする
            tb_title.Enabled = true;
            num_itemcount.Enabled = true;
            num_rottime.Enabled = true;

            for (int i = 0; i < datacount; i++)
            {
                Control[] numlist = this.pa_item.Controls.Find("num_ratio" + i.ToString(), true);
                Control[] namelist = this.pa_item.Controls.Find("tb_itemname" + i.ToString(), true);

                if (numlist.Length == 0)
                    continue;

                numlist[0].Enabled = true;
                namelist[0].Enabled = true;
            }

            StopSound();
        }

        /// ビットマップ(Bitmap)を回転する
        public Bitmap RotateBitmap(Bitmap bmp, float angle, int x, int y)
        {
            Bitmap bmp2 = new Bitmap((int)bmp.Width, (int)bmp.Height);
            Graphics g = Graphics.FromImage(bmp2);

            g.TranslateTransform(-x, -y);
            g.RotateTransform(angle, System.Drawing.Drawing2D.MatrixOrder.Append);
            g.TranslateTransform(x, y, System.Drawing.Drawing2D.MatrixOrder.Append);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;

            g.DrawImageUnscaled(bmp, 0, 0);
            g.Dispose();

            return bmp2;
        }

        //WAVEファイルを再生する
        private void PlaySound()
        {
            if (player != null)
            {
                player.Stop();

                //非同期再生する
                //player.Play();

                //ループ再生する
                player.PlayLooping();

                //最後まで再生し終えるまで待機する
                //player.PlaySync();
            }
        }

        //再生されている音を止める
        private void StopSound()
        {
            if (player != null)
            {
                player.Stop();
            }
        }
    }
}
