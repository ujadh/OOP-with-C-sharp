using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440


{

    public class ElectricalDevice
    {
        public bool IsOn { get; set; }
        public float Power { get; set; }

        public ElectricalDevice()
        {
            IsOn = false;
            Power = 0.0f;
        }
    }

    public class PortableRadio : ElectricalDevice
    {
        private int volume;
        private float channelFrequency;

        public int Volume
        {
            get { return IsOn ? volume : 0; }
            set
            {
                if (IsOn)
                {
                    if (value >= 0 && value <= 9)
                    {
                        volume = value;
                    }
                }
            }
        }

        public float ChannelFrequency
        {
            get { return IsOn ? channelFrequency : 0.0f; }
            set
            {
                if (IsOn)
                {
                    if (value >= 2000.0f && value <= 26000.0f)
                    {
                        channelFrequency = value;
                    }
                }
            }
        }

        public PortableRadio()
        {
            volume = 0;
            channelFrequency = 0.0f;
        }

        public override string ToString()
        {
            return $"Radio Status: {IsOn}, Volume: {Volume}, Channel Frequency: {ChannelFrequency} Hz";
        }
    }

    class Program
    {
        static void Main()
        {
            PortableRadio radio = new PortableRadio();

            // Turning on the radio
            radio.IsOn = true;

            // Set volume and channel frequency
            radio.Volume = 9;
            radio.ChannelFrequency = 91.2f;

            // Print radio settings
            Console.WriteLine(radio.ToString());

            // Turn off the radio
            radio.IsOn = false;

            // Try to set volume and channel frequency (should not work)
            radio.Volume = 5;
            radio.ChannelFrequency = 15000.0f;

            // Print radio settings after turning off
            Console.WriteLine(radio.ToString());
        }
    }
}