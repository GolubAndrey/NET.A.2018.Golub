using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace NUnitTestProject1
{
    [TestFixture]
    public class NUnitTest1
    {

        [TestCase(null)]
        public void QuickSort_NullTest(int[] array)
        {
            Assert.Throws<ArgumentNullException>(() => Sorting.Sorting.QuickSort(null));
        }

        [TestCase(null)]
        public void MergeSort_NullTest(int[] array)
        {
            Assert.Throws<ArgumentNullException>(() => Sorting.Sorting.MergeSort(null));
        }

        [TestCase(new int[0], new int[0])]
        [TestCase(new int[1] { 1 }, new int[1] { 1 })]
        
        public void QuickSort_0and1LengthArrayTest(int[] array, int[] resultArray)
        {
            Sorting.Sorting.QuickSort(array);
            CollectionAssert.AreEqual(resultArray, array);
        }
        
        [TestCase(new int[0], new int[0])]
        [TestCase(new int[1] { 1 }, new int[1] { 1 })]
        public void MergeSort_0and1LengthArrayTest(int[] array, int[] resultArray)
        {
            Sorting.Sorting.MergeSort(array);
            CollectionAssert.AreEqual(array,resultArray);
        }

        [Test]
        public void QuickSort_5ElementArray()
        {
            // arrange
            int[] array = new int[5] { 5, 3, 4, 1, 2 };
            int[] expectedArray = new int[5] { 1, 2, 3, 4, 5 };


            // act
            Sorting.Sorting.QuickSort(array);

            // assert
            CollectionAssert.AreEqual(expectedArray, array);
        }

        [Test]
        public void MergeSort_5ElementArray()
        {
            // arrange
            int[] array = new int[5] { 5, 3, 4, 1, 2 };
            int[] expectedArray = new int[5] { 1, 2, 3, 4, 5 };


            // act
            int[] actual=Sorting.Sorting.MergeSort(array);

            // assert
            CollectionAssert.AreEqual(expectedArray, actual);
        }

        [Test]
        public void QuickSort_LargeArray()
        {
            // arrange
            int[] array = LargeArray();
            List<int> list = new List<int>(array);
            list.Sort();
            int[] expectedArray = list.ToArray();


            // act
            Sorting.Sorting.QuickSort(array);

            // assert
            CollectionAssert.AreEqual(expectedArray, array);

        }

        [Test]
        public void MergeSort_LargeArray()
        {
            // arrange
            int[] array = LargeArray();
            List<int> list = new List<int>(array);
            list.Sort();
            int[] expectedArray = list.ToArray();


            // act
            int[] actual = Sorting.Sorting.MergeSort(array);

            // assert
            CollectionAssert.AreEqual(expectedArray, actual);

        }
        private int[] LargeArray()
        {
            int[] array = new int[10000];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(10000);
            }
            return array;
        }
    }
}