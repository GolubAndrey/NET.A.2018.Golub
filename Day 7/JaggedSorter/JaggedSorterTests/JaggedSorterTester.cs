using System;
using NUnit.Framework;
using JaggedSorter;

namespace JaggedSorterTests
{
    [TestFixture]
    public class JaggedSorterTester
    {
        private int[][] intArray;

        [SetUp]
        public void SetUp()
        {
            intArray = new int[][]
            {
                new int[] {1, 6, 9 },
                new int[] { -1, -5, 2, 7, 9},
                new int[] { },
                new int[] {0, 11, 12},
                new int[] {-10, 6, 4, 50},
                new int[] {0}
            };
        }

        [Test]
        public void JaggedSorting_SortByMinimumItems()
        {
            int[][] expectedArray = new int[][]
            {
                new int[] {-10, 6, 4, 50},
                new int[] { -1, -5, 2, 7, 9},
                new int[] {0, 11, 12},
                new int[] {0},
                new int[] {1, 6, 9 },
                new int[] {}
            };
            JaggedSorter.JaggedSorter sorter = new JaggedSorter.JaggedSorter(intArray);
            
            sorter.Sort(new MinElementSorter());

            CollectionAssert.AreEqual(expectedArray, intArray);
        }

        [Test]
        public void JaggedSorting_SortByMaximumItems()
        {
            int[][] expectedArray = new int[][]
            {
                new int[] {},
                new int[] {0},
                new int[] {1, 6, 9 },
                new int[] { -1, -5, 2, 7, 9},
                new int[] {0, 11, 12},
                new int[] {-10, 6, 4, 50}
            };
            JaggedSorter.JaggedSorter sorter = new JaggedSorter.JaggedSorter(intArray);

            sorter.Sort(new MaxElementSorter());

            CollectionAssert.AreEqual(expectedArray, intArray);
        }

        [Test]
        public void JaggedSorting_SortBySum()
        {
            int[][] expectedArray = new int[][]
            {
                new int[] {},
                new int[] {0},
                new int[] { -1, -5, 2, 7, 9},
                new int[] {1, 6, 9 },
                new int[] {0, 11, 12},
                new int[] {-10, 6, 4, 50}
            };
            JaggedSorter.JaggedSorter sorter = new JaggedSorter.JaggedSorter(intArray);

            sorter.Sort(new SumElementsSorter());

            CollectionAssert.AreEqual(expectedArray, intArray);
        }
    }
}