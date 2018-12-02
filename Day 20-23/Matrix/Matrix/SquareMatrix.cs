using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SquareMatrix<T>:AbstractMatrix<T>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size">Size of matrix</param>
        public SquareMatrix(int size) : base(size)
        { }

        protected override void InsertElement(T value, int row, int column)
        {
            this.matrix[row, column] = value;
        }
    }
}
