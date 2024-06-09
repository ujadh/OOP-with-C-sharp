using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440


{

    public delegate string StringProcessor(string input);

    public class StringTransformer
    {
        public static string ToUpperCase(string input)
        {
            return input.ToUpper();
        }

        public static string ToLowerCase(string input)
        {
            return input.ToLower();
        }

        public static string ToTitleCase(string input)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        public static string ToPalindrome(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter the string to process:");
            string input = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("Choose the treatment you want, you can give several treatments at once");
                Console.WriteLine("as one string, e.g. '123'");
                Console.WriteLine("1: to capital letters");
                Console.WriteLine("2: lowercase");
                Console.WriteLine("3: as a title");
                Console.WriteLine("4: as a palindrome");
                Console.WriteLine("0: terminate");

                Console.Write("Selection: ");
                string selection = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(selection) || !IsValidSelection(selection))
                {
                    Console.WriteLine("Invalid selection. Please enter valid choices.");
                    continue;
                }

                // Apply the selected treatments to the input
                string result = input;

                foreach (char c in selection)
                {
                    switch (c)
                    {
                        case '1':
                            result = StringTransformer.ToUpperCase(result);
                            break;
                        case '2':
                            result = StringTransformer.ToLowerCase(result);
                            break;
                        case '3':
                            result = StringTransformer.ToTitleCase(result);
                            break;
                        case '4':
                            result = StringTransformer.ToPalindrome(result);
                            break;
                        case '0':
                            // Terminate the loop
                            Console.WriteLine($"{input} changed to {result}\n");
                            goto Terminate;
                    }
                }

                Console.WriteLine($"{input} changed to {result}\n");
            }

        Terminate:
            Console.WriteLine("Program terminated.");
        }

        static bool IsValidSelection(string selection)
        {
            return selection.All(char.IsDigit) && selection.All(c => c >= '0' && c <= '4');
        }
    }
}