using System.Collections.Generic;
using System;

namespace ChartSuite
{
    public abstract class Painter
    {
        private ChartMap chartMap;

        public ChartMap ChartMap
        {
            get { return chartMap; }
            set { chartMap = value; }
        }

        protected Painter()
        {
            chartMap = new ChartMap();
        }

        public void DrawString(string s, TextStyle style, int textWidth, float x, float y)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }
            if (style == null)
            {
                throw new ArgumentNullException("style");
            }
            DrawStringCore(s, style, textWidth, x, y);
        }

        protected abstract void DrawStringCore(string s, TextStyle style, int textWidth, float x, float y);

        public void DrawLine(ShapeStyle style, IEnumerable<ChartPoint> points, int lineWidth, float tension)
        {
            if (style == null)
            {
                throw new ArgumentNullException("style");
            }
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            DrawLineCore(style, points, lineWidth, tension);
        }

        protected abstract void DrawLineCore(ShapeStyle style, IEnumerable<ChartPoint> points, int lineWidth, float tension);

        public void DrawPolygon(ShapeStyle style, IEnumerable<ChartPoint> points)
        {
            if (style == null)
            {
                throw new ArgumentNullException("style");
            }
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            DrawPolygonCore(style, points);
        }

        protected abstract void DrawPolygonCore(ShapeStyle style, IEnumerable<ChartPoint> points);

        public void DrawRectangle(ShapeStyle style, ChartPoint point, float width, float height)
        {
            if (style == null)
            {
                throw new ArgumentNullException("style");
            }
            if (point == null)
            {
                throw new ArgumentNullException("point");
            }
            DrawRectangleCore(style, point, width, height);
        }

        protected abstract void DrawRectangleCore(ShapeStyle style, ChartPoint point, float width, float height);

        public void DrawCircular(ShapeStyle style, float x, float y, float width, float height, float startAngle, float sweepAngle)
        {
            if (style == null)
            {
                throw new ArgumentNullException("style");
            }
            DrawCircularCore(style, x, y, width, height, startAngle, sweepAngle);
        }

        protected abstract void DrawCircularCore(ShapeStyle style, float x, float y, float width, float height, float startAngle, float sweepAngle);

        public void DrawImage(ChartMap chartMap, int x, int y)
        {
            if (chartMap == null)
            {
                throw new ArgumentNullException("chartMap");
            }
            DrawImageCore(chartMap, x, y);
        }

        protected abstract void DrawImageCore(ChartMap chartMap, int x, int y);

        public void DrawImage(ChartMap chartMap, int x, int y, int width, int height)
        {
            if (chartMap == null)
            {
                throw new ArgumentNullException("chartMap");
            }
            DrawImageCore(chartMap, x, y, width, height);
        }

        protected abstract void DrawImageCore(ChartMap chartMap, int x, int y, int width, int height);

        public void DrawImage(ChartMap chartMap, IEnumerable<ChartPoint> points)
        {
            if (chartMap == null)
            {
                throw new ArgumentNullException("chartMap");
            }
            if (points == null)
            {
                throw new ArgumentNullException("points");
            }
            DrawImageCore(chartMap, points);
        }

        protected abstract void DrawImageCore(ChartMap chartMap, IEnumerable<ChartPoint> points);
    }
}
