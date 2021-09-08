using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE6_NUMBER_SEARCH
{
    //Class Program
    //Author - Parth Rustagi
    //purpose - Number Guessing Game
    class Program
    {
        //Method Main
        //Purpose: To generate a random number with Random() function
        //         and let the user guess it within 8 tries.


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
            string inputNumber = "null";

            //bool variable to keep the loop running
            bool element = false;
            
            Console.WriteLine("Remember you only have 8 attempts.");
            
            while (xCounter <= 8) //While loop runs only 8 time. That is the total number of attempts a user will have.
            {
                if (xCounter == 8)
                {
                    Console.WriteLine("Maximum attempts reached.");
                    break;
                }

                while (!element)
                {
                    Console.WriteLine("Please enter a number between 0 and 100");
                    Console.Write("Enter your guess: ");
                    inputNumber = Console.ReadLine();

                    //To check if the input is not non-numeric
                    try
                    {
                        searchNumber = Double.Parse(inputNumber);
                    }

                    catch (FormatException)
                    {
                        Console.WriteLine("Non-numeric input detected, please try again");
                    }

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