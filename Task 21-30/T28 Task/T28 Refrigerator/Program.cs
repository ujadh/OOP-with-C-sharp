using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440


{
    public class FoodItem
    {
        public string Name { get; set; }

        public FoodItem(string name)
        {
            Name = name;
        }
    }

    public class Refrigerator
    {
        public List<FoodItem> Contents { get; }

        public Refrigerator()
        {
            Contents = new List<FoodItem>();
        }

        public void AddFoodItem(FoodItem foodItem)
        {
            Contents.Add(foodItem);
        }

        public void DisplayContents()
        {
            Console.WriteLine("Refrigerator Contents:");
            foreach (var foodItem in Contents)
            {
                Console.WriteLine($"- {foodItem.Name}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // Create a refrigerator
            Refrigerator myRefrigerator = new Refrigerator();

            // Add different food items to the refrigerator
            FoodItem eggs = new FoodItem("Eggs");
            FoodItem milk = new FoodItem("Milk");
            FoodItem vegetables = new FoodItem("Vegetables");
            FoodItem cheese = new FoodItem("Cheese");

            myRefrigerator.AddFoodItem(eggs);
            myRefrigerator.AddFoodItem(milk);
            myRefrigerator.AddFoodItem(vegetables);
            myRefrigerator.AddFoodItem(cheese);

            // Display the contents of the refrigerator
            myRefrigerator.DisplayContents();
        }
    }
}