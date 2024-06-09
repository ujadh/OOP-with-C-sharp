using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8840
{
    internal class Program
    {
        static int Gradecalculator(int score)
        {
            if (score >= 0 && score <= 19)
                return 0;
            else if (score >= 20 && score <= 29)
                return 1;
            else if (score >= 30 && score <= 39)
                return 2;
            else if (score >= 40 && score <= 49)
                return 3;
            else if (score >= 50 && score <= 59)
                return 4;
            else if (score >= 60 && score <= 70)
                return 5;
            else
                return -1; // This will be printed if the score is out of the specified range
        }

        static void Main(string[] args)
        {
            int score;
            Console.Write("Please enter the score: ");

            if (int.TryParse(Console.ReadLine(), out score))
            {
                int grade = Gradecalculator(score);

                if (grade != -1)
                {
                    Console.WriteLine($"The grade is: {grade}");
                }
                else
                {
                    Console.WriteLine("Error,Not a valid score.");
                }
            }
            else
            {
                Console.WriteLine("Error,Not a valid score.");
            }
        }
    }
}
