using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public abstract class MatrixVisitor<T>
    {
        /// <summary>
        /// Method to do something with the matrix
        /// </summary>
        /// <param name="firstMatrix">Source matrix</param>
        /// <param name="secondMatrix">Added matrix</param>
        /// <param name="func">Function with logic to do with matrix's elements</param>
        public void Visit(AbstractMatrix<T> firstMatrix,AbstractMatrix<T> secondMatrix,Func<T,T,T> func)
        {
            Visit((dynamic)firstMatrix, (dynamic)secondMatrix, func);
        }

        protected abstract void Visit(SquareMatrix<T> squareMatrix1, SquareMatrix<T> squareMatrix2, Func<T, T, T> func);

        protected abstract void Visit(SquareMatrix<T> squareMatrix, SymmetricMatrix<T> symmetricMatrix, Func<T, T, T> func);
        protected abstract void Visit(SquareMatrix<T> squareMatrix, DiagonalMatrix<T> diagonalMatrix, Func<T, T, T> func);

        protected abstract void Visit(SymmetricMatrix<T> symmetricMatrix, SquareMatrix<T> squareMatrix, Func<T, T, T> func);

        protected abstract void Visit(SymmetricMatrix<T> symmetricMatrix1, SymmetricMatrix<T> symmetricMatrix2, Func<T, T, T> func);

        protected abstract void Visit(SymmetricMatrix<T> symmetricMatrix, DiagonalMatrix<T> diagonalMatrix, Func<T, T, T> func);

        protected abstract void Visit(DiagonalMatrix<T> diagonalMatrix, SquareMatrix<T> squareMatrix, Func<T, T, T> func);

        protected abstract void Visit(DiagonalMatrix<T> diagonalMatrix, SymmetricMatrix<T> symmetricMatrix, Func<T, T, T> func);

        protected abstract void Visit(DiagonalMatrix<T> diagonalMatrix1, DiagonalMatrix<T> diagonalMatrix2, Func<T, T, T> func);

    }
}
