using System.Drawing;

namespace ChartSuite
{
    public class TextStyle
    {
        private Color textColor;

        public Color TextColor
        {
            get { return textColor; }
            set { textColor = value; }
        }

        public TextStyle()
            :this(Color.Black)
        {

        }

        public TextStyle(Color color)
        {
            TextColor = color;
        }
    }
}
