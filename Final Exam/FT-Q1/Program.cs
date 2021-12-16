using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1_Final_gaw
{
    class Program
    {
        static void Main(string[] args)
        {
            AlphabetCounter();
        }

        static void AlphabetCounter()
        {
            string stringInput;
            int[] characterCount = new int[50];
            int index = 0;

            Console.Write("Please input a string: ");
            stringInput = Console.ReadLine();


            foreach (char c in stringInput.ToLower())
            {
                if (Char.IsLetter(c))
                {
                    ++characterCount[c - 'a'];
                }
            }

            while( index < characterCount.Length)
            {
                Console.WriteLine($"{(char)(index + 'a')}: {characterCount[index]}");
                index++;
            }
        }
    }
}
