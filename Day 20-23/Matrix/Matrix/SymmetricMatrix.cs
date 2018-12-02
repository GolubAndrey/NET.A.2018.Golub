using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SymmetricMatrix<T>:AbstractMatrix<T>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size">Size of matrix</param>
        public SymmetricMatrix(int size):base(size)
        { }

        protected override void InsertElement(T value, int row, int column)
        {
            this.matrix[row, column] = value;
            if (row!=column)
            {
                this.matrix[column, row] = value;
            }
        }
    }
}
