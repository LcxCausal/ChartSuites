using System.Drawing;

namespace ChartSuite
{
    public class ChartMap
    {
        private object map;
        private float width;
        private float height;

        public object Map
        {
            get { return map; }
            set { map = value; if (map != null) { Image image = (Image)map; Width = image.Width; Height = image.Height; } }
        }

        public float Width
        {
            get { return width; }
            set { width = value; }
        }

        public float Height
        {
            get { return height; }
            set { height = value; }
        }

        public ChartMap()
            : this(null)
        {

        }

        public ChartMap(Image map)
        {
            if (map != null)
            {
                Map = map;
                Width = map.Width;
                Height = map.Height;
            }
        }
    }
}
