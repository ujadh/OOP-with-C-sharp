using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440

{

    public class Tank
    {
        // Properties
        public string Name { get; set; }
        public string Type { get; set; }
        public int CrewNumber
        {
            get => crewNumber;
            set
            {
                if (value >= 2 && value <= 6)
                {
                    crewNumber = value;
                }
            }
        }
        public float SpeedMax { get; } = 100; // Read-only
        public float Speed => speed; // Read-only

        // Private field for Speed
        private float speed = 0;

        // Private field for CrewNumber
        private int crewNumber = 4;

        // Constructor
        public Tank(string name, string type)
        {
            Name = name;
            Type = type;
        }

        // Method to accelerate the tank
        public void AccelerateTo(float speed)
        {
            if (speed >= 0 && speed <= SpeedMax)
            {
                this.speed = speed;
            }
        }

        // Method to slow down the tank
        public void SlowTo(float speed)
        {
            if (speed >= 0 && speed <= SpeedMax)
            {
                this.speed = speed;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Tank Test Program!");

            Console.Write("Enter the Tank Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the Tank Type: ");
            string type = Console.ReadLine();

            Tank tank = new Tank(name, type);

            Console.Write("Enter the Crew Number (between 2 and 6): ");
            int crewNumber;
            if (int.TryParse(Console.ReadLine(), out crewNumber))
            {
                if (crewNumber >= 2 && crewNumber <= 6)
                {
                    tank.CrewNumber = crewNumber;
                }
                else
                {
                    Console.WriteLine("Invalid Crew Number. Using default value (4).");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Using default value (4).");
            }

            Console.Write("Enter the Speed (0 - 100): ");
            float speed;
            if (float.TryParse(Console.ReadLine(), out speed))
            {
                if (speed >= 0 && speed <= tank.SpeedMax)
                {
                    tank.AccelerateTo(speed);
                }
                else
                {
                    Console.WriteLine("Invalid Speed. Using default value (0).");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Using default value (0).");
            }

            // Display tank information
            Console.WriteLine("\nTank Information:");
            Console.WriteLine("Name: " + tank.Name);
            Console.WriteLine("Type: " + tank.Type);
            Console.WriteLine("Crew Number: " + tank.CrewNumber);
            Console.WriteLine("Maximum Speed: " + tank.SpeedMax);
            Console.WriteLine("Current Speed: " + tank.Speed);
        }
    }
}