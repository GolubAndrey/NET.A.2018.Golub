using System;
using NUnit.Framework;
using Fibonacci;

namespace FibonacciTests
{
    [TestFixture]
    public class FibonacciTester
    {
        [TestCase(-2,2,ExpectedResult =new int[5] {-1, 1, 0, 1, 1})]
        [TestCase(-3, 2, ExpectedResult = new int[6] {2, -1, 1, 0, 1, 1 })]
        [TestCase(1, 4, ExpectedResult = new int[4] { 1, 1, 2, 3 })]
        [TestCase(-4, -1, ExpectedResult = new int[4] {-3, 2, -1, 1 })]
        [TestCase(2, 2, ExpectedResult = new int[1] { 1 })]
        public int[] FibonacciRow_ValidParameters(int lowIndex,int highIndex)
        {
            return FibonacciCalculator.CalculateFibonacciRow(lowIndex, highIndex);
        }
        
        [TestCase(-4, -5)]
        public void FibonacciRow_InvalidParameters(int lowIndex, int highIndex)
        {
            Assert.Throws<ArgumentException>(() => FibonacciCalculator.CalculateFibonacciRow(lowIndex, highIndex)); 
        }
    }
}