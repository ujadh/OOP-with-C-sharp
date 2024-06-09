using System;
using System.Collections.Generic;
using System.Linq;

public class InvoiceItem
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public double Total => Price * Quantity;

    public override string ToString()
    {
        return $"{Name} {Price:C} {Quantity} pieces {Total:C} total";
    }
}

public class Invoice
{
    public string Customer { get; set; }
    public List<InvoiceItem> Items { get; set; }

    public int ItemsCount => Items.Count;
    public int ItemsTogether => Items.Sum(item => item.Quantity);

    public double CountTotal()
    {
        return Items.Sum(item => item.Total);
    }

    public string PrintInvoice()
    {
        Console.WriteLine($"Customer {Customer}'s invoice:");
        Console.WriteLine("=================================");

        foreach (var item in Items)
        {
            Console.WriteLine(item.ToString());
        }

        Console.WriteLine("=================================");
        Console.WriteLine($"Total: {ItemsTogether} pieces {CountTotal():C}");

        return string.Empty; // Returning empty string for simplicity
    }
}

class Program
{
    static void Main()
    {
        Invoice invoice = new Invoice
        {
            Customer = "Aarati Bista",
            Items = new List<InvoiceItem>
            {
                new InvoiceItem { Name = "Milk", Price = 1.75, Quantity = 1 },
                new InvoiceItem { Name = "Beer", Price = 5.25, Quantity = 1 },
                new InvoiceItem { Name = "Butter", Price = 2.50, Quantity = 2 }
            }
        };

        PrintInvoice(invoice);

        Console.ReadLine(); // To keep the console window open
    }

    private static void PrintInvoice(Invoice invoice)
    {
        invoice.PrintInvoice();
    }
}
