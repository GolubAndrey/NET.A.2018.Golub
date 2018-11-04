using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial
{
    public sealed class Polynomial:IEquatable<Polynomial>,ICloneable
    {
        private double[] coefficients { get; set; }

        private const double accuracy = 0.0001;

        /// <summary>
        /// Constructor which gets power-related coefficients
        /// </summary>
        /// <param name="array">coefficients</param>
        public Polynomial(double[] array)
        {
            double[] tempArray = new double[array.Length];
            Array.Copy(array, tempArray, 0);
            TestingArray(tempArray);
            coefficients = tempArray;
        }
        
        /// <summary>
        /// Getting coefficients according to the power
        /// </summary>
        /// <param name="index">Power</param>
        /// <exception cref="ArgumentOutOfRangeException">When index less than 0 and more than last power of polynom</exception>
        /// <returns>Coefficient</returns>
        public double this[int index]
        {
            get
            {
                if (index<0)
                {
                    throw new ArgumentOutOfRangeException("Index should be more than 0");
                }
                if (index>=Length)
                {
                    throw new ArgumentOutOfRangeException("Index should be less than array's length");
                }
                return coefficients[index];
            }
        }

        public int Length { get { return coefficients.Length; } }
        
        /// <summary>
        /// Overloading of + operator
        /// </summary>
        /// <param name="firstPolynomial">First polynom</param>
        /// <param name="secondPolynomial">Second polynom</param>
        /// <returns>The result of the sum of two polynomias</returns>
        public static Polynomial operator +(Polynomial firstPolynomial,Polynomial secondPolynomial)
        {
            int maxLength = firstPolynomial.Length > secondPolynomial.Length ? 
                firstPolynomial.Length : secondPolynomial.Length;
            int minLength = firstPolynomial.Length < secondPolynomial.Length ?
                firstPolynomial.Length : secondPolynomial.Length;

            double[] resultCoefficients = new double[maxLength];
            for (int i=0;i<minLength;i++)
            {
                resultCoefficients[i] = firstPolynomial[i] + secondPolynomial[i];
            }
            if (firstPolynomial.Length>secondPolynomial.Length)
            {
                Array.Copy(firstPolynomial.coefficients, minLength, resultCoefficients,
                    minLength, maxLength - minLength);
            }
            else
            {
                Array.Copy(secondPolynomial.coefficients, minLength, resultCoefficients,
                    minLength, maxLength - minLength);
            }
            return new Polynomial(resultCoefficients);
        }

        /// <summary>
        /// Overloading of - operator
        /// </summary>
        /// <param name="firstPolynomial">First polynom</param>
        /// <param name="secondPolynomial">Second polynom</param>
        /// <returns>The result of the differences of two polynomias</returns>
        public static Polynomial operator -(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            return firstPolynomial + new Polynomial(InvertingArray(secondPolynomial.coefficients));
        }

        /// <summary>
        /// Overloading of * operator
        /// </summary>
        /// <param name="firstPolynomial">Polynom</param>
        /// <param name="multiplier">Number</param>
        /// <returns>The result of the multiplications of polynom and number</returns>
        public static Polynomial operator *(Polynomial firstPolynomial,int multiplier)
        {
            double[] resultArray = new double[firstPolynomial.Length];
            for (int i=0;i<firstPolynomial.Length;i++)
            {
                resultArray[i] = firstPolynomial[i] * multiplier;
            }
            return new Polynomial(resultArray);
        }

        /// <summary>
        /// Overloading of * operator
        /// </summary>
        /// <param name="multiplier">Number</param>
        /// <param name="firstPolynomial">Polynom</param>
        /// <returns>The result of the multiplications of polynom and number</returns>
        public static Polynomial operator *(int multiplier,Polynomial firstPolynomial)
        {
            double[] resultArray = new double[firstPolynomial.Length];
            for (int i = 0; i < firstPolynomial.Length; i++)
            {
                resultArray[i] = firstPolynomial[i] * multiplier;
            }
            return new Polynomial(resultArray);
        }

        /// <summary>
        /// Overloading of * operator
        /// </summary>
        /// <param name="firstPolynomial">First polynom</param>
        /// <param name="secondPolynomial">Second polynom</param>
        /// <returns>The result of the multiplication of two polynomias</returns>
        public static Polynomial operator *(Polynomial firstPolynomial,Polynomial secondPolynomial)
        {
            int resultLength = firstPolynomial.Length + secondPolynomial.Length;

            double[] resultCoefficients = new double[resultLength];

            for (int i = 0; i < firstPolynomial.Length; i++)
                for (int j = 0; j < secondPolynomial.Length; j++)
                    resultCoefficients[i + j] += firstPolynomial[i] * firstPolynomial[j];

            return new Polynomial(resultCoefficients);
        }

        /// <summary>
        /// Overloading of / operator
        /// </summary>
        /// <param name="firstPolynomial">Polynom</param>
        /// <param name="devider">Number</param>
        /// <returns>The result of the division of polynom and number</returns>
        public static Polynomial operator /(Polynomial firstPolynomial,double devider)
        {
            double[] resultArray = new double[firstPolynomial.Length];
            for (int i = 0; i < firstPolynomial.Length; i++)
            {
                resultArray[i] = firstPolynomial[i] / devider;
            }
            return new Polynomial(resultArray);
        }

        /// <summary>
        /// Overloading of / operator
        /// </summary>
        /// <param name="devider">Number</param>
        /// <param name="firstPolynomial">Polynom</param>
        /// <returns>The result of the division of polynom and number</returns>
        public static Polynomial operator /(double devider,Polynomial firstPolynomial)
        {
            return firstPolynomial / devider;
        }
        
        public static Polynomial Add(Polynomial polynom1, Polynomial polynom2) => polynom1 + polynom2;

        public static Polynomial Subtract(Polynomial polynom1, Polynomial polynom2) => polynom1 - polynom2;

        public static Polynomial Multiply(Polynomial polynom1, Polynomial polynom2) => polynom1 * polynom2;

        public static Polynomial Multiply(int multiplier, Polynomial polynom1) => multiplier*polynom1;

        public static Polynomial Multiply(Polynomial polynom1, int multiplier) => polynom1*multiplier;

        public static Polynomial Division(Polynomial polynom1, int divider) => polynom1 / divider;

        public static Polynomial Division(int divider, Polynomial polynom1) => polynom1 / divider;

        /// <summary>
        /// Overloading of == operator
        /// </summary>
        /// <param name="firstPolynomial">First polynom</param>
        /// <param name="secondPolynomial">Second polynom</param>
        /// <returns>Equality test result</returns>
        public static bool operator ==(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            return firstPolynomial.Equals(secondPolynomial);
        }

        /// <summary>
        /// Overloading of != operator
        /// </summary>
        /// <param name="firstPolynomial">First polynom</param>
        /// <param name="secondPolynomial">Second polynom</param>
        /// <returns>inequality check result</returns>
        public static bool operator !=(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            return !(firstPolynomial == secondPolynomial);
        }

        /// <summary>
        /// Overriding of ToString method
        /// </summary>
        /// <returns>Polynomial in string representation</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < coefficients.Length; i++)
            {
                if (this[i] != 0 && this[i] != 0.0)
                {
                    if (stringBuilder.Length == 0)
                    {
                        stringBuilder.Append($"{this[i]}*x^{i}");
                    }
                    else
                    {
                        stringBuilder.Append($" + {this[i]}*x^{i}");
                    }
                }
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Overriding of GetHashCode method
        /// </summary>
        /// <returns>Hash code of polynom</returns>
        public override int GetHashCode()
        {
            int hash = 0;
            for (int i=0;i<Length;i++)
            {
                hash += this[i].GetHashCode() + i;
            }
            return hash;
        }

        /// <summary>
        /// Overriding of Equals method
        /// </summary>
        /// <param name="obj">Compared obj</param>
        /// <returns>True if equals</returns>
        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                return false;
            }
            Polynomial tempPolynom = obj as Polynomial;

            return Equals(tempPolynom);
        }

        public bool Equals(Polynomial polynom)
        {
            if (ReferenceEquals(polynom,null))
            {
                return false;
            }

            for (int i = 0; i < Length; i++)
            {
                if (Math.Abs(this[i] - polynom[i]) > accuracy)
                    return false;
            }
            return true;
        }

        public object Clone()
        {
            return new Polynomial(this.coefficients);
        }


        private void TestingArray(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (double.IsNaN(array[i]) || double.IsInfinity(array[i]))
                {
                    throw new ArgumentOutOfRangeException("Array's elements shouldn't be NaN or Infinity");
                }
            }
        }

        private static double[] InvertingArray(double[] array)
        {
            double[] resultArray = new double[array.Length];
            for (int i=0;i<array.Length;i++)
            {
                resultArray[i] = -array[i];
            }
            return resultArray;
        }

    }
}
