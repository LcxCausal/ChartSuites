using System.Drawing;

namespace ChartSuite
{
    public class ShapeStyle
    {
        private Color lineColor;
        private Color fillColor;

        public Color LineColor
        {
            get { return lineColor; }
            set { lineColor = value; }
        }

        public Color FillColor
        {
            get { return fillColor; }
            set { fillColor = value; }
        }

        public ShapeStyle()
            :this(Color.Black, Color.Black)
        {

        }

        public ShapeStyle(Color lineColor, Color fillColor)
        {
            LineColor = lineColor;
            FillColor = fillColor;
        }
    }
}
