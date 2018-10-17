using System;
using NUnit.Framework;
using FindNextBiggerNumber;

namespace NUnitFindNextBiggerNumberTests
{
    [TestFixture]
    public class NUnitFindNextBiggerNumberTester
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public int FindNextBiggerNumber_ValidNumber(int number)
        {
            int result = FinderNextBiggerNumber.FindNextBiggerNumber(number);

            return result;
        }

        [Test]
        public void FindNextBiggerNumber_InvalidNumber()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => FinderNextBiggerNumber.FindNextBiggerNumber(-10));
        }
    }
}