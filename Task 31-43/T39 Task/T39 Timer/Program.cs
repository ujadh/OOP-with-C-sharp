using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440


{

    public class Timer
    {
        private int seconds;
        private string notificationMessage;

        public Timer(int seconds, string notificationMessage = "Wake wake, the little bird")
        {
            SetTime(seconds);
            SetNotificationMessage(notificationMessage);
        }

        public void SetTime(int time)
        {
            if (time < 1 || time > 3600)
            {
                throw new ArgumentException("Time should be between 1 second and 60 minutes (3600 seconds).");
            }

            this.seconds = time;
        }

        public void SetNotificationMessage(string message)
        {
            notificationMessage = string.IsNullOrEmpty(message) ? "Wake wake, the little bird" : message;
        }

        public void Start()
        {
            Console.WriteLine($"Timer set for {seconds} seconds.");
            Thread.Sleep(seconds * 1000); // Convert seconds to milliseconds

            Console.WriteLine(notificationMessage);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Enter the time for the alarm (in seconds or minutes): ");
            string input = Console.ReadLine();

            Console.Write("Enter the alarm notification message (press Enter for default): ");
            string notificationMessage = Console.ReadLine();

            int time;
            if (int.TryParse(input, out time))
            {
                Timer timer = new Timer(time * (input.Contains("m") ? 60 : 1), notificationMessage);
                timer.Start();
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric value for time.");
            }

            Console.ReadLine(); // To keep the console window open
        }
    }
}