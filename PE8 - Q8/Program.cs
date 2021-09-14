using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8___Q8
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = null;

            Console.Write("Enter a string: ");
            str = Console.ReadLine();
            str = str.ToLower();
            String[] s = str.Split(' ');

            string resultString = null;

            foreach(string word in s)
            {
                if(word.CompareTo("yes") == 0)
                {
                    string word1;
                    word1 = word.Replace("yes", "no");
                    resultString += " " + word1;
                }

                else if(word.CompareTo("no") == 0)
                {
                    string word1;
                    word1 = word.Replace("no", "yes");
                    resultString += " " + word1;
                }

                else
                {
                    resultString += " " + word;
                }

                Console.WriteLine("String is: " + resultString);
            }
        }
    }
}
