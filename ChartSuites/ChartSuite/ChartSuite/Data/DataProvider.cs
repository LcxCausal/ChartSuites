using System;

namespace ChartSuite
{
    public abstract class DataProvider
    {
        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        protected DataProvider()
            : this(null)
        {

        }

        protected DataProvider(string path)
        {
            Path = path;
        }

        public ChartData Load()
        {
            if (Path == null)
            {
                throw new ArgumentNullException("path");
            }
            return LoadCore();
        }

        protected abstract ChartData LoadCore();
    }
}
