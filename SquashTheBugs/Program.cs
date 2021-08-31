using System;

namespace SquashTheBugs
{
    // Class Program
    // Author: David Schuh
    // Purpose: Bug squashing exercise
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Loop through the numbers 1 through 10 
        //          Output N/(N-1) for all 10 numbers
        //          and list all numbers processed
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare int counter
            //int i = 0
            //missing the semicolon ';'

            //int i = 0;
            //made the i variable a double integer type variable to handle the exception of 1/0
            double i = 0;


            string allNumbers = null;

            // loop through the numbers 1 through 10
            //for (i = 1; i < 10; ++i)
            //Chance < to <= to include the 10 in the loop
            for (i = 1; i <= 10; ++i)
            {
                // declare string to hold all numbers
                //string allNumbers = null;
                //allNumber string should be declared outside the loop

                // output explanation of calculation
                //Console.Write(i + "/" + i - 1 + " = ");
                //output expression of the calculation was missing brackets
                Console.Write(i + " / (" + i + "- 1)" + " = ");

                // output the calculation based on the numbers
                Console.WriteLine(i / (i - 1));

                // concatenate each number to allNumbers
                allNumbers += i + " ";
                //Console.Write(allNumbers);

                // increment the counter
                //i = i + 1;
                //extra incremental function
            }

            // output all numbers which have been processed
            //Console.WriteLine("These numbers have been processed: " allNumbers);
            //Missing + before the variable
            Console.WriteLine("These numbers have been processed: " + allNumbers);
        }
    }
}
