using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
            List<Person> personsList = new List<Person>();
            Dictionary<string, Person> personsDictionary = new Dictionary<string, Person>();

            // Measure time for adding persons to the list
            Stopwatch addListStopwatch = Stopwatch.StartNew();
            GeneratePersons(personsList, 10000);
            addListStopwatch.Stop();

            Console.WriteLine("List Collection:");
            Console.WriteLine($"- Adding time: {addListStopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"- Persons count: {personsList.Count}");
            Console.WriteLine($"- Random person: {GetRandomPersonInfo(personsList)}\n");

            // Measure time for finding persons in the list
            Stopwatch findListStopwatch = Stopwatch.StartNew();
            FindRandomPersons(personsList, 1000);
            findListStopwatch.Stop();

            Console.WriteLine("Finding persons in list (by first name):");
            Console.WriteLine($"- Persons tried to find: 1000");
            Console.WriteLine($"- Total finding time: {findListStopwatch.ElapsedMilliseconds} ms");

            Console.WriteLine("\n---------------------------------\n");

            // Measure time for adding persons to the dictionary
            Stopwatch addDictionaryStopwatch = Stopwatch.StartNew();
            GeneratePersons(personsDictionary, 10000);
            addDictionaryStopwatch.Stop();

            Console.WriteLine("Dictionary Collection:");
            Console.WriteLine($"- Adding time: {addDictionaryStopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"- Persons count: {personsDictionary.Count}");
            Console.WriteLine($"- Random person: {GetRandomPersonInfo(personsDictionary)}\n");

            // Measure time for finding persons in the dictionary
            Stopwatch findDictionaryStopwatch = Stopwatch.StartNew();
            FindRandomPersons(personsDictionary, 1000);
            findDictionaryStopwatch.Stop();

            Console.WriteLine("Finding persons in dictionary (by first name):");
            Console.WriteLine($"- Persons tried to find: 1000");
            Console.WriteLine($"- Total finding time: {findDictionaryStopwatch.ElapsedMilliseconds} ms");

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

        static void GeneratePersons(Dictionary<string, Person> persons, int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                string firstName = GenerateRandomName(4, random);
                string lastName = GenerateRandomName(10, random);
                // Ensure unique keys
                while (persons.ContainsKey(firstName))
                {
                    firstName = GenerateRandomName(4, random);
                }
                persons.Add(firstName, new Person(firstName, lastName));
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

        static string GetRandomPersonInfo(Dictionary<string, Person> persons)
        {
            Random random = new Random();
            int randomIndex = random.Next(persons.Count);
            Person randomPerson = persons.Values.ToList()[randomIndex];
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

        static void FindRandomPersons(Dictionary<string, Person> persons, int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                int randomIndex = random.Next(persons.Count);
                string randomKey = persons.Keys.ToList()[randomIndex];
                Person randomPerson = persons[randomKey];
                Console.WriteLine($"- Found person with {randomKey} firstname: {randomPerson.FirstName} {randomPerson.LastName}");
            }
        }
    }
}

/*the program used two different ways to organize and find information about people. One way was like having a list where you could find people by going through it one by one. The other way was like having a special book where each person had a unique name, and you could find them quickly by looking up that name.

The list was good for going through all the people in order, but if you wanted to find someone specific, you had to check each page. The special book (dictionary) was great for finding someone by their unique name very quickly, but making sure each name was unique took extra effort.

In real life, it's like choosing between a long list where things are in order, and a special book where things are organized by unique names. Each has its pros and cons depending on what you need to do.*/




