using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitShifter
{
    public static class BitShifter
    {
        /// <summary>
        /// Takes bits from one number and inserts them into a given place of another number
        /// </summary>
        /// <param name="num1">First number</param>
        /// <param name="num2">Second number</param>
        /// <param name="i">Lower border of insertion</param>
        /// <param name="j">Upper border of insertion</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the third and fourth parameter is 
        /// more than 31 and less than 0 and third parameter more than fourth</exception>
        /// <returns>Bit swap result</returns>
        public static int InsertNumber(int num1,int num2,int i,int j)
        {
            if ((i>j)|| (i<0) || (j<0) || (i>31) || (j>31))
            {
                throw new ArgumentOutOfRangeException();
            }
            int ar1 = (~((int.MaxValue >> (30 - j + i)) << i)) & num1;
            int ar2 = (((int.MaxValue >> (30 - j + i)) << i)) & num2 << i;
            return ar1 | ar2;
        }
    }
}
