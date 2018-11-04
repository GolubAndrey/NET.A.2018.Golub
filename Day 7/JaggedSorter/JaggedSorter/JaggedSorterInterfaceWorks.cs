using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedSorter
{
    public class JaggedSorterInterfaceWorks
    {
        public delegate int Comparator(int[] array1, int[] array2);
        private int[][] array { get; set; }


        public JaggedSorterInterfaceWorks(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Null array");
            }
            this.array = array;
        }
        public void Sort(ISorter sorter)
        {
            Sort(sorter.Compare);
        }

        private void Sort(Comparator comparator)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (comparator(array[i], array[j]) > 0)
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
        }

        private void Swap(ref int[] array1, ref int[] array2)
        {
            int[] temp = array1;
            array1 = array2;
            array2 = temp;
        }
    }
}
