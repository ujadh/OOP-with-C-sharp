using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440


{
    public class Window
    {
        // Properties
        public double Width { get; set; }
        public double Height { get; set; }

        // Constructor
        public Window(double width, double height)
        {
            Width = width;
            Height = height;
        }

        // Method to calculate the area of the window
        public double CalculateArea()
        {
            return Width * Height;
        }

        // Method to calculate the circumference of the window
        public double CalculateCircumference()
        {
            return 2 * (Width + Height);
        }

        // Method to calculate the amount of wood needed in square meters
        public double CalculateWoodUsage()
        {
            // Assuming the frame is made of wood and is 10 cm wide
            double frameWidth = 0.1; // in meters
            double frameArea = CalculateCircumference() * frameWidth;
            return frameArea;
        }

        // Method to calculate the amount of glass needed in square meters
        public double CalculateGlassUsage()
        {
            // Assuming the glass covers the entire area of the window
            return CalculateArea();
        }
    }

    class Program
    {
        static void Main()
        {
            // Example of using the Window class
            Console.Write("Enter the width of the window: ");
            double width = double.Parse(Console.ReadLine());

            Console.Write("Enter the height of the window: ");
            double height = double.Parse(Console.ReadLine());

            Window myWindow = new Window(width, height);

            Console.WriteLine($"\nArea of the window: {myWindow.CalculateArea()} square meters");
            Console.WriteLine($"Circumference of the window: {myWindow.CalculateCircumference()} meters");
            Console.WriteLine($"Wood usage: {myWindow.CalculateWoodUsage()} square meters");
            Console.WriteLine($"Glass usage: {myWindow.CalculateGlassUsage()} square meters");

            Console.ReadLine(); // To keep the console window open
        }
    }
}