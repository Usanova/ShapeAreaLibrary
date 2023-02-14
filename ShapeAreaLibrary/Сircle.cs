namespace ShapeAreaLibrary
{
    public class Circle : Shape
    {
        private double _radius;

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Radius mast be positive");

            _radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * _radius * _radius;
        }
    }
}

