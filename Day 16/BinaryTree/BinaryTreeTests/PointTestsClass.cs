using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeTests
{
    public struct PointTestsStruct
    {
        public int X { get; }
        public int Y { get; }

        public PointTestsStruct(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class PointComparer : Comparer<PointTestsStruct>
    {
        public override int Compare(PointTestsStruct x, PointTestsStruct y)
        {
            return x.X.CompareTo(y.Y);
        }
    }
}
