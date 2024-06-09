using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.TTC8440
{
    class Program
    {
        static void Main()
        {
            // This will ask the user for input
            Console.Write("Enter a sentence or word: ");
            string input = Console.ReadLine();

            //This if condition will check if the input is a palindrome and display the result
            if (WhetherPalindrome(input))
            {
                Console.WriteLine("The given input is a palindrome.");
            }
            else
            {
                Console.WriteLine("The given input is not a palindrome.");
            }
        }

        static bool WhetherPalindrome(string str)
        {
            // Remove spaces and convert to lowercase for case-insensitive comparison
            str = str.Replace(" ", "").ToLower();

            // We have to initialize two pointers, one at the beginning and one at the end of the string
            int left = 0;
            int right = str.Length - 1;

            // Compare characters from the start and end towards the middle
            while (left < right)
            {
                // This will verify if characters at the left and right positions do not match, it's not a palindrome
                if (str[left] != str[right])
                {
                    return false;
                }
                left++;
                right--;
            }

            //  If characters matched, so it's a palindrome
            return true;
        }
    }
}
