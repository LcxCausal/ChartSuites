using System.Collections.Generic;
using System.Drawing;

namespace ChartSuite
{
    public class ChartList
    {
        private List<Chart> charts;
        private List<ChartData> dataList;

        public List<Chart> Charts
        {
            get { return charts; }
            set { charts = value; }
        }

        public List<ChartData> DataList
        {
            get { return dataList; }
            set { dataList = value; }
        }

        public ChartList()
        {
            charts = new List<Chart>();
            dataList = new List<ChartData>();
        }

        public void Draw(Painter painter, Orientation orientation)
        {
            DrawCore(painter, orientation);
        }

        protected virtual void DrawCore(Painter painter, Orientation orientation)
        {
            for (int i = 0; i < Charts.Count; i++)
            {
                Bitmap bm1 = new Bitmap((int)painter.ChartMap.Width, (int)painter.ChartMap.Height / Charts.Count);
                ChartMap image = new ChartMap(bm1);
                Painter p1 = new GdiPlusPainter(bm1);
                Charts[i].Draw(p1, orientation);
                painter.DrawImage(image, 0, bm1.Height * i);
                bm1.Dispose();
            }
        }

        public void Refresh(Painter painter, Orientation orientation)
        {
            RefreshCore(painter, orientation);
        }

        protected virtual void RefreshCore(Painter painter, Orientation orientation)
        {
            DrawCore(painter, orientation);
        }
    }
}
