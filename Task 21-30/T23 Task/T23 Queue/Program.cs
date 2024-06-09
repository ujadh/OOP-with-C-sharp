using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440


{
    public interface ICheckoutQueue
    {
        void GoToQueue(string customerName);
        void ExitQueue();
        int Length { get; }
    }

    public class CheckoutQueue : ICheckoutQueue
    {
        private Queue<string> queue = new Queue<string>();
        private int servedCount = 0;

        public void GoToQueue(string customerName)
        {
            queue.Enqueue(customerName);
            Console.WriteLine($"There are now {Length} customers in the queue:");
            PrintQueue();
        }

        public void ExitQueue()
        {
            if (queue.Count > 0)
            {
                string servedCustomer = queue.Dequeue();
                servedCount++;
                Console.WriteLine($"I am now serving a customer: {servedCustomer} is the {servedCount} customer in line to be served");
                Console.WriteLine($"There are now {Length} customers in the queue:");
                PrintQueue();
            }
            else
            {
                Console.WriteLine("Checkout queue is empty.");
            }
        }

        public int Length
        {
            get { return queue.Count; }
        }

        private void PrintQueue()
        {
            foreach (var customer in queue)
            {
                Console.WriteLine(customer);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Let's test the customer queue for the checkout\n");

            CheckoutQueue checkoutQueue = new CheckoutQueue();

            while (true)
            {
                Console.WriteLine("Enter the name of the customer coming into the queue (press enter to stop):");
                string customerName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(customerName))
                {
                    break;
                }

                checkoutQueue.GoToQueue(customerName);
            }

            while (checkoutQueue.Length > 0)
            {
                checkoutQueue.ExitQueue();
            }

            Console.WriteLine("\nAll customers served");
        }
    }
}