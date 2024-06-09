using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440


{

    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }

    public class ShoppingCart
    {
        private readonly List<Product> products;

        public ShoppingCart()
        {
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void DisplayProducts()
        {
            Console.WriteLine("Your products in the shopping cart:");
            foreach (var product in products)
            {
                Console.WriteLine($"- product: {product.Name} {product.Price} e");
            }

            Console.WriteLine($"There are {products.Count} products in the shopping cart.");
        }
    }

    class Program
    {
        static void Main()
        {
            ShoppingCart shoppingCart = new ShoppingCart();

            // Adding products to the shopping cart
            shoppingCart.AddProduct(new Product("Milk", 1.4));
            shoppingCart.AddProduct(new Product("Bread", 2.2));
            shoppingCart.AddProduct(new Product("Butter", 3.2));
            shoppingCart.AddProduct(new Product("Cheese", 4.2));

            // Displaying products in the shopping cart
            shoppingCart.DisplayProducts();

            Console.ReadLine(); // To keep the console window open
        }
    }
}