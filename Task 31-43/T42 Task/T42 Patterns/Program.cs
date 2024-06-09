using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440


{

    abstract class Shape
    {
        public string Name { get; set; }

        public abstract double Area();

        public abstract double Circumference();
    }

    class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Name = "Circle";
            Radius = radius;
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override double Circumference()
        {
            return 2 * Math.PI * Radius;
        }
    }

    class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Name = "Rectangle";
            Width = width;
            Height = height;
        }

        public override double Area()
        {
            return Width * Height;
        }

        public override double Circumference()
        {
            return 2 * (Width + Height);
        }
    }

    class Shapes
    {
        public List<Shape> ShapeList { get; set; }

        public Shapes()
        {
            ShapeList = new List<Shape>();
        }

        public void AddShape(Shape shape)
        {
            ShapeList.Add(shape);
        }
    }

    class Program
    {
        static void Main()
        {
            Shapes shapes = new Shapes();

            // Adding Circle and Rectangle to the List
            shapes.AddShape(new Circle(1));
            shapes.AddShape(new Circle(2));
            shapes.AddShape(new Circle(3));

            shapes.AddShape(new Rectangle(10, 20));
            shapes.AddShape(new Rectangle(20, 30));
            shapes.AddShape(new Rectangle(40, 50));

            // Printing information for each shape
            foreach (var shape in shapes.ShapeList)
            {
                Console.WriteLine($"{shape.Name} {(shape is Circle ? $"Radius={((Circle)shape).Radius}" : $"Width={((Rectangle)shape).Width} Height={((Rectangle)shape).Height}")}" +
                                  $" Area={shape.Area():F2} Circumference={shape.Circumference():F2}");
            }

            Console.WriteLine("\nPress enter key to continue...");
            Console.ReadLine();
        }
    }
}