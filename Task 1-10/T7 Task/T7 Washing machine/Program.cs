using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440
{

    public class WashingMachine
    {
        // Properties
        public string Model { get; set; }
        public int Capacity { get; set; }
        public bool IsitRunning { get; private set; }

        // Constructor 1:  A Default Constructor
        public WashingMachine()
        {
            Model = "Life Good";
            Capacity = 5; // This is the default capacity in kg
            IsitRunning = false;
        }

        // Constructor 2:  A Parameterized Constructor
        public WashingMachine(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            IsitRunning = false;
        }

        // This is the method to start the washing machine
        public string Start()
        {
            if (!IsitRunning)
            {
                IsitRunning = true;
                return "Status:Now the Washing machine has started.";
            }
            else
            {
                return "Status:Washing machine is already running.";
            }
        }

        // Method to stop the washing machine
        public string Stop()
        {
            if (IsitRunning)
            {
                IsitRunning = false;
                return "Status:Now the washing machine has stopped.";
            }
            else
            {
                return "Status:Washing machine is not in use/turned off currently.";
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // Creating a washing machine object using the default constructor
            WashingMachine washerno1 = new WashingMachine();
            Console.WriteLine($"Model: {washerno1.Model}, Capacity: {washerno1.Capacity}kg, IsRunning: {washerno1.IsitRunning}");

            // Creating a washing machine object using the parameterized constructor
            WashingMachine washerno2 = new WashingMachine("ujbrroo", 9);
            Console.WriteLine($"Model: {washerno2.Model}, Capacity: {washerno2.Capacity}kg, IsRunning: {washerno2.IsitRunning}");

            // Starting the washing machine
            Console.WriteLine(washerno2.Start());
            Console.WriteLine($"IsRunning: {washerno2.IsitRunning}");

            // Trying to start it again
            Console.WriteLine(washerno2.Start());

            // Stopping the washing machine
            Console.WriteLine(washerno2.Stop());
            Console.WriteLine($"IsRunning: {washerno2.IsitRunning}");

            // Trying to stop it again
            Console.WriteLine(washerno2.Stop());
        }
    }
}