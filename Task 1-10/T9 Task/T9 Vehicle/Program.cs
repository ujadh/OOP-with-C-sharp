using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440
{
    public class Vehicle
    {
        // These properties will be auto implemented
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Speed { get; set; }
        public int Tires { get; set; }

        //A Constructor
        public Vehicle(string brand, string model, int speed, int tires)
        {
            Brand = brand;
            Model = model;
            Speed = speed;
            Tires = tires;
        }

        //This is the method to display manufacturer and model information
        public string ShowInfo()
        {
            return $"Manufacturer: {Brand}, Model: {Model}";
        }

        // Here i am overriding ToString method to return all Vehicle properties as one string
        public override string ToString()
        {
            return $"Manufacturer: {Brand}, Model: {Model}, Speed: {Speed} mph, Tires: {Tires}";
        }
    }

    class Program
    {
        static void Main()
        {
            // Now creating a bicycle object
            Vehicle bicycle = new Vehicle("Motogp", "HERO", 10, 2);

            // LAlso creating a car object
            Vehicle car = new Vehicle("UJCAR", "ADBROZ", 150, 4);

            // Displaying information using ShowInfo() method
            Console.WriteLine("Bicycle Info:");
            Console.WriteLine(bicycle.ShowInfo());

            Console.WriteLine("\nCar Info:");
            Console.WriteLine(car.ShowInfo());

            // Now changing properties
            bicycle.Speed = 25;
            car.Tires = 8;

            // Displaying information using ToString() method
            Console.WriteLine("\nUpdated Bicycle Info:");
            Console.WriteLine(bicycle.ToString());

            Console.WriteLine("\nUpdated Car Info:");
            Console.WriteLine(car.ToString());
        }
    }
}