namespace Test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ChartSuite.ChartMap chartMap1 = new ChartSuite.ChartMap();
            this.DataSourceLab = new System.Windows.Forms.Label();
            this.OpenDataSourcePathTxt = new System.Windows.Forms.TextBox();
            this.OpenDataSourceBtn = new System.Windows.Forms.Button();
            this.SaveImageBtn = new System.Windows.Forms.Button();
            this.DrawColumnChartBtn = new System.Windows.Forms.Button();
            this.DrawLineChartBtn = new System.Windows.Forms.Button();
            this.DrawCurveChartBtn = new System.Windows.Forms.Button();
            this.TranspositionBtn = new System.Windows.Forms.Button();
            this.DrawPieChartBtn = new System.Windows.Forms.Button();
            this.chartView1 = new ChartSuite.ChartView();
            this.SuspendLayout();
            // 
            // DataSourceLab
            // 
            this.DataSourceLab.AutoSize = true;
            this.DataSourceLab.Location = new System.Drawing.Point(12, 12);
            this.DataSourceLab.Name = "DataSourceLab";
            this.DataSourceLab.Size = new System.Drawing.Size(87, 17);
            this.DataSourceLab.TabIndex = 1;
            this.DataSourceLab.Text = "DataSource:";
            // 
            // OpenDataSourcePathTxt
            // 
            this.OpenDataSourcePathTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenDataSourcePathTxt.Location = new System.Drawing.Point(105, 12);
            this.OpenDataSourcePathTxt.Name = "OpenDataSourcePathTxt";
            this.OpenDataSourcePathTxt.Size = new System.Drawing.Size(956, 22);
            this.OpenDataSourcePathTxt.TabIndex = 2;
            // 
            // OpenDataSourceBtn
            // 
            this.OpenDataSourceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenDataSourceBtn.Location = new System.Drawing.Point(1067, 12);
            this.OpenDataSourceBtn.Name = "OpenDataSourceBtn";
            this.OpenDataSourceBtn.Size = new System.Drawing.Size(80, 30);
            this.OpenDataSourceBtn.TabIndex = 3;
            this.OpenDataSourceBtn.Text = "...";
            this.OpenDataSourceBtn.UseVisualStyleBackColor = true;
            this.OpenDataSourceBtn.Click += new System.EventHandler(this.OpenDataSourceBtn_Click);
            // 
            // SaveImageBtn
            // 
            this.SaveImageBtn.Location = new System.Drawing.Point(96, 62);
            this.SaveImageBtn.Name = "SaveImageBtn";
            this.SaveImageBtn.Size = new System.Drawing.Size(88, 27);
            this.SaveImageBtn.TabIndex = 4;
            this.SaveImageBtn.Text = "SaveImage";
            this.SaveImageBtn.UseVisualStyleBackColor = true;
            this.SaveImageBtn.Click += new System.EventHandler(this.SaveImageBtn_Click);
            // 
            // DrawColumnChartBtn
            // 
            this.DrawColumnChartBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.DrawColumnChartBtn.Location = new System.Drawing.Point(1016, 327);
            this.DrawColumnChartBtn.Name = "DrawColumnChartBtn";
            this.DrawColumnChartBtn.Size = new System.Drawing.Size(131, 27);
            this.DrawColumnChartBtn.TabIndex = 6;
            this.DrawColumnChartBtn.Text = "DrawColumnChart";
            this.DrawColumnChartBtn.UseVisualStyleBackColor = true;
            this.DrawColumnChartBtn.Click += new System.EventHandler(this.DrawColumnChartBtn_Click);
            // 
            // DrawLineChartBtn
            // 
            this.DrawLineChartBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.DrawLineChartBtn.Location = new System.Drawing.Point(1016, 382);
            this.DrawLineChartBtn.Name = "DrawLineChartBtn";
            this.DrawLineChartBtn.Size = new System.Drawing.Size(131, 27);
            this.DrawLineChartBtn.TabIndex = 7;
            this.DrawLineChartBtn.Text = "DrawLineChart";
            this.DrawLineChartBtn.UseVisualStyleBackColor = true;
            this.DrawLineChartBtn.Click += new System.EventHandler(this.DrawLineChartBtn_Click);
            // 
            // DrawCurveChartBtn
            // 
            this.DrawCurveChartBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.DrawCurveChartBtn.Location = new System.Drawing.Point(1016, 435);
            this.DrawCurveChartBtn.Name = "DrawCurveChartBtn";
            this.DrawCurveChartBtn.Size = new System.Drawing.Size(131, 27);
            this.DrawCurveChartBtn.TabIndex = 8;
            this.DrawCurveChartBtn.Text = "DrawCurveChart";
            this.DrawCurveChartBtn.UseVisualStyleBackColor = true;
            this.DrawCurveChartBtn.Click += new System.EventHandler(this.DrawCurveChartBtn_Click);
            // 
            // TranspositionBtn
            // 
            this.TranspositionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TranspositionBtn.Location = new System.Drawing.Point(821, 62);
            this.TranspositionBtn.Name = "TranspositionBtn";
            this.TranspositionBtn.Size = new System.Drawing.Size(104, 27);
            this.TranspositionBtn.TabIndex = 9;
            this.TranspositionBtn.Text = "Transposition";
            this.TranspositionBtn.UseVisualStyleBackColor = true;
            this.TranspositionBtn.Click += new System.EventHandler(this.TranspositionBtn_Click);
            // 
            // DrawPieChartBtn
            // 
            this.DrawPieChartBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.DrawPieChartBtn.Location = new System.Drawing.Point(1016, 488);
            this.DrawPieChartBtn.Name = "DrawPieChartBtn";
            this.DrawPieChartBtn.Size = new System.Drawing.Size(131, 27);
            this.DrawPieChartBtn.TabIndex = 10;
            this.DrawPieChartBtn.Text = "DrawPieChart";
            this.DrawPieChartBtn.UseVisualStyleBackColor = true;
            this.DrawPieChartBtn.Click += new System.EventHandler(this.DrawPieChartBtn_Click);
            // 
            // chartView1
            // 
            this.chartView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartView1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            chartMap1.Height = 0F;
            chartMap1.Map = null;
            chartMap1.Width = 0F;
            this.chartView1.ChartMap = chartMap1;
            this.chartView1.ChartType = ChartSuite.ChartType.ColumnChart;
            this.chartView1.Data = null;
            this.chartView1.DataPath = null;
            this.chartView1.Location = new System.Drawing.Point(12, 117);
            this.chartView1.Name = "chartView1";
            this.chartView1.Orientation = ChartSuite.Orientation.Horizontal;
            this.chartView1.Size = new System.Drawing.Size(972, 850);
            this.chartView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 979);
            this.Controls.Add(this.DrawPieChartBtn);
            this.Controls.Add(this.TranspositionBtn);
            this.Controls.Add(this.DrawCurveChartBtn);
            this.Controls.Add(this.DrawLineChartBtn);
            this.Controls.Add(this.DrawColumnChartBtn);
            this.Controls.Add(this.SaveImageBtn);
            this.Controls.Add(this.OpenDataSourceBtn);
            this.Controls.Add(this.OpenDataSourcePathTxt);
            this.Controls.Add(this.DataSourceLab);
            this.Controls.Add(this.chartView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ChartSuite.ChartView chartView1;
        private System.Windows.Forms.Label DataSourceLab;
        private System.Windows.Forms.TextBox OpenDataSourcePathTxt;
        private System.Windows.Forms.Button OpenDataSourceBtn;
        private System.Windows.Forms.Button SaveImageBtn;
        private System.Windows.Forms.Button DrawColumnChartBtn;
        private System.Windows.Forms.Button DrawLineChartBtn;
        private System.Windows.Forms.Button DrawCurveChartBtn;
        private System.Windows.Forms.Button TranspositionBtn;
        private System.Windows.Forms.Button DrawPieChartBtn;
    }
}

