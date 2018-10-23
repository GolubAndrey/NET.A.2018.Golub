using System;
using NUnit.Framework;
using Polynomial;

namespace PolynomialTests
{
    [TestFixture]
    public class PolynomialTester
    {
        [TestCase(new double[] { 0, 0, 0 }, ExpectedResult = 3)]
        public int CoefficientCountTest(double[] array)
        {
            Polynomial.Polynomial p = new Polynomial.Polynomial(array);
            return p.Length;
        }



        [TestCase(new double[] { 1, 5, 8 }, 0, ExpectedResult = 1)]
        [TestCase(new double[] { 1, 4, 7 }, 1, ExpectedResult = 4)]
        [TestCase(new double[] { 1, 4, 9 }, 5, ExpectedResult = 0)]
        public double IndexatorTest(double[] array, int index)
        {
            Polynomial.Polynomial p = new Polynomial.Polynomial(array);
            return p[index];
        }

        [TestCase(new double[] { 1, 4, 7, 1.1 }, new double[] { 0, 0.7, 0, 8, 10.3, 3.7 })]
        public void OverloadedPlusOperatorTest(double[] array1, double[] array2)
        {
            Polynomial.Polynomial p1 = new Polynomial.Polynomial(array1);
            Polynomial.Polynomial p2 = new Polynomial.Polynomial(array2);
            Polynomial.Polynomial p = p1 + p2;

            Polynomial.Polynomial expectedResult = new Polynomial.Polynomial(new double[] { 1, 4.7, 7, 9.1, 10.3, 3.7 });
            bool expected = true;

            for (int i = 0; i < expectedResult.Length; i++)
                if (Math.Abs(expectedResult[i] - p[i]) > 0.001)
                    expected = false;

            Assert.IsTrue(expected);
        }

        [TestCase(new double[] { 1, 4, 7, 1.1 }, new double[] { 0, 0.7, 0, 8, 10.3, 3.7 })]
        public void OverloadedMinusOperatorTest(double[] array1, double[] array2)
        {
            Polynomial.Polynomial p1 = new Polynomial.Polynomial(array1);
            Polynomial.Polynomial p2 = new Polynomial.Polynomial(array2);
            Polynomial.Polynomial p = p1 - p2;

            Polynomial.Polynomial expectedResult = new Polynomial.Polynomial(new double[] { 1, 3.3, 7, -6.9, -10.3, -3.7 });
            bool expected = true;

            for (int i = 0; i < expectedResult.Length; i++)
                if (Math.Abs(expectedResult[i] - p[i]) > 0.001)
                    expected = false;

            Assert.IsTrue(expected);
        }

        [TestCase(new double[] { 1, 4, 7, 1.1 })]
        public void PolynomialCompareTest(double[] array)
        {
            Polynomial.Polynomial p = new Polynomial.Polynomial(new double[] { 1, 4, 7, 1.1 });

            Assert.IsTrue(new Polynomial.Polynomial(array) == p);
        }

        [TestCase(new double[] { 0, 1, 2 }, ExpectedResult = "1*x^1 + 2*x^2")]
        [TestCase(new double[] { 1, 2, 0 }, ExpectedResult = "1*x^0 + 2*x^1")]
        [TestCase(new double[] { 1, 0, 2 }, ExpectedResult = "1*x^0 + 2*x^2")]
        public string PolynomialToStringTest(double[] array)
        {
            Polynomial.Polynomial p = new Polynomial.Polynomial(array);
            return p.ToString();
        }

        [TestCase(new double[] { 0, 1, 2 })]
        public void PolynomianEqualsTest(double[] array)
        {
            Polynomial.Polynomial p = new Polynomial.Polynomial(new double[] { 0, 1, 2 });

            Assert.AreEqual(new Polynomial.Polynomial(array), p);
        }
    }
}