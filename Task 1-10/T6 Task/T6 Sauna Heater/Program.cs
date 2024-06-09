using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440
{

    // DefinING the Heater class
    class Heater
    {
        // This is the private fields to store temperature and humidity
        private int temperature;
        private int humidity;

        // These are the properties to access and set temperature and humidity
        public int Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }

        public int Humidity
        {
            get { return humidity; }
            set { humidity = value; }
        }

        // A method to turn on the heater
        public string TurnOn()
        {
            return "Heater is turned on.";
        }

        // A method to turn off the heater
        public string TurnOff()
        {
            return "Heater is turned off.";
        }

        // A method to display the current state of the heater
        public string DisplayStatus()
        {
            return $"Heater temprature is {Temperature} and Humidity is {Humidity}"; 
        }
    }

    class Program
    {
        static void Main()
        {
            // Creating an instance of the Heater class
            Heater saunaHeater = new Heater();

            // Turning on the heater
            Console.WriteLine(saunaHeater.TurnOn());

            // Setting the temperature and humidity
            saunaHeater.Temperature = 82;
            saunaHeater.Humidity = 31;

            // Now displaying the current state of the heater
            Console.WriteLine("Sauna Heater Status:");
            Console.WriteLine(saunaHeater.DisplayStatus());

            // At the end,turning off the heater
            Console.WriteLine(saunaHeater.TurnOff());
        }
    }
}