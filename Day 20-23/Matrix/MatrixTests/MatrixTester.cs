using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Matrix;

namespace MatrixTests
{
    [TestFixture]
    public class MatrixTester
    {
        [Test]
        public void Constructor_ValideArgument_MatrixNotNull()
        {
            AbstractMatrix<int> matrix = new SquareMatrix<int>(5);

            Assert.NotNull(matrix);
        }

        [Test]
        public void Constructor_InvalideArgumet_ThrownException()
        {
            Assert.Throws<ArgumentException>(() => new SquareMatrix<int>(-1));
        }

        [TestCase(5, ExpectedResult = 5)]
        [TestCase(0, ExpectedResult = 0)]
        public int GetMatrixSize(int size)
        {
            AbstractMatrix<int> matrix = new SquareMatrix<int>(size);

            return matrix.Size;
        }

        [TestCase(5, 10, 2)]
        [TestCase(5, 4, 8)]
        public void Indexator_InvalideIndexes_ThrownException(int size, int row, int column)
        {
            Assert.Throws<ArgumentException>(() => new SymmetricMatrix<int>(size)[row, column] = 10);
        }

        [Test]
        public void Indexator_ValideIndexes_ChangedElement()
        {
            AbstractMatrix<int> matrix = new SymmetricMatrix<int>(5);

            matrix[1, 1] = 5;

            Assert.AreEqual(5, matrix[1, 1]);
        }

        [Test]
        public void SumMatrix()
        {
            SquareMatrix<int> matrix1 = new SquareMatrix<int>(1);
            matrix1[0, 0] = 1;
            SymmetricMatrix<int> matrix2 = new SymmetricMatrix<int>(1);
            matrix2[0, 0] = 2;

            SumVisitor<int> summator = new SumVisitor<int>();
            summator.Visit(matrix1, matrix2, (x, y) => x + y);

            Assert.AreEqual(3, matrix1[0, 0]);


        }
    }
}
