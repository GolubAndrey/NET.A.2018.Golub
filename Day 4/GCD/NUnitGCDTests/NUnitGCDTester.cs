using System;
using NUnit.Framework;
using GCD;

namespace NUnitGCDTests
{
    [TestFixture]
    public class NUnitGCDTester
    {
        [TestCase(-1,2,5,6)]
        [TestCase(1)]
        public void EuclideCalculate_InvalideArray(params int[] array)
        {
            long time;
            Assert.Throws<ArgumentException>(() => GCDCounter.GCDEuclideCalculate(out time,array));
        }

        [TestCase(3,6,9,ExpectedResult =3)]
        [TestCase(1,4,8,ExpectedResult =1)]
        [TestCase(3,5,7,8,ExpectedResult =1)]
        [TestCase(0,0,0,ExpectedResult =0)]
        [TestCase(0,0,0,1,ExpectedResult =1)]
        public int EuclideCalculate_ValidArray(params int[] array)
        {
            long time;
            return GCDCounter.GCDEuclideCalculate(out time, array);
        }

        [TestCase(-1, 2, 5, 6)]
        [TestCase(1)]
        public void StainCalculate_InvalideArray(params int[] array)
        {
            long time;
            Assert.Throws<ArgumentException>(() => GCDCounter.GCDStainCalculate(out time, array));
        }

        [TestCase(4, 16, 24, ExpectedResult = 4)]
        [TestCase(1, 4, 8, ExpectedResult = 1)]
        [TestCase(3, 5, 7, 8, ExpectedResult = 1)]
        [TestCase(0, 0, 0, ExpectedResult = 0)]
        [TestCase(0, 0, 0, 1, ExpectedResult = 1)]
        public int StainCalculate_ValidArray(params int[] array)
        {
            long time;
            return GCDCounter.GCDStainCalculate(out time, array);
        }
    }
}