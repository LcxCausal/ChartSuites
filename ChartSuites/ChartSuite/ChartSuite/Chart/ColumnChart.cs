using System;

namespace ChartSuite
{
    public class ColumnChart : Chart
    {
        public ColumnChart()
            : this(null)
        {

        }

        public ColumnChart(ChartData data)
            : base(data)
        {
            chartType = ChartType.ColumnChart;
        }

        protected override void DrawCore(Painter painter)
        {
            DrawTitle(painter);
            DrawFrame(painter);
            DrawColumns(painter);
            DrawLabel(painter);
            DrawLegend(painter);
        }

        protected override void RefreshCore(Painter painter)
        {
            DrawCore(painter);
        }

        private void DrawColumns(Painter painter)
        {
            BasicArithmetic ba = new BasicArithmetic();
            float xAxis = XMin;
            int rowsCount, columnsCount;
            float distance = ba.CalculateDistance(Data, XMax, XMin);
            ChartPoint point = new ChartPoint();
            ba.CalculateRanks(Data, out rowsCount, out columnsCount);
            for (int row = 0; row < rowsCount; row++)
            {
                xAxis = XMin + distance * Data.DataSeries[row].Index;
                for (int col = 0; col < Data.DataSeries[row].DataPoints.Count; col++)
                {
                    point.X = xAxis;
                    point.Y = YMax - YMin - Convert.ToSingle(Data.DataSeries[row].DataPoints[col].Value) / Data.Scaling;
                    painter.DrawRectangle(ShapeStyle[row % 9 + 1], point, (int)distance, Convert.ToInt32(Data.DataSeries[row].DataPoints[col].Value) / Data.Scaling);
                    xAxis += distance * (rowsCount + 1);
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
                xAxis = XMin + distance * (row + 1);
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
