using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440
{
    class Program
    {
        static void Main()
        {
            double distanceDriven;

            //This will ask the user for the distance driven
            Console.Write("Please enter distance driven in kilometers: ");
            string input = Console.ReadLine();

            // This will check and convert the user input to a number
            if (double.TryParse(input, out distanceDriven))
            {
                //  To generate random values for consumption and fuel price
                Random random = new Random();
                double consumption = random.Next(6, 10) / 100.0; // Random consumption between 6 - 9 liters/100km
                double fuelPrice = (random.Next(175, 251) / 100.0) * 1.0; // Random fuel price between 1.75€ - 2.50€ per litre

                // To Calculate the amount of gasoline consumed
                double gasConsumed = distanceDriven * consumption;

                //To calculate the money spent on gasoline
                double moneySpent = gasConsumed * fuelPrice;

                //Displaying the results to the user
                Console.WriteLine($" Total gas consumed in a trip: {gasConsumed} liters");
                Console.WriteLine($" Total money spent on gas in a trip: {moneySpent}");
            }
            else
            {
                Console.WriteLine("Error! Please enter a valid number for distance travelled.");
            }
        }
    }
}