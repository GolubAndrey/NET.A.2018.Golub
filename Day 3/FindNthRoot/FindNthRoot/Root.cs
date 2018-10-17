using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNthRoot
{
    public static class Root
    {
        /// <summary>
        /// Find root n of degree
        /// </summary>
        /// <param name="number">Original number</param>
        /// <param name="power">Power</param>
        /// <param name="accuracy">Specified accuracy</param>
        /// <exception cref="ArgumentOutOfRangeException" Thrown when one of the parameters is less than 0</exeption>
        /// <returns>Number in n degree</returns>
        public static double RootNPower(double number,double power,double accuracy)
        {
            if (accuracy<0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (power<0)
            {
                throw new ArgumentOutOfRangeException();
            }

            double x0 = number / power;
            double x1 = (1 / power) * ((power - 1) * x0 + number / Math.Pow(x0, power - 1));

            while (Math.Abs(x1 - x0) > accuracy)
            {
                x0 = x1;
                x1 = (1 / power) * ((power - 1) * x0 + number / Math.Pow(x0, power - 1));
            }
            
            return x1;
        }
    }
}
