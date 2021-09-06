using System;

namespace Mandelbrot
{
    /// <summary>
    /// This class generates Mandelbrot sets in the console window!
    /// </summary>


    class Class1
    {
        /// <summary>
        /// This is the Main() method for Class1 -
        /// this is where we call the Mandelbrot generator!
        /// </summary>
        /// <param name="args">
        /// The args parameter is used to read in
        /// arguments passed from the console window
        /// </param>

        //Author - Parth Rustagi
        //Purpose - Taking the values of the coordinates for the pattern from the user 
        [STAThread]
        static void Main(string[] args)
        {
            //Defining variables for starting, ending, and difference for Imaginary Coordinates
            double sImageCoord = 0; 
            double eImageCoord = 0;
            double dImageCoord = 0;

            //Defining variables for starting, ending, and difference for Real Coordinates
            double sRealCoord = 0;
            double eRealCoord = 0;
            double dRealCoord = 0;

            //Defining a bool variable for the while loop so that user doesn't enter invalid details
            bool bImageCoord = false;
            Console.WriteLine("Enter the values for the start and end for the Imaginary coordinates");

            //Defining the loop so if the user enters wrong values for the coordinates then he can enter it again
            while (!bImageCoord)
            {
                Console.Write("Enter the starting value : ");
                sImageCoord = Convert.ToDouble(Console.ReadLine()); //Taking input from the user and converting it into a double

                Console.Write("Enter the ending value : ");
                eImageCoord = Convert.ToDouble(Console.ReadLine()); //Taking input from the user and converting it into a double

                if (sImageCoord > eImageCoord)
                {
                    bImageCoord = true; //To exit the loop if the values are correct
                }
                else
                {
                    Console.WriteLine("Error - Please enter a starting value that is higher than the ending value");
                }
            }

            //Defining a bool variable for the while loop so that user doesn't enter invalid details
            bool bRealCoord = false;
            Console.WriteLine("Enter the values for the start and end for the Real coordinates");
            
            //Defining the loop so if the user enters wrong values for the coordinates then he can enter it again
            while(!bRealCoord)
            {
                Console.Write("Enter the starting value : ");
                sRealCoord = Convert.ToDouble(Console.ReadLine()); //Taking input from the user and converting it into a double

                Console.Write("Enter the ending value : ");
                eRealCoord = Convert.ToDouble(Console.ReadLine()); //Taking input from the user and converting it into a double

                if (sRealCoord < eRealCoord)
                {
                    bRealCoord = true; //To exit the loop if the values are correct
                }
                else
                {
                    Console.WriteLine("Error - Please enter a ending value that is higher than the starting value");
                }
            }

            dImageCoord = (sImageCoord - eImageCoord) / 48; //To fit the imaginary coordinates pattern in the space
            dRealCoord = (sRealCoord - eImageCoord) / 80; //To fit the real coordinates pattern in the space

            double realCoord, imagCoord;
            double realTemp, imagTemp, realTemp2, arg;
            int iterations;
            for (imagCoord = sImageCoord; imagCoord >= eImageCoord; imagCoord -= dImageCoord)
            {
                for (realCoord = sRealCoord; realCoord <= eRealCoord; realCoord += dRealCoord)
                {
                    iterations = 0;
                    realTemp = realCoord;
                    imagTemp = imagCoord;
                    arg = (realCoord * realCoord) + (imagCoord * imagCoord);
                    while ((arg < 4) && (iterations < 40))
                    {
                        realTemp2 = (realTemp * realTemp) - (imagTemp * imagTemp)
                           - realCoord;
                        imagTemp = (2 * realTemp * imagTemp) - imagCoord;
                        realTemp = realTemp2;
                        arg = (realTemp * realTemp) + (imagTemp * imagTemp);
                        iterations += 1;
                    }
                    switch (iterations % 4)
                    {
                        case 0:
                            Console.Write(".");
                            break;
                        case 1:
                            Console.Write("o");
                            break;
                        case 2:
                            Console.Write("O");
                            break;
                        case 3:
                            Console.Write("@");
                            break;
                    }
                }
                Console.Write("\n");
            }
        }
    }
}

