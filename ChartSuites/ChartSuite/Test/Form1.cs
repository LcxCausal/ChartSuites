using System;
using System.Drawing;
using System.Windows.Forms;
using ChartSuite;

namespace Test
{
    public partial class Form1 : Form
    {
        private string dataSourcePath;
        private string saveImagePath;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenDataSourceBtn.Enabled = true;
            SaveImageBtn.Enabled = false;
            DrawColumnChartBtn.Enabled = false;
            DrawLineChartBtn.Enabled = false;
            DrawCurveChartBtn.Enabled = false;
            DrawPieChartBtn.Enabled = false;
            TranspositionBtn.Enabled = false;
        }

        private void OpenDataSourceBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Excel|*.xlsx";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                OpenDataSourcePathTxt.Text = dialog.FileName;
                dataSourcePath = OpenDataSourcePathTxt.Text;
            }
            chartView1.DataPath = dataSourcePath;
            DrawColumnChartBtn.Enabled = true;
            DrawLineChartBtn.Enabled = true;
            DrawCurveChartBtn.Enabled = true;
            DrawPieChartBtn.Enabled = true;
        }

        private void DrawColumnChartBtn_Click(object sender, EventArgs e)
        {
            chartView1.ChartType = ChartType.ColumnChart;
            chartView1.Refresh();
            TranspositionBtn.Enabled = true;
            SaveImageBtn.Enabled = true;
        }

        private void DrawLineChartBtn_Click(object sender, EventArgs e)
        {
            chartView1.ChartType = ChartType.LineChart;
            chartView1.Refresh();
            TranspositionBtn.Enabled = true;
            SaveImageBtn.Enabled = true;
        }

        private void DrawCurveChartBtn_Click(object sender, EventArgs e)
        {
            chartView1.ChartType = ChartType.CurveChart;
            chartView1.Refresh();
            TranspositionBtn.Enabled = true;
            SaveImageBtn.Enabled = true;
        }

        private void TranspositionBtn_Click(object sender, EventArgs e)
        {
            if(chartView1.Orientation == ChartSuite.Orientation.Horizontal)
            {
                chartView1.Orientation = ChartSuite.Orientation.Vertical;
            }
            else
            {
                chartView1.Orientation = ChartSuite.Orientation.Horizontal;
            }
            chartView1.Transpose();
            TranspositionBtn.Enabled = false;
        }

        private void SaveImageBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Lossy compression|*.jpg|Lossy compression|*.jpeg|Lossless compression|*.png|Nondestructive|*.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                saveImagePath = dialog.FileName;
            }
            chartView1.SaveImage(saveImagePath);
        }

        private void DrawPieChartBtn_Click(object sender, EventArgs e)
        {
            chartView1.ChartType = ChartType.PieChart;
            chartView1.Refresh();
            TranspositionBtn.Enabled = true;
            SaveImageBtn.Enabled = true;
        }

        private void MantChartBtn_Click(object sender, EventArgs e)
        {
            DataProvider dp = new ExcelDataProvider(dataSourcePath);
            ChartData data = dp.Load();
            ChartList charts = new ChartList();
            Chart chart = new ColumnChart(data);
            charts.Charts.Add(chart);
            chart = new LineChart(data);
            charts.Charts.Add(chart);
            chart = new CurveChart(data);
            charts.Charts.Add(chart);
            Bitmap bm = new Bitmap(1000, 1000*charts.Charts.Count);
            Painter p = new GdiPlusPainter(bm);
            charts.Draw(p, ChartSuite.Orientation.Horizontal);
            chartView1.ChartMap.Map = bm;
        }
        
    }
}
