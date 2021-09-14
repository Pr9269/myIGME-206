using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8___Q5
{
    //Author: Parth Rustagi
    //Purpose: To write a code to solve the formula : z = 3y2 + 2x - 1 
    class Program
    {
        //Main Method
        //Purpose: Declaring variables to store and hold values for x, y, z and making a double data type array to hold them.
        static void Main(string[] args)
        {
            double x = 0;
            double y = 0;
            double z = 0;

            int nX = 0;
            int nY = 0;

            double[,,] zFunc = new double[30, 40, 3];

            // loop through each value of x, increment the int nX after each loop
            for (x = -1; x <= 1; x += 0.1, ++nX)
            {
                x = Math.Round(x, 1);

                nY = 0;

                // loop through each value of y, increment nY after each loop
                for (y = 1; y <= 4; y += 0.1, ++nY)
                {
                    y = Math.Round(y, 1);

                    z = 3 * Math.Pow(y, 2) + 2 * x + 1;

                    z = Math.Round(z, 3);

                    // store x, y and z for this (x,y) data point
                    zFunc[nX, nY, 0] = x;
                    zFunc[nX, nY, 1] = y;
                    zFunc[nX, nY, 2] = z;
                }
            }
        }
    }
}
