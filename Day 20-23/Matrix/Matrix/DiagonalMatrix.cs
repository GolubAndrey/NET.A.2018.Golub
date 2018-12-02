using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class DiagonalMatrix<T>:AbstractMatrix<T>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size">Size of matrix</param>
        public DiagonalMatrix(int size):base(size)
        { }

        protected override void InsertElement(T value, int row, int column)
        {
            if (row!=column)
            {
                throw new InvalidOperationException($"Element in position {row}-{column} can't be changed");
            }
            this.matrix[row, column] = value;
        }
    }
}
