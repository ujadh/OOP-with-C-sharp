using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace JAMK.IT.TTC8440
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }

    class Program
    {
        static void Main()
        {
            List<Person> persons = new List<Person>();

            // Measure time for adding persons to the list
            Stopwatch addStopwatch = Stopwatch.StartNew();
            GeneratePersons(persons, 10000);
            addStopwatch.Stop();

            Console.WriteLine("List Collection:");
            Console.WriteLine($"- Adding time: {addStopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"- Persons count: {persons.Count}");
            Console.WriteLine($"- Random person: {GetRandomPersonInfo(persons)}\n");

            // Measure time for finding persons in the list
            Stopwatch findStopwatch = Stopwatch.StartNew();
            FindRandomPersons(persons, 1000);
            findStopwatch.Stop();

            Console.WriteLine("Finding persons in collection (by first name):");
            Console.WriteLine($"- Persons tried to find: 1000");
            Console.WriteLine($"- Total finding time: {findStopwatch.ElapsedMilliseconds} ms");

            Console.ReadLine(); // To keep the console window open
        }

        static void GeneratePersons(List<Person> persons, int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                string firstName = GenerateRandomName(4, random);
                string lastName = GenerateRandomName(10, random);
                persons.Add(new Person(firstName, lastName));
            }
        }

        static string GenerateRandomName(int length, Random random)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] name = new char[length];
            for (int i = 0; i < length; i++)
            {
                name[i] = chars[random.Next(chars.Length)];
            }
            return new string(name);
        }

        static string GetRandomPersonInfo(List<Person> persons)
        {
            Random random = new Random();
            int randomIndex = random.Next(persons.Count);
            Person randomPerson = persons[randomIndex];
            return $"{randomPerson.FirstName} {randomPerson.LastName}";
        }

        static void FindRandomPersons(List<Person> persons, int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                int randomIndex = random.Next(persons.Count);
                Person randomPerson = persons[randomIndex];
                Console.WriteLine($"- Found person with {randomPerson.FirstName} firstname: {randomPerson.FirstName} {randomPerson.LastName}");
            }
        }
    }
}