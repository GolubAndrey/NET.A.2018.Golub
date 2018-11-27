using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLSerializer
{
    interface IConverter<T,U>
    {
        IEnumerable<U> Convert(IEnumerable<T> list);
    }
}
