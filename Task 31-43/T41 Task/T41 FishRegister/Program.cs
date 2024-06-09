using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440


{
    class Fish
    {
        public string Species { get; set; }
        public int Length { get; set; }
        public double Weight { get; set; }
        public string Place { get; set; }
        public string Location { get; set; }

        public override string ToString()
        {
            return $"{Species} {Length} cm {Weight} kg at {Place}, {Location}";
        }
    }

    class Fisherman
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public List<Fish> Fishes { get; set; } = new List<Fish>();

        public override string ToString()
        {
            return $"Fisherman: {Name} Phone: {Phone}";
        }
    }

    class FishingLocation
    {
        public string Name { get; set; }
        public string SpecificPlace { get; set; }
    }

    class FishRegister
    {
        private List<Fisherman> fishermen = new List<Fisherman>();
        private List<FishingLocation> fishingLocations = new List<FishingLocation>();

        public void AddFisherman(string name, string phone)
        {
            Fisherman fisherman = new Fisherman { Name = name, Phone = phone };
            fishermen.Add(fisherman);
            Console.WriteLine($"A new Fisherman added to Fish-register:\n- {fisherman}");
        }

        public void AddFish(string fishermanName, string species, int length, double weight, string place, string location)
        {
            Fisherman fisherman = fishermen.FirstOrDefault(f => f.Name == fishermanName);
            if (fisherman != null)
            {
                Fish fish = new Fish { Species = species, Length = length, Weight = weight, Place = place, Location = location };
                fisherman.Fishes.Add(fish);
                Console.WriteLine($"{fishermanName} got a new fish\n - {fish}");
            }
            else
            {
                Console.WriteLine($"Fisherman {fishermanName} not found.");
            }
        }

        public void PrintFishRegister()
        {
            Console.WriteLine("\nAll fish in register:");
            foreach (Fisherman fisherman in fishermen)
            {
                Console.WriteLine($"\n{fisherman.Name} has got following fish:");
                for (int i = 0; i < fisherman.Fishes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {fisherman.Fishes[i]}");
                }
            }
        }

        public void PrintSortedFishRegister()
        {
            Console.WriteLine("\nSorted register\n");
            var sortedFishes = fishermen.SelectMany(f => f.Fishes)
                                         .OrderByDescending(f => f.Weight)
                                         .ThenBy(f => f.Species)
                                         .ToList();

            Console.WriteLine("*** All fish in Fish-register: ***");
            for (int i = 0; i < sortedFishes.Count; i++)
            {
                Fish fish = sortedFishes[i];
                Fisherman fisherman = fishermen.First(f => f.Fishes.Contains(fish));
                Console.WriteLine($"{i + 1}) {fish} by: {fisherman.Name}");
            }
        }
    }

    class MyFishApp
    {
        static void Main(string[] args)
        {
            FishRegister fishRegister = new FishRegister();

            // Adding fishermen
            fishRegister.AddFisherman("Kirsi Kernel", "020-12345678");
            fishRegister.AddFisherman("Uolevi Kärppä", "041-12345678");

            // Adding fish
            fishRegister.AddFish("Kirsi Kernel", "Pike", 120, 4.5, "The Lake of Jyväskylä", "Jyväskylä");
            fishRegister.AddFish("Kirsi Kernel", "Salmon", 190, 13.2, "River Teno", "The Northern edge of Finland");
            fishRegister.AddFish("Uolevi Kärppä", "Crucian carp", 20, 0.2, "The Lake of Jyväskylä", "Jyväskylä");

            // Printing fish register
            fishRegister.PrintFishRegister();

            Console.WriteLine("\nPress enter key to continue...");
            Console.ReadLine();

            // Printing sorted fish register
            fishRegister.PrintSortedFishRegister();

            Console.WriteLine("\nPress enter key to continue...");
            Console.ReadLine();
        }
    }
}