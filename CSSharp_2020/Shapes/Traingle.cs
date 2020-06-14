namespace CSSharp_2020.Shapes
{
    public class Triangle
    {
        double _base;

        public double Base
        {
            get
            {
                return _base;
            }

            set
            {
                _base = value;
            }
        }

        public double Height { get; }

        public Triangle(double @base, double height)
        {
            Base = @base;
            Height = height;
        }
    }
}
