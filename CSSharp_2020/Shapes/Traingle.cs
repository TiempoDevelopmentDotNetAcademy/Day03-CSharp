namespace CSSharp_2020.Shapes {
    public class Triangle {
        double _base;

        public double Base {
            get {
                return _base;
            }

            set {
                _base = value;
            }
        }

        public Triangle (double height) {
            this.Height = height;

        }
        public double Height { get; }

        public Triangle (double @base, double height) {
            Base = @base;
            Height = height;
        }
    }
}