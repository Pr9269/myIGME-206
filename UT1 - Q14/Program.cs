using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT1___Q14
{
    //Author: Parth Rustagi
    //Purpose: BugSquash Game
    class Program
    {
        //Main program
        //Purpose: Asking the user for input base and its exponential power
        static void Main(string[] args)
        {
            string sNumber;
            int nX;
            //int nY ------------- Syntax Error: Missing semi-colon
            int nY;
            int nAnswer;

            //Console.WriteLine(This program calculates x ^ y.);-----------Syntex Error Mission collons
            Console.WriteLine("This program calculates x ^ y.");

            do
            {
                Console.Write("Enter a whole number for x: ");
                //Console.ReadLine(); ------------- Runtime Error because it is not storing the input value anywhere
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nX));

            do
            {
                Console.Write("Enter a positive whole number for y: ");
                sNumber = Console.ReadLine();
            } //while (int.TryParse(sNumber, out nX));-----------------logical error: number should be stored in nY and also while loop needs to include ! mark to exit the loop
            while (!int.TryParse(sNumber, out nY));

            // compute the factorial of the number using a recursive function
            nAnswer = Power(nX, nY);

            //Console.WriteLine("{nX}^{nY} = {nAnswer}");----------------syntax erorr colons were missing
            Console.WriteLine(nX + "^" + nY + "= " + nAnswer);
        }


        //int Power(int nBase, int nExponent) -----------logical error - method needs to be static 
        static int Power(int nBase, int nExponent)
        {
            int returnVal = 0;
            int nextVal = 0;

            // the base case for exponents is 0 (x^0 = 1)
            if (nExponent == 0)
            {
                // return the base case and do not recurse
                //returnVal = 0; ------------- cannot return the value 0
                return 1;
            }
            else
            {
                // compute the subsequent values using nExponent-1 to eventually reach the base case
                //nextVal = Power(nBase, nExponent + 1); ----------------logical error instead of increasing it by 1 it should be decreased.
                nextVal = Power(nBase, nExponent - 1);

                // multiply the base with all subsequent values
                returnVal = nBase * nextVal;
            }

            //returnVal; ---------------- logical error: return value was missing
            return returnVal;
        }

    }
}
