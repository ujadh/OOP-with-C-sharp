using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440


{

    public class Item
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Item(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }

    public class PrintedItem : Item
    {
        public int Pages { get; set; }

        public PrintedItem(string title, string author, int pages)
            : base(title, author)
        {
            Pages = pages;
        }
    }

    public class ElectronicDevice : Item
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }

        public ElectronicDevice(string title, string author, string manufacturer, string model)
            : base(title, author)
        {
            Manufacturer = manufacturer;
            Model = model;
        }
    }

    public class Book : PrintedItem
    {
        public string Genre { get; set; }

        public Book(string title, string author, int pages, string genre)
            : base(title, author, pages)
        {
            Genre = genre;
        }
    }

    public class Magazine : PrintedItem
    {
        public int IssueNumber { get; set; }

        public Magazine(string title, string author, int pages, int issueNumber)
            : base(title, author, pages)
        {
            IssueNumber = issueNumber;
        }
    }

    public class Laptop : ElectronicDevice
    {
        public Laptop(string title, string author, string manufacturer, string model)
            : base(title, author, manufacturer, model)
        {
        }
    }

    public class CD : ElectronicDevice
    {
        public int TrackCount { get; set; }

        public CD(string title, string author, string manufacturer, string model, int trackCount)
            : base(title, author, manufacturer, model)
        {
            TrackCount = trackCount;
        }
    }

    public class DVD : ElectronicDevice
    {
        public int VideoDuration { get; set; }

        public DVD(string title, string author, string manufacturer, string model, int videoDuration)
            : base(title, author, manufacturer, model)
        {
            VideoDuration = videoDuration;
        }
    }

    public class BluRay : ElectronicDevice
    {
        public string Resolution { get; set; }

        public BluRay(string title, string author, string manufacturer, string model, string resolution)
            : base(title, author, manufacturer, model)
        {
            Resolution = resolution;
        }
    }

    public class Phone : ElectronicDevice
    {
        public string OperatingSystem { get; set; }

        public Phone(string title, string author, string manufacturer, string model, string operatingSystem)
            : base(title, author, manufacturer, model)
        {
            OperatingSystem = operatingSystem;
        }
    }

    public class Tablet : ElectronicDevice
    {
        public string OperatingSystem { get; set; }

        public Tablet(string title, string author, string manufacturer, string model, string operatingSystem)
            : base(title, author, manufacturer, model)
        {
            OperatingSystem = operatingSystem;
        }
    }

    class Program
    {
        static void Main()
        {
            Book book1 = new Book("Adhuro Prem", "Ujjwal", 300, "Romance");
            Magazine magazine1 = new Magazine("15 things", "Dada", 60, 23);
            Laptop laptop1 = new Laptop("Ujbro", "Dell", "Inspiron", "i5");
            CD cd1 = new CD("Bratabanda", "Mama", "Sony", "CDX-123", 12);
            DVD dvd1 = new DVD("Marriage", "Director", "LG", "DVD-999", 120);
            BluRay bluray1 = new BluRay("Blu-ray Title", "Director", "Sony", "BR-742", "4K");
            Phone phone1 = new Phone("Phone Title", "Apple", "Iphone 15 Plus", "IOS", "IOS 17");
            Tablet tablet1 = new Tablet("Tablet Title", "Apple", "iPad Air", "iOS", "iOS");

            Console.WriteLine("Book:");
            Console.WriteLine($"Title: {book1.Title}, Author: {book1.Author}, Pages: {book1.Pages}, Genre: {book1.Genre}");

            Console.WriteLine("\nMagazine:");
            Console.WriteLine($"Title: {magazine1.Title}, Author: {magazine1.Author}, Pages: {magazine1.Pages}, Issue Number: {magazine1.IssueNumber}");

            Console.WriteLine("\nLaptop:");
            Console.WriteLine($"Title: {laptop1.Title}, Author: {laptop1.Author}, Manufacturer: {laptop1.Manufacturer}, Model: {laptop1.Model}");

            Console.WriteLine("\nCD:");
            Console.WriteLine($"Title: {cd1.Title}, Author: {cd1.Author}, Manufacturer: {cd1.Manufacturer}, Model: {cd1.Model}");
        }
    }
}