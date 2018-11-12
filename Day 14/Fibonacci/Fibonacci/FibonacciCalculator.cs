using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Fibonacci
{
    public static class FibonacciCalculator
    {
        public static IEnumerable<BigInteger> GenerateFibonacciNumbers(int count)
        {
            if (count<=0)
            {
                throw new ArgumentException($"{nameof(count)} can't be less than 1");
            }
            return GenerateFibonacciRow(count);
        }
        private static IEnumerable<BigInteger> GenerateFibonacciRow(int count)
        {
            BigInteger firstNumber = 0, secondNumber = 1, sum;
            for (int i=0;i<count;i++)
            {
                yield return firstNumber;
                sum = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = sum;
            }
        }
    }
}
