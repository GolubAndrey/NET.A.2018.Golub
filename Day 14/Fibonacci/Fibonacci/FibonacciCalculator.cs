using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public class FibonacciCalculator
    {
        /// <summary>
        /// Сalculates Fibonacci series with given indices
        /// </summary>
        /// <param name="lowIndex">Lower index</param>
        /// <param name="highIndex">Upper index</param>
        /// <returns>Row as int array</returns>
        public static int[] CalculateFibonacciRow(int lowIndex, int highIndex)
        {
            if (lowIndex>highIndex)
            {
                throw new ArgumentException($"{nameof(lowIndex)} should be less than {nameof(highIndex)}");
            }
            if (lowIndex==highIndex)
            {
                int flag;
                if (Math.Abs(lowIndex) % 2==0)
                {
                    flag = 1;
                }
                else
                {
                    flag = -1;
                }
                return new int[1] { FibonacciNumber(lowIndex)*flag };
            }
            if (lowIndex>0)
            {
                return PositiveFibonacciRow(lowIndex, highIndex);
            }
            if (highIndex<0)
            {
                return NegativeFibonacciRow(lowIndex, highIndex);
            }
            return NegativeFibonacciRow(lowIndex, -1).Concat(PositiveFibonacciRow(0, highIndex)).ToArray();
        } 

        private static int[] PositiveFibonacciRow(int lowIndex,int highIndex)
        {
            int[] result = new int[highIndex-lowIndex+1];
            for (int i=lowIndex;i<=highIndex;i++)
            {
                result[i-lowIndex] = FibonacciNumber(i);
            }
            return result;
        }

        private static int[] NegativeFibonacciRow(int lowIndex,int highIndex)
        {
            int[] result = PositiveFibonacciRow(Math.Abs(highIndex), Math.Abs(lowIndex));
            int flag = 1;
            for (int i=0;i<result.Length;i++)
            {
                result[i] *= flag;
                flag *= -1;
            }
            Array.Reverse(result);
            return result;
        }

        private static int FibonacciNumber(int n)
        {
            return n > 1 ? FibonacciNumber(n - 1) + FibonacciNumber(n - 2) : n;
        }
    }
}
