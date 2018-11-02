using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DoubleToString
{
    public class DoubleToStringConverter
    {
        public delegate string DoubleToStringTransformer(double value);
        /// <summary>
        /// Convert double to binary string according to IEEE 754
        /// </summary>
        /// <param name="value">Input double number</param>
        /// <returns>Binary string</returns>
        public static string ConvertingDoubleToString(double value)
        {
            const int bitInByte = 8;

            DoubleToLongStruct doubleToLong = new DoubleToLongStruct();
            doubleToLong.doubleValue = value;
            long longValue = doubleToLong.longValue;

            int iterations = bitInByte * sizeof(double);

            char[] doubleBits = new char[iterations];
            
            for (int i=iterations-1;i>=0;i--)
            {
                doubleBits[i] = (longValue & 1) == 1 ? '1' : '0';
                longValue >>= 1;
            }

            return new string(doubleBits);
        }

        /// <summary>
        /// Convert double to binary string according to IEEE 754
        /// </summary>
        /// <param name="value1">Input double number</param>
        /// <param name="value2">Input double number</param>
        /// <returns>Array of binary strings</returns>
        public static string[] ConvertingDoubleToString(params double[] values)
        {
            string[] result = new string[values.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = ConvertingDoubleToString(values[i]);
            }
            return result;
        }

        public static string[] ConvertingDoubleToString( DoubleToStringTransformer transformer, 
            params double[] values)
        {
            string[] result = new string[values.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = transformer(values[i]);
            }
            return result;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLongStruct
        {
            [FieldOffset(0)]
            public double doubleValue;

            [FieldOffset(0)]
            public long longValue;
        }
    }
}
