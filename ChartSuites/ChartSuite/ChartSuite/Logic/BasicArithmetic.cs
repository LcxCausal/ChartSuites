using System;

namespace ChartSuite
{
    internal class BasicArithmetic
    {
        internal float CalculateDistance(ChartData data, float xMax, float xMin)
        {
            int rowsCount, columnsCount;
            CalculateRanks(data, out rowsCount, out columnsCount);
            return (xMax - xMin) / (columnsCount + 1) / (rowsCount + 1 + (float)0.5);
        }

        internal void CalculateRanks(ChartData data, out int rowsCount, out int columnsCount)
        {
            rowsCount = data.DataSeries.Count;
            columnsCount = data.CalculateColumnsCount();
        }

        internal float[,] CalculateDataRatio(ChartData data)
        {
            int rowsCount, columnsCount;
            CalculateRanks(data, out rowsCount, out columnsCount);
            float[,] dataRatio = new float[rowsCount, columnsCount];
            float rowSum = 0;
            for (int row = 0; row < rowsCount; row++)
            {
                rowSum = 0;
                for (int col = 0; col < columnsCount; col++)
                {
                    rowSum += Convert.ToSingle(data.DataSeries[row].DataPoints[col].Value);
                }
                for (int col = 0; col < columnsCount; col++)
                {
                    dataRatio[row, col] = Convert.ToSingle(data.DataSeries[row].DataPoints[col].Value) / rowSum;
                }
            }
            return dataRatio;
        }

        internal float CalculateMax(ChartData data)
        {
            float max = Convert.ToSingle(data.DataSeries[0].DataPoints[0].Value);
            for (int row = 0; row < data.DataSeries.Count; row++)
            {
                for (int col = 0; col < data.DataSeries[row].DataPoints.Count; col++)
                {
                    if (Convert.ToSingle(data.DataSeries[row].DataPoints[col].Value) > max)
                    {
                        max = Convert.ToSingle(data.DataSeries[row].DataPoints[col].Value);
                    }
                }
            }
            return max;
        }

        internal void CalculateScaling(ChartData data, float yMax)
        {
            float maxValue = CalculateMax(data);
            data.Scaling = maxValue / (yMax / (float)1.5);
        }
    }
}
