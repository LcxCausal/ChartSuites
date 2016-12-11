using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ChartSuite
{
    public partial class ChartView : UserControl
    {
        private string dataPath;
        private ChartData data;
        private ChartMap chartMap;
        private Orientation orientation;
        private Chart chart;
        private Painter painter;
        private ChartType chartType;

        [Browsable(true), Category("ChartView")]
        public string DataPath
        {
            get { return dataPath; }
            set { dataPath = value; }
        }

        public ChartMap ChartMap
        {
            get { return chartMap; }
            set { chartMap = value; }
        }

        [Browsable(true), Category("ChartView")]
        public Orientation Orientation
        {
            get { return orientation; }
            set { orientation = value; }
        }

        [Browsable(true), Category("ChartView")]
        public ChartType ChartType
        {
            get { return chartType; }
            set { chartType = value; }
        }

        public ChartData Data
        {
            get { return data; }
            set { data = value; }
        }

        public ChartView()
        {
            InitializeComponent();
            Orientation = Orientation.Horizontal;
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.ResizeRedraw |
                    ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (DataPath != null)
            {
                if (Data == null)
                {
                    DataProvider dp = new ExcelDataProvider(DataPath);
                    Data = dp.Load();
                }
                ChartMap = new ChartMap(new Bitmap(Width, Height));
                painter = new GdiPlusPainter((Image)ChartMap.Map);
                switch (ChartType)
                {
                    case ChartType.ColumnChart: chart = new ColumnChart(Data); break;
                    case ChartType.LineChart: chart = new LineChart(Data); break;
                    case ChartType.CurveChart: chart = new CurveChart(Data); break;
                    case ChartType.PieChart: chart = new PieChart(Data); break;
                    default: break;
                }
                chart.Draw(painter, Orientation);
                if (ChartMap.Map != null)
                {
                    e.Graphics.DrawImage((Image)ChartMap.Map, 0, 0);
                }
            }

        }

        public void Transpose()
        {
            if (Data == null)
            {
                throw new ArgumentNullException("data");
            }
            if (Orientation == Orientation.Horizontal)
            {
                Orientation = Orientation.Vertical;
            }
            else
            {
                Orientation = Orientation.Horizontal;
            }
            Data.Transpose();
            chart.Data = Data;
        }

        public void SaveImage(string path)
        {
            ((Image)ChartMap.Map).Save(path);
        }

    }
}
