using System;

namespace ShapeAreaLibrary
{
    public abstract class Shape
    {
        public abstract double CalculateArea();

        /// <summary>
        /// Метод для вычисления площади фигуры без знания типа на этапе компиляции
        /// </summary>
        /// <param name="shapeName">Название фигуры</param>
        /// <param name="parameters">Параметры для вычисления площади конкретной фигуры</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Если имя фигуры невалидно, либо некорректное число параметров</exception>
        public static double RuntimeAreaCalculation(string shapeName, double[] parameters)
        {
            var shapeType = Type.GetType($"ShapeAreaLibrary.{shapeName}", throwOnError: false, ignoreCase: true);
            if (shapeType == null)
                throw new ArgumentException($"Invalid arguments");

            var objectParameters = parameters.Select(num => (object)num).ToArray();

            Shape? shape;
            try
            {
                shape = (Shape)Activator.CreateInstance(shapeType!, args: objectParameters)!;
            }
            catch (Exception ex) when (ex is MissingMethodException ||
                               ex is InvalidCastException)
            {
                throw new ArgumentException($"Invalid arguments");
            }

            if (shape == null)
                throw new ArgumentException($"Invalid arguments");

            return shape.CalculateArea();
        }
    }
}

