using System.Collections.Generic;

namespace ChartSuite
{
    public class DataSeries
    {
        private List<DataPoint> dataPoints;
        private string rowName;
        private int index;

        public List<DataPoint> DataPoints
        {
            get { return dataPoints; }
            set { dataPoints = value; }
        }

        public string RowName
        {
            get { return rowName; }
            set { rowName = value; }
        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public DataSeries()
        {
            dataPoints = new List<DataPoint>();
        }

        public List<string> ReadColumnsName()
        {
            List<string> columnsName = new List<string>();
            foreach (DataPoint point in DataPoints)
            {
                columnsName.Add(point.ColumnName);
            }
            return columnsName;
        }

    }
}
