using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SymmetricMatrix<T>:AbstractMatrix<T>
    {
        T[][] matrix;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size">Size of matrix</param>
        public SymmetricMatrix(int size):base(size)
        {
            matrix = new T[size][];
            for (int i=0;i<size;i++)
            {
                matrix[i] = new T[size - i];
            }
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
                if (column<row)
                {
                    return matrix[column][row];
                }
                return matrix[row][column];
            }
            set
            {
                PositionCheck(row, column);
                T previousValue;
                if (column<row)
                {
                    previousValue = this[column,row];
                }
                else
                {
                    previousValue = this[row,column];
                }
                InsertElement(value, row, column);
                OnChangeElement(row, column, previousValue, value);
            }
        }

        protected override void InsertElement(T value, int row, int column)
        {
            if (column<row)
            {
                matrix[column][row] = value;
                return;
            }
            matrix[row][column] = value;
        }
    }
}
