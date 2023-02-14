using System;
using System.Reflection;
using ShapeAreaLibrary;

namespace ShapeAreaLibraryTests
{
    [TestClass]
    public class RuntimeAreaCalculationTests
    {
        const double threshold = 1e-8;

        [TestMethod]
        public void Calculate_Triangle_Area()
        {
            var shapeName = "Triangle";
            var sides = new double[] { 3, 4, 5 };

            var area = Shape.RuntimeAreaCalculation(shapeName, sides);

            Assert.AreEqual(area, 6, threshold);
        }

        [TestMethod]
        public void Calculate_Circle_Area()
        {
            var shapeName = "Circle";
            var radius = new double[] { 1 };

            var area = Shape.RuntimeAreaCalculation(shapeName, radius);

            Assert.AreEqual(area, Math.PI, threshold);
        }

        [TestMethod]
        public void Calculate_Area_Of_Unintended_Shape()
        {
            var shapeName = "Rhombus";
            var diagonals = new double[] { 10, 5 };

            Assert.ThrowsException<ArgumentException>(() => Shape.RuntimeAreaCalculation(shapeName, diagonals));
        }

        [TestMethod]
        public void Calculate_Area_With_Incorrect_Number_Of_Parameters()
        {
            var shapeName = "Circle";
            var parameters = new double[] { 10, 5 };

            Assert.ThrowsException<ArgumentException>(() => Shape.RuntimeAreaCalculation(shapeName, parameters));
        }

        [TestMethod]
        public void Area_Of_An_Triangle_When_One_Side_Is_Equal_To_Sum_Of_Other_Two()
        {
            var shapeName = "Triangle";
            var sides = new double[] { 3, 7, 4 };

            Assert.ThrowsException<TargetInvocationException>(() => Shape.RuntimeAreaCalculation(shapeName, sides));
        }
    }
}

