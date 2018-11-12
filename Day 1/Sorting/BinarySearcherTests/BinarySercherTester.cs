using System;
using NUnit.Framework;
using Searching;
using System.Collections.Generic;

namespace BinarySearcherTests
{
    [TestFixture]
    public class BinarySercherTester
    {
        [TestCase(new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 3, ExpectedResult = 2)]
        [TestCase(new int[5] { 1, 2, 3, 4, 5}, 4, ExpectedResult = 3)]
        public int BinarySearcherTest_ValidValuesWithoutInterfaceAndDelegate<T>(T[] array, T key)
        {
            return Searcher.BinarySearch(array, key);
        }

        [TestCase(null, 3, ExpectedResult = 2)]
        [TestCase(new string[5] { "1", "2", "3", "4", "5" }, null, ExpectedResult = 3)]
        public void BinarySearcherTest_InvalidValuesWithoutInterfaceAndDelegate<T>(T[] array, T key)
        {
            Assert.Throws<ArgumentNullException>(() => Searcher.BinarySearch(array, key));
        }




    }
}