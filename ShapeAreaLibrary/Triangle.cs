namespace ShapeAreaLibrary
{
    public class Triangle : Shape
    {
        private double _firstSide;
        private double _secondSide;
        private double _thirdSide;

        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            if (firstSide <= 0 || firstSide <= 0 || thirdSide <= 0)
                throw new ArgumentException("Side mast be positive");

            if(firstSide >= secondSide + thirdSide)
                throw new ArgumentException("The first side is not less than the sum of the other two");
            if (secondSide >= firstSide + thirdSide)
                throw new ArgumentException("The secondSide side is not less than the sum of the other two");
            if (thirdSide >= firstSide + secondSide)
                throw new ArgumentException("The thirdSide side is not less than the sum of the other two");

            _firstSide = firstSide;
            _secondSide = secondSide;
            _thirdSide = thirdSide;
        }

        public override double CalculateArea()
        {
            double p = (_firstSide + _secondSide + _thirdSide) / 2;

            return Math.Sqrt(p * (p - _firstSide) * (p - _secondSide) * (p - _thirdSide));
        }

        public bool IsRectangular()
        {
            var sides = new List<double> { _firstSide, _secondSide, _thirdSide };
            sides.Sort();

            double hypotenuse = sides[2];
            double firstLeg = sides[1];
            double secondLeg = sides[0];

            double threshold = 1e-8;

            return Math.Abs(hypotenuse * hypotenuse - (firstLeg * firstLeg + secondLeg * secondLeg)) < threshold;
        }
    }
}

