using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using FindNextBiggerNumber;

namespace MSUnitFindNextBiggerNumberTests
{
    [TestClass]
    public class MSUnitFindNextBiggerNumberTester
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNextBiggerNumber_InvalidNumber()
        {
            int number = -10;

            FinderNextBiggerNumber.FindNextBiggerNumber(number);
        }

        [TestMethod]
        public void FindNextBiggerNumber_12Number()
        {
            int number = 12;
            int expectedResult = 21;

            int result =FinderNextBiggerNumber.FindNextBiggerNumber(number);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FindNextBiggerNumber_144Number()
        {
            int number = 144;
            int expectedResult = 414;

            int result = FinderNextBiggerNumber.FindNextBiggerNumber(number);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FindNextBiggerNumber_1234126Number()
        {
            int number = 1234126;
            int expectedResult = 1234162;

            int result = FinderNextBiggerNumber.FindNextBiggerNumber(number);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FindNextBiggerNumber_3456432Number()
        {
            int number = 3456432;
            int expectedResult = 3462345;

            int result = FinderNextBiggerNumber.FindNextBiggerNumber(number);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
