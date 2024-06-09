using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440


{
    public class Amplifier
    {
        private int volume;

        public int Volume
        {
            get => volume;
            set
            {
                if (value >= 0 && value <= 100)
                {
                    volume = value;
                    Console.WriteLine($"-> Amplifier volume is set to : {volume}");
                }
                else if (value < 0)
                {
                    volume = 0;
                    Console.WriteLine("-> Too low volume - Amplifier volume is set to minimum : 0");
                }
                else
                {
                    volume = 100;
                    Console.WriteLine("-> Too much volume - Amplifier volume is set to maximum : 100");
                }
            }
        }

        public Amplifier()
        {
            // Initialize the volume to a default value
            volume = 50;
        }
    }

    class Program
    {
        static void Main()
        {
            Amplifier amplifier = new Amplifier();

            while (true)
            {
                Console.Write("Give a new volume value (0-100) > ");
                if (int.TryParse(Console.ReadLine(), out int newVolume))
                {
                    amplifier.Volume = newVolume;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
    }
}