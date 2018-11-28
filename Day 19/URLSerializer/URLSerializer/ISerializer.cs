using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLSerializer
{
    public interface ISerializer<U>
    {
        void Serialize(IEnumerable<U> serializeList,string way);
    }
}
