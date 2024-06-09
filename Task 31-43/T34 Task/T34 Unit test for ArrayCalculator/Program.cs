using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440


{
    public class ArrayCalculator
    {
        public static double Sum(double[] array)
        {
            double sum = 0;
            foreach (var number in array)
            {
                sum += number;
            }
            return sum;
        }

        public static double Average(double[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Array must not be empty.");
            }

            double sum = Sum(array);
            return sum / array.Length;
        }

        public static double Min(double[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Array must not be empty.");
            }

            double min = array[0];
            foreach (var number in array)
            {
                if (number < min)
                {
                    min = number;
                }
            }
            return min;
        }

        public static double Max(double[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Array must not be empty.");
            }

            double max = array[0];
            foreach (var number in array)
            {
                if (number > max)
                {
                    max = number;
                }
            }
            return max;
        }
    }

    class Program
    {
        static void Main()
        {
            double[] array = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };

            Console.WriteLine($"Sum = {ArrayCalculator.Sum(array):F2}");
            Console.WriteLine($"Ave = {ArrayCalculator.Average(array):F2}");
            Console.WriteLine($"Min = {ArrayCalculator.Min(array):F2}");
            Console.WriteLine($"Max = {ArrayCalculator.Max(array):F2}");

            Console.ReadLine(); // To keep the console window open
        }
    }
}