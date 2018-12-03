using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class DiagonalMatrix<T>:AbstractMatrix<T>
    {
        T[] matrix;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size">Size of matrix</param>
        public DiagonalMatrix(int size):base(size)
        {
            matrix = new T[size];
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
                if (row==column)
                {
                    return this.matrix[row];
                }
                return default(T);
                        
            }
            set
            {
                PositionCheck(row, column);
                if (row!=column)
                {
                    throw new ArgumentException($"{nameof(row)} must be equal {nameof(column)}");
                }
                T previousValue = this[row, column];
                InsertElement(value, row, column);
                OnChangeElement(row, column, previousValue, value);
            }
        }

        protected override void InsertElement(T value, int row, int column)
        {
            if (row!=column)
            {
                throw new InvalidOperationException($"Element in position {row}-{column} can't be changed");
            }
            this.matrix[row] = value;
        }
    }
}
