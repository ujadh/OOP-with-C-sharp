using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440


{

    public class DynamoElevator
    {
        public int CurrentFloor { get; private set; }

        public DynamoElevator()
        {
            CurrentFloor = 1; // Initialize the elevator on the first floor
        }

        public bool GoTo(int floor, out string message)
        {
            if (floor < 1)
            {
                message = "Cannot go there!";
                return false;
            }
            else if (floor > 5)
            {
                message = "No such floor here!";
                return false;
            }
            else
            {
                CurrentFloor = floor;
                message = $"Elevator is now in floor: {CurrentFloor}";
                return true;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            DynamoElevator elevator = new DynamoElevator();

            while (true)
            {
                Console.Write("Give a new floor number (1-5) > ");
                if (int.TryParse(Console.ReadLine(), out int newFloor))
                {
                    string message;

                    if (elevator.GoTo(newFloor, out message))
                    {
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine(message);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
    }
}