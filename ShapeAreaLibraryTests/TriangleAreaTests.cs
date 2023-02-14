namespace ShapeAreaLibraryTests;
using ShapeAreaLibrary;

[TestClass]
public class TriangleAreaTests
{
    const double threshold = 1e-8;

    [TestMethod]
    public void Area_Of_An_Right_Triangle()
    {
        double firstSide = 3;
        double secondSide = 4;
        double thirdSide = 5;

        var triangle = new Triangle(firstSide, secondSide, thirdSide);

        Assert.AreEqual(triangle.CalculateArea(), 6, threshold);
    }

    [TestMethod]
    public void Area_Of_An_Orthogonal_Triangle()
    {
        double firstSide = 5.5;
        double secondSide = 5.5;
        double thirdSide = 5.5;

        var triangle = new Triangle(firstSide, secondSide, thirdSide);

        Assert.AreEqual(triangle.CalculateArea(), 13.098634232, threshold);
    }

    [TestMethod]
    public void Area_Of_An_Triangle_When_One_Side_Is_Zero()
    {
        double firstSide = 3;
        double secondSide = 4;
        double thirdSide = 0;

        Assert.ThrowsException<ArgumentException>(() => new Triangle(firstSide, secondSide, thirdSide));
    }

    [TestMethod]
    public void Area_Of_An_Triangle_When_One_Side_Is_Negative()
    {
        double firstSide = 3;
        double secondSide = -1;
        double thirdSide = 5;

        Assert.ThrowsException<ArgumentException>(() => new Triangle(firstSide, secondSide, thirdSide));
    }

    [TestMethod]
    public void Area_Of_An_Triangle_When_One_Side_Is_Equal_To_Sum_Of_Other_Two()
    {
        double firstSide = 3;
        double secondSide = 4;
        double thirdSide = 7;

        Assert.ThrowsException<ArgumentException>(() => new Triangle(firstSide, secondSide, thirdSide));
    }

    [TestMethod]
    public void Area_Of_An_Triangle_When_One_Side_Greater_Than_To_Sum_Of_Other_Two()
    {
        double firstSide = 3;
        double secondSide = 4;
        double thirdSide = 7.5;

        Assert.ThrowsException<ArgumentException>(() => new Triangle(firstSide, secondSide, thirdSide));
    }

    [TestMethod]
    public void Сhecking_Right_Triangle_For_Squareness()
    {
        double firstSide = 4;
        double secondSide = 5;
        double thirdSide = 3;

        var triangle = new Triangle(firstSide, secondSide, thirdSide);

        Assert.IsTrue(triangle.IsRectangular());
    }

    [TestMethod]
    public void Сhecking_Not_Right_Triangle_For_Squareness()
    {
        double firstSide = 6;
        double secondSide = 4;
        double thirdSide = 6;

        var triangle = new Triangle(firstSide, secondSide, thirdSide);

        Assert.IsFalse(triangle.IsRectangular());
    }
}
