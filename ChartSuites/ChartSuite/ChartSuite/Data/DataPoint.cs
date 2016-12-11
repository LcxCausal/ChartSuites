namespace ChartSuite
{
    public class DataPoint
    {
        private int index;
        private object value;
        private string columnName;

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public object Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public string ColumnName
        {
            get { return columnName; }
            set { columnName = value; }
        }
        public DataPoint()
        {

        }
    }
}
