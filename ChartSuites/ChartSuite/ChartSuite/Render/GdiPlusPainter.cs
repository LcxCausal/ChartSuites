using System.Collections.Generic;
using System.Drawing;

namespace ChartSuite
{
    public class GdiPlusPainter : Painter
    {
        Graphics graphics;

        public GdiPlusPainter()
            : this(null)
        {

        }

        public GdiPlusPainter(Image image)
            : base()
        {
            ChartMap = new ChartMap(image);
            graphics = Graphics.FromImage(image);
        }

        protected override void DrawCircularCore(ShapeStyle style, float x, float y, float width, float height, float startAngle, float sweepAngle)
        {
            Pen pen = new Pen(style.LineColor);
            Brush brush = new SolidBrush(style.FillColor);
            graphics.DrawPie(pen, x, y, width, height, startAngle, sweepAngle);
            graphics.FillPie(brush, x, y, width, height, startAngle, sweepAngle);
        }

        protected override void DrawImageCore(ChartMap chartMap, IEnumerable<ChartPoint> points)
        {
            int count = 0;
            foreach (ChartPoint point in points)
            {
                count++;
            }
            PointF[] newPoints = new PointF[count];
            int i = 0;
            foreach (ChartPoint point in points)
            {
                newPoints[i].X = point.X;
                newPoints[i].Y = point.Y;
                i++;
            }
            graphics.DrawImage((Image)chartMap.Map, newPoints);
        }

        protected override void DrawImageCore(ChartMap chartMap, int x, int y)
        {
            graphics.DrawImage((Image)chartMap.Map, x, y);
        }

        protected override void DrawImageCore(ChartMap chartMap, int x, int y, int width, int height)
        {
            graphics.DrawImage((Image)chartMap.Map, x, y, width, height);
        }

        protected override void DrawLineCore(ShapeStyle style, IEnumerable<ChartPoint> points, int lineWidth, float tension)
        {
            Pen pen = new Pen(style.LineColor);
            pen.Width = lineWidth;
            int count = 0;
            foreach (ChartPoint point in points)
            {
                count++;
            }
            PointF[] newPoints = new PointF[count];
            int i = 0;
            foreach (ChartPoint point in points)
            {
                newPoints[i].X = point.X;
                newPoints[i].Y = point.Y;
                i++;
            }
            graphics.DrawCurve(pen, newPoints, tension);
        }

        protected override void DrawStringCore(string s, TextStyle style, int textWidth, float x, float y)
        {
            Font font = new Font("宋体", textWidth);
            Brush brush = new SolidBrush(style.TextColor);
            graphics.DrawString(s, font, brush, x, y);
        }

        protected override void DrawPolygonCore(ShapeStyle style, IEnumerable<ChartPoint> points)
        {
            Pen pen = new Pen(style.LineColor);
            Brush brush = new SolidBrush(style.FillColor);
            int count = 0;
            foreach (ChartPoint point in points)
            {
                count++;
            }
            PointF[] newPoints = new PointF[count];
            int i = 0;
            foreach (ChartPoint point in points)
            {
                newPoints[i].X = point.X;
                newPoints[i].Y = point.Y;
                i++;
            }
            graphics.DrawPolygon(pen, newPoints);
            graphics.FillPolygon(brush, newPoints);
        }

        protected override void DrawRectangleCore(ShapeStyle style, ChartPoint point, float width, float height)
        {
            ChartPoint[] points = new ChartPoint[4];
            points[0] = point;
            points[1] = new ChartPoint(point.X + width, point.Y);
            points[2] = new ChartPoint(point.X + width, point.Y + height);
            points[3] = new ChartPoint(point.X, point.Y + height);
            DrawPolygon(style, points);
        }
    }
}
