using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SquareMatrix<T>:AbstractMatrix<T>
    {
        private T[,] matrix;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size">Size of matrix</param>
        public SquareMatrix(int size) : base(size)
        {
            matrix = new T[size, size];
        }

        /// <summary>
        /// Overriding indexator
        /// </summary>
        /// <param name="row">Number of row</param>
        /// <param name="column">Number of column</param>
        /// <returns>Element from matrix from the cell [row,column]</returns>
        public override T this[int row, int column]
        {
            get
            {
                PositionCheck(row, column);
                return this.matrix[row, column];
            }
            set
            {
                PositionCheck(row, column);
                T previousValue = this[row, column];
                InsertElement(value, row, column);
                OnChangeElement(row, column, previousValue, value);
            }
        }

        protected override void InsertElement(T value, int row, int column)
        {
            this.matrix[row, column] = value;
        }
    }
}
