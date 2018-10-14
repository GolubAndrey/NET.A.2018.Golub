using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting;
using System.Collections.Generic;

namespace SortingTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuickSort_NullArray()
        {
            // arrange
            int[] array = null;
            int[] expectedArray = null;

            // act
            Sorting.Sorting.QuickSort(array);

            // assert
            Assert.AreEqual(expectedArray, array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSort_NullArray()
        {
            // arrange
            int[] array = null;
            int[] expectedArray = null;

            // act
            int[] actual = Sorting.Sorting.MergeSort(array);

            // assert
            Assert.AreEqual(expectedArray, actual);
        }

        [TestMethod]
        public void MergeSort_5ElementArray()
        {
            // arrange
            int[] array = new int[5] { 5, 3, 4, 1, 2 };
            int[] expectedArray = new int[5] { 1, 2, 3, 4, 5 };

            // act
            int[] actual = Sorting.Sorting.MergeSort(array);

            // assert
            CollectionAssert.AreEqual(expectedArray, actual);
        }

        [TestMethod]
        public void MergeSort_1ElementArray()
        {
            // arrange
            int[] array = new int[1] { 1 };
            int[] expectedArray = new int[1] { 1 };

            // act
            int[] actual = Sorting.Sorting.MergeSort(array);

            // assert
            CollectionAssert.AreEqual(expectedArray, actual);
        }

        [TestMethod]
        public void MergeSort_EmptyArray()
        {
            // arrange
            int[] array = new int[0];
            int[] expectedArray = new int[0];

            // act
            int[] actual = Sorting.Sorting.MergeSort(array);

            // assert
            CollectionAssert.AreEqual(expectedArray, actual);
        }

        [TestMethod]
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

        [TestMethod]
        public void QuickSort_1ElementArray()
        {
            // arrange
            int[] array = new int[1] { 5 };
            int[] expectedArray = new int[1] { 5 };


            // act
            Sorting.Sorting.QuickSort(array);

            // assert
            CollectionAssert.AreEqual(expectedArray, array);
        }

        [TestMethod]
        public void QuickSort_EmptyArray()
        {
            // arrange
            int[] array = new int[0];
            int[] expectedArray = new int[0];


            // act
            Sorting.Sorting.QuickSort(array);

            // assert
            CollectionAssert.AreEqual(expectedArray, array);
        }

        [TestMethod]
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

        [TestMethod]
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
            for (int i=0;i<array.Length;i++)
            {
                array[i] = rand.Next(10000);
            }
            return array;
        }
        
    }
}
