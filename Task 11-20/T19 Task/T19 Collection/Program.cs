using System;

// Base class - Vehicle
class Vehicle
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year
    {
        get; set;
    }

    public Vehicle(string make, string model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
    }

    public void Start()
    {
        Console.WriteLine("Turned on the Vehicle.");
    }

    public void Stop()
    {
        Console.WriteLine("Ignition Off.");
    }

    public virtual void Drive()
    {
        Console.WriteLine("The vehicle is on and moving.");
    }
}

// Derived class - Car
class Car : Vehicle
{
    public Car(string make, string model, int year)
        : base(make, model, year)
    {
    }

    public override void Drive()
    {
        Console.WriteLine($"The {Year} {Make} {Model} car is on the road.");
    }
}

// Derived class - Motorcycle
class Motorcycle : Vehicle
{
    public Motorcycle(string make, string model, int year)
        : base(make, model, year)
    {
    }

    public override void Drive()
    {
        Console.WriteLine($"The {Year} {Make} {Model} scooty is on the road.");
    }
}

class Program
{
    static void Main()
    {
        Car myCar = new Car("Yatri", "MadeInNepal", 2015);
        Motorcycle myMotorcycle = new Motorcycle("Deo", "Milaege Queen", 2023);

        myCar.Start();
        myCar.Drive();
        myCar.Stop();

        Console.WriteLine();

        myMotorcycle.Start();
        myMotorcycle.Drive();
        myMotorcycle.Stop();
    }
}
