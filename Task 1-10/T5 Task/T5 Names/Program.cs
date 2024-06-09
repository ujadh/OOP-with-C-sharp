using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440
{
    class Program
    {
        // This will define a struct to represent a person
        struct Person
        {
            public string Name;
            public int YearOfBirth;
            public int Age;
        }

        static void Main()
        {
            //This will create a list to store people's data
            List<Person> people = new List<Person>();

            Console.WriteLine("Enter names and year of birth (Name, Year of Birth). When you are done,press enter in empty line to terminate the execution:");

            // This will keep reading input until an empty line is entered
            while (true)
            {
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                    break;

                // I am spliting the input into name and year of birth
                string[] parts = input.Split(',');

                if (parts.Length != 2)
                {
                    Console.WriteLine("Invalid input format. Please enter a valid name and year of birth separated by a comma.");
                    continue;
                }

                // Computing the year of birth and calculate age
                if (int.TryParse(parts[1].Trim(), out int yearOfBirth))
                {
                    int age = DateTime.Now.Year - yearOfBirth;

                    // Now creating a new person and adding it to the list
                    Person person = new Person
                    {
                        Name = parts[0].Trim(),
                        YearOfBirth = yearOfBirth,
                        Age = age
                    };

                    people.Add(person);
                }
                else
                {
                    Console.WriteLine("Error! Please enter a valid number for the year of birth.");
                }
            }

            // Sort the list of people by age (from youngest to oldest)
            people.Sort((x, y) => x.Age.CompareTo(y.Age));

            // Display the sorted list of people
            Console.WriteLine("\nPeople sorted by age (youngest to oldest) according to user's input:");
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name} (Year of Birth: {person.YearOfBirth}, Age: {person.Age})");
            }
        }
    }
}