using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueTests
{
    public class CastomForTest:IEquatable<CastomForTest>
    {
        private int id;

        public CastomForTest(int id) => this.id = id;

        public bool Equals(CastomForTest castom)
        {
            return this.id == castom.id;
        }

        bool IEquatable<CastomForTest>.Equals(CastomForTest other)
        {
            if (other==null)
            {
                return false;
            }
            return Equals(other);
        }
    }
}
