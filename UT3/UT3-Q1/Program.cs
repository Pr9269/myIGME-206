using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace UT3_Q1
{
    class Program
    {
        static string ReverseString(string abc)
        {
            char[] reverseCharacters = abc.ToCharArray();
            for (int i = 0; i < abc.Length; i++)
            {
                reverseCharacters[i] = abc[abc.Length - i - 1];
            }
            string reverseString = new string(reverseCharacters);
            return reverseString;
        }

        static char[] StringValue(string abc)
        {
            ArrayList list = new ArrayList();
            char[] character = abc.ToCharArray();
            for (int i = 0; i < character.Length; i++)
            {
                if (character[i] >= 'A' && character[i] <= 'Z')
                {
                    character[i] = (char)(character[i] + 'a' - 'A');
                }
            }
            return character;
        }

        static string RemovePuncts(string abc)
        {
            for (int i = 0; i < abc.Length; i++)
            {
                if (!((abc[i] >= 'A' && abc[i] <= 'Z') || (abc[i] >= 'a' && abc[i] <= 'z')))
                {
                    abc = abc.Remove(i, 1);
                    i--;
                }
            }
            return abc;
        }

        static bool StringPalindrome(string abc)
        {
            abc = RemovePuncts(abc);
            abc = new string(StringValue(abc));

            if (abc == ReverseString(abc))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please input a string: ");
            string userInput = Console.ReadLine();

            char[] userInputValues = StringValue(userInput);
            for (int i = 0; i < userInput.Length; i++)
            {
                Console.WriteLine("{0}: {1}", userInput[i], (int)userInputValues[i]);
            }

            Console.WriteLine("Reverse string is {0}", ReverseString(userInput));
            Console.WriteLine("The string is a palindrome? {0}", StringPalindrome(userInput));
        }
    }
}