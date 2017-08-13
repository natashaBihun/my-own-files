namespace MapOfTheCity
{
    public class GeographicCoordinates
    {
        public double X;
        public double Y;
        public GeographicCoordinates(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format($"({X}, {Y})");
        }
    }
}
