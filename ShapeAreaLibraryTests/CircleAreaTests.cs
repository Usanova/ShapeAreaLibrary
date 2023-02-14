using System;
using ShapeAreaLibrary;

namespace ShapeAreaLibraryTests
{
    [TestClass]
    public class CircleAreaTests
    {
        const double threshold = 1e-8;

        [TestMethod]
        public void Area_Of_Unit_Circle()
        {
            double radius = 1;

            var circle = new Circle(radius);

            Assert.AreEqual(circle.CalculateArea(), Math.PI, threshold);
        }

        [TestMethod]
        public void Area_Of_Not_Unit_Circle()
        {
            double radius = 1.1;

            var circle = new Circle(radius);

            Assert.AreEqual(circle.CalculateArea(), 3.80132711084, threshold);
        }

        [TestMethod]
        public void Area_Of_Circle_When_Radius_Is_Zero()
        {
            double radius = 0;

            Assert.ThrowsException<ArgumentException>(() => new Circle(radius));
        }

        [TestMethod]
        public void Area_Of_Circle_When_Radius_Is_Negative()
        {
            double radius = -1;

            Assert.ThrowsException<ArgumentException>(() => new Circle(radius));
        }
    }
}

