using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberTransformToWords
{
    public static class NumberToWordsTransformer
    {
        private static string[] words = new string[10] { "zero", "one", "two", "three", "fouth", "five", "six", "seven", "eight", "nine" };

        /// <summary>
        /// Transform double array into a string array of words
        /// </summary>
        /// <param name="numberArray">Input double array</param>
        /// <returns>String array of words</returns>
        public static string[] TransformToWords(double[] numberArray)
        {
            if (numberArray==null)
            {
                throw new ArgumentNullException();
            }
            if (numberArray.Length==0)
            {
                throw new ArgumentException();
            }

            string[] resultArray = new string[numberArray.Length];

            for (int i=0;i<numberArray.Length;i++)
            {
                resultArray[i] = DoubleToWords(numberArray[i]);
            }

            return resultArray;

        }

        private static string DoubleToWords(double number)
        {
            string stringNumber = number.ToString();
            char[] numberArray = stringNumber.ToArray();
            string[] resultArray = new string[numberArray.Length];

            for (int i=0;i<numberArray.Length;i++)
            {
                if (numberArray[i]==',' || numberArray[i] == '.')
                {
                    resultArray[i] = String.Copy("point");
                    continue;
                }
                if (numberArray[i] == '-')
                {
                    resultArray[i] = string.Copy("minus");
                    continue;
                }
                resultArray[i]=String.Copy(words[Convert.ToInt32(numberArray[i] - 48)]);
            }
            string result=String.Join(" ", resultArray);
            

            return result;
        }

    }
}
