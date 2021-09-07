using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE6_NUMBER_SEARCH
{
    //Author - Parth Rustagi
    //purpose - To generate a random number and let the user guess it.
    class Program
    {
        static void Main(string[] args)
        {
            //generating random number and storing it in a variable
            Random rand = new Random();
            int randomNumber = rand.Next(0, 101);
            Console.WriteLine(randomNumber);

            //To store the number of times users have already guessed
            int xCounter = 0;

            //To store the number user is going to input
            double searchNumber = 0;

            //bool variable to keep the loop running
            bool element = false;

            while (xCounter <= 8) //While loop runs only 8 time. That is the total number of attempts a user have.
            {
                if (xCounter == 8)
                {
                    Console.WriteLine("Maximum attempts reached.");
                    break;
                }

                while (!element)
                {
                    Console.Write("Enter your guess: ");
                    searchNumber = Convert.ToDouble(Console.ReadLine());

                    if (searchNumber >= 0 && searchNumber <= 100) //To check if the number is within the limits or not
                    {
                        element = true;
                    }
                }
                element = false;

                if (searchNumber == randomNumber) //When the number matches
                {
                    Console.WriteLine("Your guess is right, conguratulations");
                    break;
                }

                else if (searchNumber <= randomNumber) //if the number is lower than the actual number
                {
                    Console.WriteLine("Your guess is lower");
                    xCounter++;
                }

                else //when the number is higher than the actual number
                {
                    Console.WriteLine("Your guess is higher");
                    xCounter++;
                }
            }
            xCounter++;
        }
    }
}