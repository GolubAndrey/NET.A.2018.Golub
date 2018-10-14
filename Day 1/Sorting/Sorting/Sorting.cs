using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public static class Sorting
    {
        /// <summary>
        /// Sorting an array of integers using quick sort
        /// </summary>
        /// <param name="array">The one-dimensional integer array to sort</param>
        /// <exception cref="System.ArgumentNullException">When array is null</exception>
        public static void QuickSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            if (array.Length == 1 || array.Length == 0)
            {
                return;
            }
            QSort(array, 0, array.Length-1);
        }

        //Quick sort with borders
        private static void QSort(int[] array, int start, int end)
        {
            int l = start, r = end;
            int mid = array[(start + end) / 2];

            while (l <= r)
            {
                while (array[l] < mid)
                {
                    l++;
                }

                while (array[r] > mid)
                {
                    r--;
                }

                if (l <= r)
                {
                    int temp = array[l];
                    array[l] = array[r];
                    array[r] = temp;
                    l++;
                    r--;
                }
            }

            if (start < r)
                QSort(array, start, r);
            if (end > l)
                QSort(array, l, end);
        }

        /// <summary>
        /// Sorting an array of integers using merge sort
        /// </summary>
        /// <param name="array">The one-dimensional integer array to sort</param>
        /// <exception cref="System.ArgumentNullException">When array is null</exception>
        public static int[] MergeSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            if (array.Length == 1 || array.Length == 0)
            {
                return array;
            }
            int mid_point = array.Length / 2;
            return Merge(MergeSort(array.Take(mid_point).ToArray()), MergeSort(array.Skip(mid_point).ToArray()));
        }

        //Merge arrays
        private static int[] Merge(int[] mass1, int[] mass2)
        {
            int a = 0, b = 0;
            int[] merged = new int[mass1.Length + mass2.Length];
            for (int i = 0; i < mass1.Length + mass2.Length; i++)
            {
                if (b < mass2.Length && a < mass1.Length)
                    if (mass1[a] > mass2[b] && b < mass2.Length)
                        merged[i] = mass2[b++];
                    else
                        merged[i] = mass1[a++];
                else
                    if (b < mass2.Length)
                    merged[i] = mass2[b++];
                else
                    merged[i] = mass1[a++];
            }
            return merged;
        }
    }
}
