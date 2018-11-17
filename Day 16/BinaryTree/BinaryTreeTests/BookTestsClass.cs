using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeTests
{
    public class BookTestsClass : IComparable<BookTestsClass>
    {
        public int Cost { get; }

        public BookTestsClass(int cost)
        {
            Cost = cost;
        }

        public int CompareTo(BookTestsClass other)
        {
            if (other == null)
                return 1;

            if (ReferenceEquals(this, other))
                return 0;

            return Cost.CompareTo(other.Cost);
        }

        public override bool Equals(object obj)
        {
            BookTestsClass book = obj as BookTestsClass;
            return Equals(book);
        }

        public bool Equals(BookTestsClass other)
        {
            return Cost.Equals(other.Cost);
        }

    }
}
