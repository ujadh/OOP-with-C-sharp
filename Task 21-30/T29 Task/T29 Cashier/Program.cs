using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440


{
    public interface ITransaction
    {
        string ShowTransaction();
        float Money { get; set; }
    }

    public class PaidWithCash : ITransaction
    {
        public int BillNumber { get; }
        public DateTime Date { get; }
        public float Money { get; set; }

        public PaidWithCash(int billNumber, DateTime date, float money)
        {
            BillNumber = billNumber;
            Date = date;
            Money = money;
        }

        public string ShowTransaction()
        {
            return $"Paid with cash: bill number {BillNumber} date {Date.ToShortDateString()} amount {Money:C}";
        }
    }

    public class PaidWithCard : ITransaction
    {
        public string CardNumber { get; }
        public DateTime Date { get; }
        public float Money { get; set; }

        public PaidWithCard(string cardNumber, DateTime date, float money)
        {
            CardNumber = cardNumber;
            Date = date;
            Money = money;
        }

        public string ShowTransaction()
        {
            return $"Transaction to bank: charge from card {CardNumber} date {Date.ToShortDateString()} amount {Money:C}";
        }
    }

    public class CashMachine
    {
        private List<ITransaction> transactions;
        private float cashInRegister;

        public CashMachine()
        {
            transactions = new List<ITransaction>();
            cashInRegister = 0;
        }

        public void ProcessTransaction(ITransaction transaction)
        {
            transactions.Add(transaction);

            if (transaction is PaidWithCash)
            {
                cashInRegister += transaction.Money;
            }
        }

        public float ShowTotal()
        {
            float total = 0;
            foreach (var transaction in transactions)
            {
                total += transaction.Money;
            }
            return total;
        }

        public float ShowCash()
        {
            return cashInRegister;
        }

        public float ShowTotalSales()
        {
            return ShowTotal() + cashInRegister;
        }
    }

    class Program
    {
        static void Main()
        {
            CashMachine cashMachine = new CashMachine();

            // Cash transactions
            PaidWithCash cashTransaction1 = new PaidWithCash(1, new DateTime(2024, 1, 1), 100);
            PaidWithCash cashTransaction2 = new PaidWithCash(2, new DateTime(2024, 1, 1), 50);

            // Card transactions
            PaidWithCard cardTransaction1 = new PaidWithCard("0001-0002", new DateTime(2024, 1, 1), 78.95f);
            PaidWithCard cardTransaction2 = new PaidWithCard("0003-0004", new DateTime(2024, 1, 1), 45.65f);

            // Process transactions
            cashMachine.ProcessTransaction(cardTransaction1);
            cashMachine.ProcessTransaction(cardTransaction2);
            cashMachine.ProcessTransaction(cashTransaction1);
            cashMachine.ProcessTransaction(cashTransaction2);

            // Display results
            Console.WriteLine(cardTransaction1.ShowTransaction());
            Console.WriteLine(cardTransaction2.ShowTransaction());

            Console.WriteLine($"Total money at bank account: {cashMachine.ShowTotal():C}");
            Console.WriteLine(cashTransaction1.ShowTransaction());
            Console.WriteLine(cashTransaction2.ShowTransaction());
            Console.WriteLine($"Total money in cash: {cashMachine.ShowCash():C}");
            Console.WriteLine($"Total sales today {DateTime.Now.DayOfWeek} {DateTime.Now.ToShortDateString()} is {cashMachine.ShowTotalSales():C}");

            Console.WriteLine("Program completed successfully. Press any key to quit.");
            Console.ReadKey();
        }
    }
}