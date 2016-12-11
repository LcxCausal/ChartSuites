using System;

namespace ChartSuite
{
    public class CurveChart : Chart
    {
        public CurveChart()
            : this(null)
        {

        }

        public CurveChart(ChartData data)
            : base(data)
        {
            chartType = ChartType.CurveChart;
        }

        protected override void DrawCore(Painter painter)
        {
            DrawTitle(painter);
            DrawFrame(painter);
            DrawCurve(painter);
            DrawLabel(painter);
            DrawLegend(painter);
        }

        protected override void RefreshCore(Painter painter)
        {
            DrawCore(painter);
        }

        private void DrawCurve(Painter painter)
        {
            BasicArithmetic ba = new BasicArithmetic();
            float xAxis = XMin;
            int rowsCount, columnsCount;
            float distance = ba.CalculateDistance(Data, XMax, XMin);
            ChartPoint[] points = null;
            ba.CalculateRanks(Data, out rowsCount, out columnsCount);
            for (int row = 0; row < rowsCount; row++)
            {

                xAxis = XMin + distance;
                points = new ChartPoint[Data.DataSeries[row].DataPoints.Count];
                int i = 0;
                for (int col = 0; col < Data.DataSeries[row].DataPoints.Count; col++)
                {
                    if (Convert.ToSingle(Data.DataSeries[row].DataPoints[col].Value) == 0)
                    {
                        ChartPoint[] tempPoints = new ChartPoint[col];
                        for (int j = 0; j < col; j++)
                        {
                            tempPoints[j] = points[j];
                        }
                        if (tempPoints.Length > 1)
                        {
                            painter.DrawLine(ShapeStyle[row % 9 + 1], tempPoints, 1, 0.8F);
                        }
                        points = new ChartPoint[Data.DataSeries[row].DataPoints.Count - col - 1];
                        i = 0;
                        xAxis += distance * (rowsCount + 1);
                        continue;
                    }
                    points[i] = new ChartPoint(xAxis, YMax - YMin - Convert.ToSingle(Data.DataSeries[row].DataPoints[col].Value) / base.Data.Scaling);
                    xAxis += distance * (rowsCount + 1);
                    i++;
                }
                if (points.Length > 1)
                {
                    painter.DrawLine(ShapeStyle[row % 9 + 1], points, 1, 0.8F);
                }
            }
        }

        private void DrawLabel(Painter painter)
        {
            BasicArithmetic ba = new BasicArithmetic();
            float xAxis = XMin;
            int rowsCount, columnsCount;
            float distance = ba.CalculateDistance(Data, XMax, XMin);
            ChartPoint point = new ChartPoint();
            ba.CalculateRanks(Data, out rowsCount, out columnsCount);
            for (int row = 0; row < Data.DataSeries.Count; row++)
            {
                xAxis = XMin + distance;
                for (int col = 0; col < Data.DataSeries[row].DataPoints.Count; col++)
                {
                    if (Data.DataSeries[row].DataPoints[col].Value != null)
                    {
                        painter.DrawString(Data.DataSeries[row].DataPoints[col].Value.ToString(), TextStyle, 9, xAxis, YMax - YMin - 15 - Convert.ToSingle(Data.DataSeries[row].DataPoints[col].Value) / base.Data.Scaling);
                    }
                    xAxis += distance * (Data.DataSeries.Count + 1);
                }
            }
        }

    }
}
