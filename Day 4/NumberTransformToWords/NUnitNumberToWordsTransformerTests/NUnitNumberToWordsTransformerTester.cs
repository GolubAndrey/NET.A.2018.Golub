using System;
using NUnit.Framework;
using NumberTransformToWords;

namespace NUnitNumberToWordsTransformerTests
{
    [TestFixture]
    public class NUnitNumberToWordsTransformerTester
    {
        [TestCase(new double[3] { -23.809, 0.295, 15.17 },new string[3] { "minus two three point eight zero nine", "zero point two nine five", "one five point one seven" })]
        [TestCase(new double[1] { 12.855},new string[1] {"one two point eight five five"})]
        public void TransformToWords_ValidDoubleArray(double[] array,string[] expectedResult)
        {
            string[] result = NumberToWordsTransformer.TransformToWords(array);

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestCase(null)]
        public void TransformToWords_NullDoubleArray(double[] array)
        {
            Assert.Throws<ArgumentNullException>(() => NumberToWordsTransformer.TransformToWords(array));
        }

        [TestCase(new double[0])]
        public void TransformToWords_EmptyDoubleArray(double[] array)
        {
            Assert.Throws<ArgumentException>(() => NumberToWordsTransformer.TransformToWords(array));
        }
    }
}