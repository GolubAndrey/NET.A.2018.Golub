using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleToString
{
    public class DoubleToStringConverter
    {

        private const int maxExponentOffset = 1023;
        private const int mantissaLength = 52;
        private const int exponentLength = 11;


        /// <summary>
        /// Convert double to binary string according to IEEE 754
        /// </summary>
        /// <param name="value">Input double number</param>
        /// <returns>Binary string</returns>
        public static string ConvertingDoubleToString(double value)
        {
            return ConvertDoubleToString(value);
        }

        /// <summary>
        /// Convert double to binary string according to IEEE 754
        /// </summary>
        /// <param name="value1">Input double number</param>
        /// <param name="value2">Input double number</param>
        /// <returns>Array of binary strings</returns>
        public static string[] ConvertingDoubleToString(double value1,double value2)
        {
            string[] result = new string[2];
            result[0]=ConvertDoubleToString(value1);
            result[1] = ConvertDoubleToString(value2);
            return result;
        }

        /// <summary>
        /// Convert double to binary string according to IEEE 754
        /// </summary>
        /// <param name="value1">Input double number</param>
        /// <param name="value2">Input double number</param>
        /// <param name="value3">Input double number</param>
        /// <returns>Array of binary strings</returns>
        public static string[] ConvertingDoubleToString(double value1, double value2,double value3)
        {
            string[] result = new string[3];
            result[0] = ConvertDoubleToString(value1);
            result[1] = ConvertDoubleToString(value2);
            result[2] = ConvertDoubleToString(value3);
            return result;
        }

        /// <summary>
        /// Convert double to binary string according to IEEE 754
        /// </summary>
        /// <param name="values">Array of double numbers</param>
        /// <returns>Array of binary strings</returns>
        public static string[] ConvertingDoubleToString(params double[] values)
        {
            string[] result = new string[values.Length];
            for (int i=0;i<result.Length;i++)
            {
                result[i] = ConvertDoubleToString(values[i]);
            }
            return result;
        }
        /// <summary>
        /// Convert double to binary string according to IEEE 754
        /// </summary>
        /// <param name="value">Input double number</param>
        /// <returns>Binary string</returns>
        private static string ConvertDoubleToString(double value)
        {
            string sign = GetSigh(value);

            value = Math.Abs(value);

            int offset = GetOffset(ref value);

            string binaryIntegerPart = ConvertDecimalToString(offset);

            string binaryFractionPart = ConvertFractionToString(value - 1).Substring(0, mantissaLength);

            return $"{sign}{binaryIntegerPart}{binaryFractionPart}";
        }
        


        private static string GetSigh(double value)
        {
            return value < 0 || double.IsNaN(value) || double.IsNegativeInfinity(1/value)? "1" : "0";
        }

        private static int GetOffset(ref double value)
        {
            if (double.IsInfinity(value) || double.IsNaN(value))
            {
                return (int)Math.Pow(2, 11) - 1;
            }

            if (value == 0.0)
            {
                return 0;
            }
            int offset = 0;

            if (value < 1.0)
            {
                while (value < 1.0)
                {
                    value *= 2;
                    offset--;
                }
            }
            else
            {
                while (value > 2.0)
                {
                    value /= 2;
                    offset++;
                }
            }

            offset += maxExponentOffset;
            return offset < 0 ? 0 : offset;
        }

        private static string ConvertDecimalToString(long value)
        {

            StringBuilder result = new StringBuilder();
            if (value == 0)
            {
                result.Insert(0, "0", 11);
                return result.ToString();
            }
            else
            {
                for (int i = 0; value != 0; i++)
                {
                    result.Insert(0, value % 2);
                    value /= 2;
                }
            }

            return result.ToString().TrimStart('0');
        }

        private static string ConvertFractionToString(double value)
        {
            if (double.IsNaN(value))
            {
                value = 0.5;
            }

            if (value == 0)
            {
                value = Math.Pow(2, -mantissaLength);
            }

            if (double.IsInfinity(value))
            {
                value = 0;
            }


            StringBuilder result = new StringBuilder();
            int integerOverflow = 0;
            for (int i = 0; i < mantissaLength + exponentLength; i++)
            {
                value *= 2;
                integerOverflow = (int)value % 2;
                value -= integerOverflow;
                result.Insert(result.Length, integerOverflow);
            }

            return result.ToString();
        }
    }
}
