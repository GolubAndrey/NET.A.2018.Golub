using System;
using NUnit.Framework;
using FindNthRoot;

namespace NUnitFindNthRootTests
{
    [TestFixture]
    public class NUnitFindNthRootTester
    {
        [TestCase(-0.01,2,0.0001)]
        [TestCase(0.001, -2, 0.0001)]
        [TestCase(0.01, 2, -1)]
        public void FindNthRoot_ArgumentsLessThan0Test(double number,double power,double accurancy)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Root.RootNPower(number, power, accurancy));
        }

        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void FindNthRoot_ValidArgumentValues(double number, double power, double accurancy,double expectedResult)
        {
            double result = Root.RootNPower(number, power, accurancy);

            Assert.IsTrue(Math.Abs(expectedResult - result) < 0.1);
        }
    }
}