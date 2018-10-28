using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedSorter
{
    public interface ISorter:IComparer<int[]>,IArrayOperations
    {
    }
}
