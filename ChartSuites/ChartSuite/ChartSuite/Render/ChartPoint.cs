namespace ChartSuite
{
    public class ChartPoint
    {
        private float x;
        private float y;

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public ChartPoint()
            : this(0, 0)
        {

        }

        public ChartPoint(float x, float y)
        {
            X = x;
            Y = y;
        }

    }
}
