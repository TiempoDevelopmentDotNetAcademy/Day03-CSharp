namespace CSSharp_2020.Shapes
{
    public class Circle
    {
        public double Radius { get; } //CSharp6_read_only_properties
        public Circle(double radius) => Radius = radius; //CSharp6_Expression_Bodied_Methods
    }
}