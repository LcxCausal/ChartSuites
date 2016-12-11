using System.Collections.Generic;

namespace ChartSuite
{
    public class ChartData
    {
        private List<DataSeries> dataSeries;
        private string title;
        private float scaling;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        internal List<DataSeries> DataSeries
        {
            get { return dataSeries; }
            set { dataSeries = value; }
        }

        public float Scaling
        {
            get { return scaling; }
            set { scaling = value; }
        }

        public ChartData()
        {
            dataSeries = new List<DataSeries>();
        }

        public List<string> ReadRowsName()
        {
            List<string> rowsName = new List<string>();
            foreach (DataSeries dataSerie in DataSeries)
            {
                rowsName.Add(dataSerie.RowName);
            }
            return rowsName;
        }

        public int CalculateColumnsCount()
        {
            int maxColumnsCount = 0;
            foreach (DataSeries dataSerie in DataSeries)
            {
                if (maxColumnsCount < dataSerie.DataPoints.Count)
                {
                    maxColumnsCount = dataSerie.DataPoints.Count;
                }
            }
            return maxColumnsCount;
        }

        public void AddRowData(DataSeries newDataSeries)
        {
            if (newDataSeries.DataPoints.Count < DataSeries[0].DataPoints.Count)
            {
                for (int i = newDataSeries.DataPoints.Count; i < DataSeries[0].DataPoints.Count; i++)
                {
                    DataPoint dataPoint = new DataPoint();
                    dataPoint.ColumnName = DataSeries[0].DataPoints[i].ColumnName;
                    dataPoint.Index = DataSeries[0].DataPoints[i].Index;
                    newDataSeries.DataPoints.Add(dataPoint);
                }
            }
            if (newDataSeries.Index != 0 && newDataSeries.Index <= DataSeries.Count)
            {
                for (int i = newDataSeries.Index - 1; i < DataSeries.Count; i++)
                {
                    DataSeries[i].Index += 1;
                }
            }
            else
            {
                newDataSeries.Index = DataSeries.Count + 1;
            }
            DataSeries.Add(newDataSeries);
        }

        public void AddColumnData(DataPoint[] dataPoints)
        {
            List<DataPoint> newDataPoints = new List<DataPoint>();
            if (dataPoints.Length < DataSeries.Count)
            {
                for (int i = 0; i < dataPoints.Length; i++)
                {
                    newDataPoints.Add(dataPoints[i]);
                }
                for (int i = dataPoints.Length; i < DataSeries.Count; i++)
                {
                    DataPoint newDataPoint = new DataPoint();
                    newDataPoint.ColumnName = dataPoints[0].ColumnName;
                    newDataPoint.Index = dataPoints[0].Index;
                    newDataPoint.Value = null;
                    newDataPoints.Add(newDataPoint);
                }
            }
            else
            {
                foreach (DataPoint newDataPoint in dataPoints)
                {
                    newDataPoints.Add(newDataPoint);
                }
            }
            for (int row = 0; row < DataSeries.Count; row++)
            {
                if (newDataPoints[row].Index < DataSeries[row].DataPoints.Count)
                {
                    for (int col = newDataPoints[row].Index; col < DataSeries[row].DataPoints.Count; col++)
                    {
                        DataSeries[row].DataPoints[col].Index += 1;
                    }
                }
                else
                {
                    newDataPoints[row].Index = DataSeries[row].DataPoints.Count + 1;
                }
                DataSeries[row].DataPoints.Add(newDataPoints[row]);
            }
        }

        public void Transpose()
        {
            BasicArithmetic ba = new BasicArithmetic();
            ChartData newData = new ChartData();
            int rowsCount, columnsCount;
            rowsCount = DataSeries.Count;
            columnsCount = CalculateColumnsCount();
            for (int row = 0; row < columnsCount; row++)
            {
                DataSeries newDataSeries = new DataSeries();
                newDataSeries.Index = row + 1;
                newDataSeries.RowName = DataSeries[0].DataPoints[row].ColumnName;
                for (int col = 0; col < rowsCount; col++)
                {
                    DataPoint newDataPoint = new DataPoint();
                    newDataPoint.Index = col + 1;
                    newDataPoint.ColumnName = DataSeries[col].RowName;
                    newDataPoint.Value = DataSeries[col].DataPoints[row].Value;
                    newDataSeries.DataPoints.Add(newDataPoint);
                }
                newData.DataSeries.Add(newDataSeries);
            }
            DataSeries.RemoveRange(0, DataSeries.Count);
            foreach (DataSeries dataSerie in newData.DataSeries)
            {
                DataSeries.Add(dataSerie);
            }
        }
    }
}
