using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440


{

    // Define a Shape interface
    public interface IShape
    {
        double CalculateArea();
        double CalculatePerimeter();
    }

    // Implement classes for different shapes
    public class Circle : IShape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }

    public class Square : IShape
    {
        public double SideLength { get; set; }

        public Square(double sideLength)
        {
            SideLength = sideLength;
        }

        public double CalculateArea()
        {
            return Math.Pow(SideLength, 2);
        }

        public double CalculatePerimeter()
        {
            return 4 * SideLength;
        }
    }

    // Main program
    class Program
    {
        static void Main()
        {
            Circle circle = new Circle(5);
            Square square = new Square(4);

            DisplayShapeInfo(circle);
            DisplayShapeInfo(square);
        }

        static void DisplayShapeInfo(IShape shape)
        {
            Console.WriteLine($"Shape Type: {shape.GetType().Name}");
            Console.WriteLine($"Area: {shape.CalculateArea():F2}");
            Console.WriteLine($"Perimeter: {shape.CalculatePerimeter():F2}\n");
        }
    }
}