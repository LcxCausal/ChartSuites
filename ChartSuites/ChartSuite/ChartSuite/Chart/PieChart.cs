using System;
using System.Collections.Generic;

namespace ChartSuite
{
    public class PieChart : Chart
    {
        public PieChart()
            : this(null)
        {

        }

        public PieChart(ChartData data)
            : base(data)
        {
            chartType = ChartType.PieChart;
        }

        protected override void DrawCore(Painter painter)
        {
            DrawTitle(painter);
            BasicArithmetic ba = new BasicArithmetic();
            float[,] dataRatio = ba.CalculateDataRatio(Data);
            int rowsCount, columnsCount;
            ba.CalculateRanks(Data, out rowsCount, out columnsCount);
            int distance = (int)(XMax / 1.4 / ((int)Math.Sqrt(rowsCount) + 1));
            ChartPoint point = new ChartPoint(XMin, YMin * 2);
            float startAngle, sweepAngle;
            List<string> rowsName = Data.ReadRowsName();
            for (int row = 0; row < rowsCount; row++)
            {
                startAngle = sweepAngle = 0;
                for (int col = 0; col < columnsCount; col++)
                {
                    sweepAngle = dataRatio[row, col] * 360;
                    painter.DrawCircular(ShapeStyle[col % 9 + 1], point.X, point.Y, distance, distance, startAngle, sweepAngle);
                    startAngle += sweepAngle;
                }
                painter.DrawString(rowsName[row], TextStyle, 9, point.X + distance / 5 * 2, point.Y + distance + YMin / 5);
                point.X = point.X + XMin + distance;
                if (XMax < (point.X + distance))
                {
                    point.X = XMin;
                    point.Y = point.Y + YMin + distance;
                }
            }
            Data.Transpose();
            DrawLegend(painter);
            Data.Transpose();
        }

        protected override void RefreshCore(Painter painter)
        {
            DrawCore(painter);
        }
    }
}
