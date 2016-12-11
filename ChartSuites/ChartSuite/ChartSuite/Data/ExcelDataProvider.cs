using Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace ChartSuite
{
    public class ExcelDataProvider : DataProvider
    {
        internal ExcelDataProvider()
            : this(null)
        {

        }

        public ExcelDataProvider(string path)
            : base(path)
        {

        }

        protected override ChartData LoadCore()
        {
            ChartData data = new ChartData();
            object missing = Missing.Value;
            Application excel = new Application();
            Workbook workBook = excel.Application.Workbooks.Open(base.Path, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
            Worksheet workSheet = (Worksheet)workBook.Worksheets.get_Item(1);
            data.Title = workSheet.Name;
            int rowsCount = workSheet.UsedRange.Cells.Rows.Count;
            int columnsCount = workSheet.UsedRange.Cells.Columns.Count;
            Range range = null;
            for (int row = 1; row < rowsCount; row++)
            {
                DataSeries dataSeries = new DataSeries();
                int pointIndex = 0;
                for (int col = 1; col < columnsCount; col++)
                {
                    DataPoint dataPoint = new DataPoint();
                    range = (Range)workSheet.Cells[1, col + 1];
                    dataPoint.ColumnName = range.Text;
                    range = (Range)workSheet.Cells[row + 1, col + 1];
                    try
                    {
                        dataPoint.Value = float.Parse(range.Text);
                    }
                    catch
                    {
                        dataPoint.Value = null;
                    }
                    dataPoint.Index = pointIndex++;
                    dataSeries.DataPoints.Add(dataPoint);
                }
                range = (Range)workSheet.Cells[row + 1, 1];
                dataSeries.RowName = range.Text;
                dataSeries.Index = row;
                data.DataSeries.Add(dataSeries);
            }
            workBook.Close();
            return data;
        }

    }
}
