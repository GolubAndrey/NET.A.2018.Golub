using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public static class Searcher
    {
        /// <summary>
        /// Searching an item in a sorted array using the delegate comparison
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Sorter array of T type</param>
        /// <param name="element">Element to search</param>
        /// <param name="comparison">Delegate for searching</param>
        /// <returns>Index of element or -1 if not found</returns>
        public static int BinarySearch<T>(this T[] array, T element, Comparison<T> comparison)
        {
            CheckInputData<T>(array, element);

            int left = 0, right = array.Length - 1;
            int mid = right / 2;

            while (left <= right)
            {
                int result = comparison(array[mid], element);
                if (result == 0)
                {
                    return mid;
                }
                else
                {
                    if (result < 0)
                    {
                        left = mid + 1;
                        mid = (left + right) / 2;
                    }
                    else
                    {
                        if (true)
                        {
                            right = mid - 1;
                            mid = (left + right) / 2;
                        }
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// Searching an item in a sorted array using the interface IComparer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Sorter array of T type</param>
        /// <param name="element">Element to search</param>
        /// <param name="comparer">Searching interface</param>
        /// <returns>Index of element or -1 if not found</returns>
        public static int BinarySearch<T>(this T[] array, T element, IComparer<T> comparer)
        {
            return BinarySearch<T>(array, element, comparer.Compare);
        }

        /// <summary>
        /// Searching an item in a sorted array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Sorter array of T type</param>
        /// <param name="element">Searching interface</param>
        /// <exception cref="InvalidOperationException">If T doesn't implement IComparable</exception>
        /// <returns>Index of element or -1 if not found</returns>
        public static int BinarySearch<T>(this T[] array, T element)
        {
            CheckInputData<T>(array, element);
            if (element is IComparable)
            {
                IComparer<T> comparer = Comparer<T>.Default;
                return BinarySearch<T>(array, element, comparer.Compare);
            }
            else
                throw new InvalidOperationException($"Specified type does't implement IComparable< {element.GetType()} > interface");
        }

        private static void CheckInputData<T>(T[] array,T element)
        {
            if (array == null || array.Length == 0)
                throw new ArgumentNullException($"{nameof(array)} can't be equal to null or empty");

            if (ReferenceEquals(element, null))
                throw new ArgumentNullException($"{nameof(element)} can't be equal to null");
        }
    }
}
