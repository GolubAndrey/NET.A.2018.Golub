using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SumVisitor<T>:MatrixVisitor<T>
    {
        protected override void Visit(SquareMatrix<T> squareMatrix, DiagonalMatrix<T> diagonalMatrix, Func<T, T, T> func)
        {
            SumDiagonalElements(squareMatrix, diagonalMatrix, func);
        }

        protected override void Visit(SquareMatrix<T> squareMatrix, SymmetricMatrix<T> symmetricMatrix, Func<T, T, T> func)
        {
            SumElements(squareMatrix, symmetricMatrix, func);
        }

        protected override void Visit(SquareMatrix<T> squareMatrix1, SquareMatrix<T> squareMatrix2, Func<T, T, T> func)
        {
            SumElements(squareMatrix1, squareMatrix2, func);
        }

        protected override void Visit(SymmetricMatrix<T> symmetricMatrix1, SymmetricMatrix<T> symmetricMatrix2, Func<T, T, T> func)
        {
            SumElements(symmetricMatrix1, symmetricMatrix2, func);
        }

        protected override void Visit(SymmetricMatrix<T> symmetricMatrix, DiagonalMatrix<T> diagonalMatrix, Func<T, T, T> func)
        {
            SumDiagonalElements(symmetricMatrix, diagonalMatrix, func);
        }

        protected override void Visit(SymmetricMatrix<T> symmetricMatrix, SquareMatrix<T> squareMatrix, Func<T, T, T> func)
        {
            throw new NotImplementedException();
        }

        protected override void Visit(DiagonalMatrix<T> diagonalMatrix1, DiagonalMatrix<T> diagonalMatrix2, Func<T, T, T> func)
        {
            SumDiagonalElements(diagonalMatrix1, diagonalMatrix2, func);
        }

        protected override void Visit(DiagonalMatrix<T> diagonalMatrix, SymmetricMatrix<T> symmetricMatrix, Func<T, T, T> func)
        {
            throw new NotImplementedException();
        }

        protected override void Visit(DiagonalMatrix<T> diagonalMatrix, SquareMatrix<T> squareMatrix, Func<T, T, T> func)
        {
            throw new NotImplementedException();
        }
        private void SumElements(AbstractMatrix<T> source,AbstractMatrix<T> addedMatrix, Func<T, T, T> func)
        {
            for (int i=0;i<source.Size;i++)
            {
                for (int j=0;j<source.Size;j++)
                {
                    source[i, j] = func(source[i, j], addedMatrix[i, j]);
                }
            }
        }

        private void SumDiagonalElements(AbstractMatrix<T> source, AbstractMatrix<T> addedMatrix, Func<T, T, T> func)
        {
            for (int i=0;i< source.Size;i++)
            {
                source[i, i] = func(source[i, i], addedMatrix[i, i]);
            }
        }
    }
}
