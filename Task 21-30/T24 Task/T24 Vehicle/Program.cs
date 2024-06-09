using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440


{
    public class Tire
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string TireSize { get; set; }

        public Tire(string manufacturer, string model, string tireSize)
        {
            Manufacturer = manufacturer;
            Model = model;
            TireSize = tireSize;
        }
    }

    public class Vehicle
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public List<Tire> Tires { get; set; }

        public Vehicle(string name, string model)
        {
            Name = name;
            Model = model;
            Tires = new List<Tire>();
            Console.WriteLine($"Created a new vehicle {Name} model {Model}");
        }

        public void AddTire(Tire tire)
        {
            Tires.Add(tire);
            Console.WriteLine($"Tire {tire.Manufacturer} added to vehicle {Name}");
        }

        public void DisplayTires()
        {
            Console.WriteLine($"Vehicle Name: {Name} Model: {Model} has tires:");
            foreach (var tire in Tires)
            {
                Console.WriteLine($"-Name: {tire.Manufacturer} Model: {tire.Model} TireSize: {tire.TireSize}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // Create a new vehicle Porsche model 911
            Vehicle porsche = new Vehicle("Porsche", "911");
            porsche.AddTire(new Tire("Nokia", "Hakkapeliitta", "205R16"));
            porsche.AddTire(new Tire("Nokia", "Hakkapeliitta", "205R16"));
            porsche.AddTire(new Tire("Nokia", "Hakkapeliitta", "205R16"));
            porsche.AddTire(new Tire("Nokia", "Hakkapeliitta", "205R16"));

            // Display the tires of the Porsche
            porsche.DisplayTires();

            // Create a new vehicle Ducati model Diavel
            Vehicle ducati = new Vehicle("Ducati", "Diavel");
            ducati.AddTire(new Tire("MIC", "Pilot", "160R17"));
            ducati.AddTire(new Tire("MIC", "Pilot", "140R16"));

            // Display the tires of the Ducati
            ducati.DisplayTires();
        }
    }
}