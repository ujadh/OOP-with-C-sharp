using System;

class Program
{
    static void Main()
    {
        // Create an array to store ratings from 5 judges
        double[] ratings = new double[5];
        double sumOfStylePoints = 0;

        // To get the ratings from each judge
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Lets enter the rating from each judge {i + 1}: ");
            double rating;

            // Using a while loop to check if the input is valid or not
            while (!double.TryParse(Console.ReadLine(), out rating))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                Console.Write($"Enter rating from judge {i + 1}: ");
            }

            ratings[i] = rating;
            sumOfStylePoints += rating;
        }

        // Loading variables to track the minimum and maximum ratings
        double minRating = ratings[0];
        double maxRating = ratings[0];

        //  This will find the minimum and maximum ratings
        foreach (double rating in ratings)
        {
            if (rating < minRating)
                minRating = rating;

            if (rating > maxRating)
                maxRating = rating;
        }

        // Now to subtract the smallest and largest ratings from the sum of style points
        sumOfStylePoints -= minRating + maxRating;

        //  Again displaying the result with two decimal places
        Console.WriteLine($"Total points of judges after subtracting largest and smallest from the sum is: {sumOfStylePoints}");
    }
}
