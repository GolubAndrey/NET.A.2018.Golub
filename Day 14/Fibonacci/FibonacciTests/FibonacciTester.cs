using System;
using NUnit.Framework;
using Fibonacci;
using System.Numerics;
using System.Collections.Generic;

namespace FibonacciTests
{
    [TestFixture]
    public class FibonacciTester
    {
        [TestCase(3,ExpectedResult ="0 1 1 ")]
        [TestCase(5,ExpectedResult ="0 1 1 2 3 ")]
        [TestCase(41,ExpectedResult ="0 1 1 2 3 5 8 13 21 34 55 89 144 233 377 610 987 1597 2584 4181 6765 10946 17711 28657 46368 75025 121393 196418 317811 514229 832040 1346269 2178309 3524578 5702887 9227465 14930352 24157817 39088169 63245986 102334155 ")]
        public string FibonacciRow_ValidParameters(int count)
        {
            string actualResult = "";
            foreach(var number in FibonacciCalculator.GenerateFibonacciNumbers(count))
            {
                actualResult += number.ToString() + " ";
            }
            return actualResult;
        }
        
        [TestCase(-4)]
        [TestCase(0)]
        public void FibonacciRow_InvalidParameters(int count)
        {
            Assert.Throws<ArgumentException>(() => FibonacciCalculator.GenerateFibonacciNumbers(count)); 
        }
    }
}