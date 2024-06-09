using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440


{

    public class Dice
    {
        private Random random;

        public Dice()
        {
            random = new Random();
        }

        public int Roll()
        {
            return random.Next(1, 7); // Generates a random number between 1 and 6 (inclusive)
        }
    }

    class Program
    {
        static void Main()
        {
            Dice dice = new Dice();

            // Test throw
            int testThrow = dice.Roll();
            Console.WriteLine($"Dice, one test throw value is {testThrow}\n");

            // Number of throws input
            Console.Write("How many times you want to throw a dice: ");
            int numberOfThrows = int.Parse(Console.ReadLine());

            // Perform throws and calculate average
            int total = 0;
            int[] counts = new int[7]; // Index 0 is not used, 1 to 6 represent the faces of the dice

            for (int i = 0; i < numberOfThrows; i++)
            {
                int result = dice.Roll();
                total += result;
                counts[result]++;
            }

            double average = (double)total / numberOfThrows;

            Console.WriteLine($"\nDice is now thrown {numberOfThrows} times, average is {average:F4}\n");

            // Print counts for each number
            for (int i = 1; i <= 6; i++)
            {
                Console.WriteLine($"{i} count is {counts[i]}");
            }

            Console.ReadLine(); // To keep the console window open
        }
    }
}