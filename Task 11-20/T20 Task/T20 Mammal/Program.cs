using System;
using System.Collections.Generic;

// Abstract base class Mammal
abstract class Mammal
{
    public int Age { get; set; }

    public Mammal(int age)
    {
        Age = age;
    }

    public abstract void Move();
}

// Derived class Human from Mammal
class Human : Mammal
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }

    public Human(string name, double weight, double height, int age)
        : base(age)
    {
        Name = name;
        Weight = weight;
        Height = height;
    }

    public override void Move()
    {
        Console.WriteLine("Moving");
    }

    public void Grow()
    {
        Age++;
    }
}

// Derived class Baby from Human
class Baby : Human
{
    public string Diaper { get; set; }

    public Baby(string name, double weight, double height, int age, string diaper)
        : base(name, weight, height, age)
    {
        Diaper = diaper;
    }

    public override void Move()
    {
        Console.WriteLine("Crawling");
    }
}

// Derived class Adult from Human
class Adult : Human
{
    public string Auto { get; set; }

    public Adult(string name, double weight, double height, int age, string auto)
        : base(name, weight, height, age)
    {
        Auto = auto;
    }

    public override void Move()
    {
        Console.WriteLine("Walking");
    }
}

class Program
{
    static void Main()
    {
        List<Mammal> mammals = new List<Mammal>
        {
            new Baby("Krinza", 10, 0.7, 1, "Pamper"),
            new Adult("Ujjwal", 70, 1.75, 30, "Suzuki"),
            new Baby("Baby pari", 9, 0.6, 1, "Huggies"),
            new Adult("Ankit ", 65, 1.70, 35, "Lambo"),
            new Baby("Vukke", 8, 0.6, 1, "Mamy poko pants"),
            new Adult("Virat", 80, 1.80, 40, "Audi"),
        };

        Console.WriteLine("Mammals Info:");
        foreach (var mammal in mammals)
        {
            string name = (mammal is Human h) ? h.Name : "N/A";
            Console.WriteLine($"Name: {name}, Age: {mammal.Age}");
            mammal.Move();

            if (mammal is Baby baby)
            {
                Console.WriteLine($"Weight: {baby.Weight}, Height: {baby.Height}, Diaper: {baby.Diaper}");
            }
            else if (mammal is Adult adult)
            {
                Console.WriteLine($"Weight: {adult.Weight}, Height: {adult.Height}, Auto: {adult.Auto}");
            }

            Console.WriteLine();
        }
    }
}
