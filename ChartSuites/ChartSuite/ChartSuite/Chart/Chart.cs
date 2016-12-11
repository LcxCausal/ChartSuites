using System;
using System.Drawing;
using System.Collections.Generic;

namespace ChartSuite
{
    public abstract class Chart
    {
        private ChartData data;
        private TextStyle textStyle = new TextStyle();
        private ShapeStyle[] shapeStyle = new ShapeStyle[10];
        private Orientation orientation = Orientation.Horizontal;
        protected ChartType chartType;
        private float xMax = 50;
        private float xMin = 50;
        private float yMax = 50;
        private float yMin = 50;

        public float XMax
        {
            get { return xMax; }
            set { xMax = value; }
        }

        public float XMin
        {
            get { return xMin; }
            set { xMin = value; }
        }

        public float YMax
        {
            get { return yMax; }
            set { yMax = value; }
        }

        public float YMin
        {
            get { return yMin; }
            set { yMin = value; }
        }


        public ChartData Data
        {
            get { return data; }
            set { data = value; }
        }

        public TextStyle TextStyle
        {
            get { return textStyle; }
            set { textStyle = value; }
        }

        public ShapeStyle[] ShapeStyle
        {
            get { return shapeStyle; }
            set { shapeStyle = value; }
        }

        public ChartType ChartType
        {
            get { return chartType; }
        }

        protected Chart()
            : this(null)
        {

        }

        protected Chart(ChartData data)
        {
            Data = data;
            ShapeStyle[0] = new ShapeStyle(Color.Black, Color.Black);
            ShapeStyle[1] = new ShapeStyle(Color.Blue, Color.Blue);
            ShapeStyle[2] = new ShapeStyle(Color.Green, Color.Green);
            ShapeStyle[3] = new ShapeStyle(Color.HotPink, Color.HotPink);
            ShapeStyle[4] = new ShapeStyle(Color.LightBlue, Color.LightBlue);
            ShapeStyle[5] = new ShapeStyle(Color.OrangeRed, Color.OrangeRed);
            ShapeStyle[6] = new ShapeStyle(Color.Purple, Color.Purple);
            ShapeStyle[7] = new ShapeStyle(Color.RoyalBlue, Color.RoyalBlue);
            ShapeStyle[8] = new ShapeStyle(Color.Yellow, Color.Yellow);
            ShapeStyle[9] = new ShapeStyle(Color.Orange, Color.Orange);
        }

        public void Draw(Painter painter, Orientation orientation)
        {
            if (Data == null)
            {
                throw new ArgumentNullException("data");
            }
            if (painter == null)
            {
                throw new ArgumentNullException("painter");
            }
            if (this.orientation != orientation)
            {
                this.orientation = orientation;
                Data.Transpose();
            }
            XMax = painter.ChartMap.Width;
            YMax = painter.ChartMap.Height;
            BasicArithmetic ba = new BasicArithmetic();
            ba.CalculateScaling(Data, YMax);
            DrawCore(painter);
        }

        protected abstract void DrawCore(Painter painter);

        public void Refresh(Painter painter)
        {
            if (painter == null)
            {
                throw new ArgumentNullException("painter");
            }
            RefreshCore(painter);
        }

        protected abstract void RefreshCore(Painter painter);

        protected void DrawFrame(Painter painter)
        {
            BasicArithmetic ba = new BasicArithmetic();
            float xAxis = XMin;
            int rowsCount, columnsCount;
            float distance = ba.CalculateDistance(Data, XMax, XMin);
            ChartPoint[] points = new ChartPoint[2];
            points[0] = new ChartPoint(XMin, YMax - YMin);
            points[1] = new ChartPoint(XMax, YMax - YMin);
            painter.DrawLine(ShapeStyle[0], points, 3, 0);
            points[0].X = XMin;
            points[0].Y = YMax - YMin;
            points[1].X = XMin;
            points[1].Y = YMin;
            painter.DrawLine(ShapeStyle[0], points, 3, 0);
            ba.CalculateRanks(Data, out rowsCount, out columnsCount);
            for (int i = 0; i < YMax - 2.5 * YMin - 10; i += 50)
            {
                points[0].X = XMin;
                points[0].Y = YMax - YMin - i;
                points[1].X = XMax - XMin;
                points[1].Y = YMax - YMin - i;
                painter.DrawLine(ShapeStyle[0], points, 1, 0);
            }
            for (int i = 7; i < YMax - 2.5 * YMin - 3; i += 50)
            {
                painter.DrawString(((i - 7) * this.Data.Scaling).ToString("f0"), TextStyle, 9, XMin - 30, YMax - YMin - i);
            }
            for (int col = 0; col < columnsCount; col++)
            {
                xAxis += distance;
                painter.DrawString(Data.DataSeries[0].DataPoints[col].ColumnName, TextStyle, 9, xAxis, YMax - YMin + 20);
                xAxis += distance * rowsCount;
            }
        }

        protected void DrawLegend(Painter painter)
        {
            ChartPoint point = new ChartPoint();
            List<string> rowsName = Data.ReadRowsName();
            for (int row = 0; row < Data.DataSeries.Count; row++)
            {
                point.X = XMax - XMin * 2;
                point.Y = YMin / 2 * (row + 4);
                painter.DrawRectangle(ShapeStyle[row % 9 + 1], point, XMin / 2, YMin / 10);
                painter.DrawString(rowsName[row], TextStyle, 9, XMax - XMin * (float)1.4, YMin / 2 * (row + 4));
            }
        }

        protected void DrawTitle(Painter painter)
        {
            painter.DrawString(Data.Title, TextStyle, 16, (XMax - xMin * 2) / 2, YMin);
        }
    }
}
