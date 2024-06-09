using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440


{

    // Defining the Television class
    public class Television
    {
        // These properties will be implemented automatically
        public string Brand { get; set; }
        public int SizeInInches { get; set; }
        public bool IsTurnedOn { get; private set; }
        public int Volume { get; private set; }
        public int Channel { get; private set; }

        // A Constructor
        public Television(string brand, int sizeInInches)
        {
            Brand = brand;
            SizeInInches = sizeInInches;
            IsTurnedOn = false; // Here TV is initially turned off
            Volume = 75; //This is the default volume level
            Channel = 99; //This is default channel
        }

        //here is the method to turn on the TV
        public void TurnOn()
        {
            IsTurnedOn = true;
        }

        // Here is the method to turn off the TV
        public void TurnOff()
        {
            IsTurnedOn = false;
            Volume = 0; // When turned off, lets set volume to 0
            Channel = 0; // When turned off,lets  set channel to 0
        }

        // Now method to change the channel
        public void ChangeChannel(int channel)
        {
            if (IsTurnedOn)
            {
                if (channel >= 1 && channel <= 100)
                {
                    Channel = channel;
                }
                else
                {
                    Console.WriteLine("Error! Channel should be between 1 and 100.");
                }
            }
            else
            {
                Console.WriteLine("Please turn the tv on first.");
            }
        }

        // Now this is the method to adjust the volume
        public void AdjustVolume(int amount)
        {
            if (IsTurnedOn)
            {
                int newVolume = Volume + amount;
                if (newVolume >= 0 && newVolume <= 100)
                {
                    Volume = newVolume;
                }
                else
                {
                    Console.WriteLine("Sorry!Volume should be between 0 and 100.");
                }
            }
            else
            {
                Console.WriteLine("Please turn the tv on first if you want to adjust the volume.");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            //Here i am creating a television object
            Television tv = new Television("Huawai", 85);

            //Now to display TV properties
            Console.WriteLine($"Brand: {tv.Brand}, Size: {tv.SizeInInches} inches");
            Console.WriteLine($"IsTurnedOn: {tv.IsTurnedOn}, Volume: {tv.Volume}, Channel: {tv.Channel}");

            // To Turn on the TV
            tv.TurnOn();
            Console.WriteLine($"IsTurnedOn: {tv.IsTurnedOn}");

            // To Change the channel
            tv.ChangeChannel(5);
            Console.WriteLine($"Channel: {tv.Channel}");

            // To Adjust the volume
            tv.AdjustVolume(10);
            Console.WriteLine($"Volume: {tv.Volume}");

            // To Turn off the TV
            tv.TurnOff();
            Console.WriteLine($"IsTurnedOn: {tv.IsTurnedOn}");
        }
    }
}