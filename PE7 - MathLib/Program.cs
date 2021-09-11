using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Madlibs
{
    //Class Program
    //Author: Parth Rustagi
    //Purpose: MathLib Game
    class Program
    {
        //Main method
        //Purpose: To make a game where system first reads the file with file handling functions, then gives the user the choice to play which story he wants. 

        static void Main(string[] args)
        {
            int numLibs = 0;
            int cntr = 0;
            int nChoice = 0;
            string userPlay = "null";
            //StreamReader input;
            StreamReader input = null;

            //Asking the user whether he wants to play the game or not
            Console.WriteLine("Hello there! Do you want to play my game?");
            while(true)
            {
                userPlay = Console.ReadLine();
                if(userPlay.ToLower() == "yes")
                {
                    // open the template file to count how many Mad Libs it contains
                    try
                    {
                        input = new StreamReader("c:\\templates\\MadLibsTemplate.txt");
                        string line = null;
                        while ((line = input.ReadLine()) != null)
                        {
                            ++numLibs;
                        }
                    }

                    //Catching the exception while opening the file
                    catch (Exception e)
                    {
                        Console.WriteLine("Error with file: " + e.Message);
                    }

                    // close it
                    finally
                    {
                        if (input != null)
                        {
                            input.Close();
                        }
                    }

                    // only allocate as many strings as there are Mad Libs
                    string[] madLibs = new string[numLibs];

                    // read the Mad Libs into the array of strings
                    try
                    {
                        input = new StreamReader("c:\\templates\\MadLibsTemplate.txt");

                        string line = null;
                        while ((line = input.ReadLine()) != null)
                        {
                            // set this array element to the current line of the template file
                            madLibs[cntr] = line;

                            // replace the "\\n" tag with the newline escape character
                            madLibs[cntr] = madLibs[cntr].Replace("\\n", "\n");

                            ++cntr;
                        }
                    }

                    //Catching the exception while opening the file
                    catch (Exception e)
                    {
                        Console.WriteLine("Error with file: " + e.Message);
                    }

                    // close it
                    finally
                    {
                        if (input != null)
                        {
                            input.Close();
                        }
                    }

                    //input variable for the user
                    string userChoice = "null";

                    // prompt the user for which Mad Lib they want to play (nChoice)
                    Console.Write("Enter the number of the story you want to play.\nPlease Enter a number from 1 to " + numLibs + ": ");
                    while (true)
                    {
                        userChoice = Console.ReadLine();

                        //try and catch block to remove exceptions if a non-numeric input is given
                        try
                        {
                            nChoice = int.Parse(userChoice);
                        }

                        catch (FormatException)
                        {
                            Console.WriteLine("Non-numeric input detected, please try again");
                        }

                        if (nChoice <= 0 || nChoice > numLibs)
                        {
                            Console.Write("Please Enter a valid choice number: ");
                        }

                        else
                        {
                            break;
                        }
                    }

                    // split the Mad Lib into separate words
                    string[] words = madLibs[nChoice].Split(' ');
                    string resultString = null;
                    foreach (string word in words)
                    {
                        if (word.StartsWith("{"))
                        {
                            string newWord;
                            newWord = word.Replace('{', ' '); //Replacing {
                            newWord = newWord.Replace('}', ' '); //Replacing }
                            newWord = newWord.Replace('_', ' '); //Replacing _ with "space"
                            Console.WriteLine("Enter a word for " + newWord);
                            string word2 = Console.ReadLine();
                            resultString += " " + word2; //Concatenating two strings
                        }

                        else
                        {
                            resultString += " " + word;
                        }
                    }

                    Console.WriteLine(resultString);
                    break;
                }

                else if (userPlay.ToLower() == "no")
                {
                    Console.WriteLine("Goodbye!!!");
                    break;
                }

                else
                {
                    Console.WriteLine("Please enter a valid choice");
                }
            }
        }
    }
}
