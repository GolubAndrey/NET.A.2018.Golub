using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedSorter
{
    public class JaggedSorterDelegateWorks
    {
        public delegate int Comparator(int[] array1, int[] array2);
        private int[][] array { get; set; }


        public JaggedSorterDelegateWorks(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Null array");
            }
            this.array = array;
        }
        private void Sort(ISorter sorter)
        {
            Array.Sort(this.array, sorter);
        }

        public void Sort(Comparator comparator)
        {
            Sort((ISorter)comparator.Target);
        }
    }
}
