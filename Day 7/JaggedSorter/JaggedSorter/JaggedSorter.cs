using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedSorter
{
    public class JaggedSorter
    {
        private int[][] array { get; set; }
       

        public JaggedSorter(int[][] array)
        {
            if (array==null)
            {
                throw new ArgumentNullException("Null array");
            }
            this.array = array;
        }

        
        private void Swap(int[] a,int[] b)
        {
            int[] temp = a;
            a = b;
            b = temp;
        }

        private void Sorting(ISorter sorter)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (sorter.Compare(array[i],array[j])>0)
                    {
                        Swap(array[i],array[j]);
                    }
                }
            }
        }
        public void Sort(ISorter sorter)
        {
            Array.Sort(this.array, sorter);
            //Sorting(sorter);
        }
    }

    public class ArrayOperations:IArrayOperations
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

    public class MinElementSorter: ArrayOperations,ISorter
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
