using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedSorter
{
    public class ArrayOperations
    {
        public int GetSum(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        public int GetMaxElement(int[] array)
        {
            int max = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }

        public int GetMinElement(int[] array)
        {
            int min = int.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            return min;
        }
    }

    public class MinElementSorter : ArrayOperations, ISorter
    {
        public MinElementSorter()
        { }
        public int Compare(int[] array1, int[] array2)
        {
            return GetMinElement(array1).CompareTo(GetMinElement(array2));
        }

    }

    public class MaxElementSorter : ArrayOperations, ISorter
    {
        public MaxElementSorter()
        { }
        public int Compare(int[] array1, int[] array2)
        {
            return GetMaxElement(array1).CompareTo(GetMaxElement(array2));
        }
    }

    public class SumElementsSorter : ArrayOperations, ISorter
    {
        public SumElementsSorter()
        { }
        public int Compare(int[] array1, int[] array2)
        {
            return GetSum(array1).CompareTo(GetSum(array2));
        }
    }
}
