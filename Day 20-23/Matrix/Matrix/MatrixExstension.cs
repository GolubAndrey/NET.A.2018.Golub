using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public static class MatrixExstension
    {
        public static void Add<T>(this AbstractMatrix<T> matrix, AbstractMatrix<T> addedMatrix)
        {
            if (matrix.Size != addedMatrix.Size)
            {
                throw new ArgumentException($"matrices must be the same size");
            }
            SumValidation<T>(matrix, addedMatrix);
            Sum((dynamic)matrix, (dynamic)addedMatrix);
        }

        private static void SumValidation<T>(AbstractMatrix<T> matrix1,AbstractMatrix<T> matrix2)
        {
            try
            {
                var temp = (dynamic)matrix1[0, 0] + (dynamic)matrix2[0, 0];
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException($"type {typeof(T).ToString()} does not implement the + method");
            }
        }
        

        private static void Sum<T>(SquareMatrix<T> matrix,SquareMatrix<T> addedMatrix)
        {
            SumElements<T>(matrix, addedMatrix);
        }

        private static void Sum<T>(SquareMatrix<T> matrix,SymmetricMatrix<T> addedMatrix)
        {
            SumElements<T>(matrix, addedMatrix);
        }

        private static void Sum<T>(SquareMatrix<T> matrix,DiagonalMatrix<T> addedMatrix)
        {
            SumDiagonalElements<T>(matrix, addedMatrix);
        }

        private static void Sum<T>(SymmetricMatrix<T> matrix,SymmetricMatrix<T> addedMatrix)
        {
            SumElements<T>(matrix, addedMatrix);
        }

        private static void Sum<T>(SymmetricMatrix<T> matrix,DiagonalMatrix<T> addedMatrix)
        {
            SumDiagonalElements<T>(matrix, addedMatrix);
        }

        private static void Sum<T>(DiagonalMatrix<T> matrix,DiagonalMatrix<T> addedMatrix)
        {
            SumDiagonalElements<T>(matrix, addedMatrix);
        }


        private static void SumElements<T>(AbstractMatrix<T> source, AbstractMatrix<T> addedMatrix)
        {
            for (int i = 0; i < source.Size; i++)
            {
                for (int j = 0; j < source.Size; j++)
                {
                    source[i, j] = (dynamic)source[i, j] + (dynamic)addedMatrix[i, j];
                }
            }
        }

        private static void SumDiagonalElements<T>(AbstractMatrix<T> source, AbstractMatrix<T> addedMatrix)
        {
            for (int i = 0; i < source.Size; i++)
            {
                source[i, i] = (dynamic)source[i, i] + (dynamic)addedMatrix[i, i];
            }
        }
    }
}
