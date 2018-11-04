using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitShifter
{
    public static class BitShifter
    {
        private const int sizeofIntWithoutSign = 31;
        /// <summary>
        /// Takes bits from one number and inserts them into a given place of another number
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2">Second number</param>
        /// <param name="i">Lower border of insertion</param>
        /// <param name="j">Upper border of insertion</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the third and fourth parameter is 
        /// more than 31 and less than 0 and third parameter more than fourth</exception>
        /// <returns>Bit swap result</returns>
        public static int InsertNumber(int number1,int number2, int i,int j)
        {
            if ((i>j)|| (i<0) || (j<0) || (i>sizeofIntWithoutSign) || (j>sizeofIntWithoutSign))
            {
                throw new ArgumentOutOfRangeException();
            }
            if (i>j)
            {
                throw new ArgumentOutOfRangeException("i should be more than j");
            }
            if (i < 0)
            {
                throw new ArgumentOutOfRangeException("i should be more than 0");
            }
            if (j < 0)
            {
                throw new ArgumentOutOfRangeException("j should be more than 0");
            }
            if (i > sizeofIntWithoutSign)
            {
                throw new ArgumentOutOfRangeException("i should be more than sizeof(Int)-1");
            }
            if (j > sizeofIntWithoutSign)
            {
                throw new ArgumentOutOfRangeException("j should be more than sizeof(Int)-1");
            }
            int mask = ((int.MaxValue >> (30 - j + i)) << i);
            int ar1 = ~mask & number1;
            int ar2 = mask & number2 << i;
            return ar1 | ar2;
        }
    }
}
