using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedSorter
{
    public interface IArrayOperations
    {
        int GetSum(int[] array);
        int GetMinElement(int[] array);
        int GetMaxElement(int[] array);
    }
}
