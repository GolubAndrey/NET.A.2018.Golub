using System;
using NUnit.Framework;
using BitShifter;

namespace BitShifterTests
{
    [TestFixture]
    public class NUnitTest1
    {
        [TestCase(15, 15, 0, 0, 15)]
        [TestCase(8, 15, 0, 0, 9)]
        [TestCase(8, 15, 3, 8, 120)]
        public void InsertNumber_ValidInputParameters(int num1,int num2,int i,int j,int result)
        {
            Assert.AreEqual(result, BitShifter.BitShifter.InsertNumber(num1, num2, i, j));
        }

        [TestCase(15, 15, -1, 0, 15)]
        [TestCase(8, 15, 0, -10, 9)]
        [TestCase(8, 15, 8, 3, 120)]
        [TestCase(8, 15, 40, 3, 120)]
        [TestCase(8, 15, 8, 56, 120)]
        [TestCase(8, 15, -1, 54, 120)]
        public void InsertNumber_InvalidParameters(int num1, int num2, int i, int j, int result)
        {
            Assert.Throws<ArgumentOutOfRangeException>(()=>BitShifter.BitShifter.InsertNumber(num1, num2, i, j));
        }

    }
}