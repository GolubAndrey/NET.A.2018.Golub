using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueTests
{
    public class CastomForTest2
    {
        private int id;

        public CastomForTest2(int id) => this.id = id;
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj,null))
            {
                return false;
            }

            CastomForTest2 temp = obj as CastomForTest2;
            if (ReferenceEquals(temp,null))
            {
                return false;
            }
            return id == temp.id;
        }
    }
}
