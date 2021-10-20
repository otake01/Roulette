namespace Roulette
{
    partial class Roulette
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 1D);
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Roulette));
            this.ch_roulette = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.la_itemcount = new System.Windows.Forms.Label();
            this.pa_item = new System.Windows.Forms.Panel();
            this.la_itemname = new System.Windows.Forms.Label();
            this.la_ratio = new System.Windows.Forms.Label();
            this.bu_start = new System.Windows.Forms.Button();
            this.pi_arrow = new System.Windows.Forms.PictureBox();
            this.tb_title = new System.Windows.Forms.TextBox();
            this.la_title = new System.Windows.Forms.Label();
            this.la_rottime = new System.Windows.Forms.Label();
            this.num_itemcount = new System.Windows.Forms.NumericUpDown();
            this.num_rottime = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ch_roulette)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pi_arrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_itemcount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_rottime)).BeginInit();
            this.SuspendLayout();
            // 
            // ch_roulette
            // 
            this.ch_roulette.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            this.ch_roulette.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.ch_roulette.Legends.Add(legend1);
            this.ch_roulette.Location = new System.Drawing.Point(30, 30);
            this.ch_roulette.Name = "ch_roulette";
            series1.BorderColor = System.Drawing.Color.Gray;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            dataPoint1.IsValueShownAsLabel = true;
            dataPoint1.IsVisibleInLegend = true;
            dataPoint1.Label = "a";
            series1.Points.Add(dataPoint1);
            this.ch_roulette.Series.Add(series1);
            this.ch_roulette.Size = new System.Drawing.Size(700, 620);
            this.ch_roulette.TabIndex = 0;
            this.ch_roulette.Text = "chart1";
            title1.Name = "Title1";
            this.ch_roulette.Titles.Add(title1);
            this.ch_roulette.Click += new System.EventHandler(this.Form_Click);
            // 
            // la_itemcount
            // 
            this.la_itemcount.AutoSize = true;
            this.la_itemcount.Location = new System.Drawing.Point(938, 105);
            this.la_itemcount.Name = "la_itemcount";
            this.la_itemcount.Size = new System.Drawing.Size(82, 24);
            this.la_itemcount.TabIndex = 2;
            this.la_itemcount.Text = "項目数";
            this.la_itemcount.Click += new System.EventHandler(this.Form_Click);
            // 
            // pa_item
            // 
            this.pa_item.AutoScroll = true;
            this.pa_item.Location = new System.Drawing.Point(750, 214);
            this.pa_item.Name = "pa_item";
            this.pa_item.Size = new System.Drawing.Size(300, 299);
            this.pa_item.TabIndex = 3;
            // 
            // la_itemname
            // 
            this.la_itemname.AutoSize = true;
            this.la_itemname.Location = new System.Drawing.Point(796, 181);
            this.la_itemname.Name = "la_itemname";
            this.la_itemname.Size = new System.Drawing.Size(82, 24);
            this.la_itemname.TabIndex = 4;
            this.la_itemname.Text = "項目名";
            this.la_itemname.Click += new System.EventHandler(this.Form_Click);
            // 
            // la_ratio
            // 
            this.la_ratio.AutoSize = true;
            this.la_ratio.Location = new System.Drawing.Point(956, 181);
            this.la_ratio.Name = "la_ratio";
            this.la_ratio.Size = new System.Drawing.Size(58, 24);
            this.la_ratio.TabIndex = 5;
            this.la_ratio.Text = "比率";
            this.la_ratio.Click += new System.EventHandler(this.Form_Click);
            // 
            // bu_start
            // 
            this.bu_start.Location = new System.Drawing.Point(960, 610);
            this.bu_start.Name = "bu_start";
            this.bu_start.Size = new System.Drawing.Size(90, 40);
            this.bu_start.TabIndex = 0;
            this.bu_start.Text = "Start!";
            this.bu_start.UseVisualStyleBackColor = true;
            this.bu_start.Click += new System.EventHandler(this.bu_start_Click);
            // 
            // pi_arrow
            // 
            this.pi_arrow.Location = new System.Drawing.Point(96, 76);
            this.pi_arrow.Name = "pi_arrow";
            this.pi_arrow.Size = new System.Drawing.Size(512, 512);
            this.pi_arrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pi_arrow.TabIndex = 6;
            this.pi_arrow.TabStop = false;
            this.pi_arrow.Click += new System.EventHandler(this.Form_Click);
            // 
            // tb_title
            // 
            this.tb_title.Location = new System.Drawing.Point(750, 62);
            this.tb_title.MaxLength = 30;
            this.tb_title.Name = "tb_title";
            this.tb_title.Size = new System.Drawing.Size(270, 31);
            this.tb_title.TabIndex = 7;
            this.tb_title.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_title.Leave += new System.EventHandler(this.tb_title_Leave);
            // 
            // la_title
            // 
            this.la_title.AutoSize = true;
            this.la_title.Location = new System.Drawing.Point(915, 30);
            this.la_title.Name = "la_title";
            this.la_title.Size = new System.Drawing.Size(105, 24);
            this.la_title.TabIndex = 8;
            this.la_title.Text = "タイトル名";
            this.la_title.Click += new System.EventHandler(this.Form_Click);
            // 
            // la_rottime
            // 
            this.la_rottime.AutoSize = true;
            this.la_rottime.Location = new System.Drawing.Point(826, 528);
            this.la_rottime.Name = "la_rottime";
            this.la_rottime.Size = new System.Drawing.Size(194, 24);
            this.la_rottime.TabIndex = 9;
            this.la_rottime.Text = "1回転する時間(秒)";
            this.la_rottime.Click += new System.EventHandler(this.Form_Click);
            // 
            // num_itemcount
            // 
            this.num_itemcount.Location = new System.Drawing.Point(900, 137);
            this.num_itemcount.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.num_itemcount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_itemcount.Name = "num_itemcount";
            this.num_itemcount.Size = new System.Drawing.Size(120, 31);
            this.num_itemcount.TabIndex = 10;
            this.num_itemcount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_itemcount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_itemcount.ValueChanged += new System.EventHandler(this.num_itemcount_ValueChanged);
            // 
            // num_rottime
            // 
            this.num_rottime.DecimalPlaces = 1;
            this.num_rottime.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.num_rottime.Location = new System.Drawing.Point(900, 562);
            this.num_rottime.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num_rottime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.num_rottime.Name = "num_rottime";
            this.num_rottime.Size = new System.Drawing.Size(120, 31);
            this.num_rottime.TabIndex = 11;
            this.num_rottime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_rottime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_rottime.ValueChanged += new System.EventHandler(this.num_rottime_ValueChanged);
            // 
            // Roulette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 669);
            this.Controls.Add(this.num_rottime);
            this.Controls.Add(this.num_itemcount);
            this.Controls.Add(this.la_rottime);
            this.Controls.Add(this.la_title);
            this.Controls.Add(this.tb_title);
            this.Controls.Add(this.pi_arrow);
            this.Controls.Add(this.bu_start);
            this.Controls.Add(this.la_ratio);
            this.Controls.Add(this.la_itemname);
            this.Controls.Add(this.pa_item);
            this.Controls.Add(this.la_itemcount);
            this.Controls.Add(this.ch_roulette);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Roulette";
            this.Text = "ドキドキ★ルーレット";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form_Click);
            ((System.ComponentModel.ISupportInitialize)(this.ch_roulette)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pi_arrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_itemcount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_rottime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart ch_roulette;
        private System.Windows.Forms.Label la_itemcount;
        private System.Windows.Forms.Panel pa_item;
        private System.Windows.Forms.Label la_itemname;
        private System.Windows.Forms.Label la_ratio;
        private System.Windows.Forms.Button bu_start;
        private System.Windows.Forms.PictureBox pi_arrow;
        private System.Windows.Forms.TextBox tb_title;
        private System.Windows.Forms.Label la_title;
        private System.Windows.Forms.Label la_rottime;
        private System.Windows.Forms.NumericUpDown num_itemcount;
        private System.Windows.Forms.NumericUpDown num_rottime;
    }
}

