using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public abstract class AbstractMatrix<T>
    {
        #region fields
        private int size;
        #endregion

        protected event EventHandler<ElementChangingEventArgs> ChangeElement = delegate { };

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size">Size of matrix</param>
        /// <exception cref="ArgumentException">Thrown when size less than 0</exception>
        protected AbstractMatrix(int size)
        {
            if (size<0)
            {
                throw new ArgumentException($"{nameof(size)} - matrix size can't be less than 0");
            }
            this.size = size;
        }
        #endregion

        /// <summary>
        /// Indexator
        /// </summary>
        /// <param name="row">Number of row</param>
        /// <param name="column">Number of column</param>
        /// <returns>Element from matrix from the cell [row,column]</returns>
        public abstract T this[int row,int column] { get;set; }
        

        /// <summary>
        /// Get size of matrix
        /// </summary>
        public int Size => size;

        protected abstract void InsertElement(T value, int row, int columt);

        protected virtual void OnChangeElement(int row,int column,T previousValue,T newValue)
        {
            ChangeElement?.Invoke(this, new ElementChangingEventArgs(row, column, previousValue, newValue));
        }

        protected void PositionCheck(int row,int column)
        {
            if (row<0 || row>this.size)
            {
                throw new ArgumentException($"{nameof(row)} - invalide argument value");
            }
            if (column<0 || column>this.size)
            {
                throw new ArgumentException($"{nameof(column)} - invalide argument value");
            }
        }

        public class ElementChangingEventArgs : EventArgs
        {
            #region Constructors
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="row">Number of row</param>
            /// <param name="column">Number of column</param>
            /// <param name="previousValue">Previous value</param>
            /// <param name="newValue">New value</param>
            public ElementChangingEventArgs(int row, int column,T previousValue,T newValue)
            {
                Row = row;
                Column = column;
                PreviousValue = previousValue;
                NewValue = newValue;
            }
            #endregion

            #region properties
            /// <summary>
            /// Number of row
            /// </summary>
            public int Row { get; }

            /// <summary>
            /// Number of column
            /// </summary>
            public int Column { get; }

            /// <summary>
            /// Previous value
            /// </summary>
            public T PreviousValue { get; }

            /// <summary>
            /// New value
            /// </summary>
            public T NewValue { get; }
            #endregion
        }
    }

    
}
