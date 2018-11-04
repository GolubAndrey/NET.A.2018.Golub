using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNextBiggerNumber
{
    public static class FinderNextBiggerNumber
    {
        /// <summary>
        /// Looking for the smallest number more than the specified consisting of the same digits
        /// </summary>
        /// <param name="number">Input number</param>
        /// <returns>the smallest number more than the specified consisting of the same digits</returns>
        public static int FindNextBiggerNumber(int number)
        {
            if (number<=0)
            {
                throw new ArgumentOutOfRangeException("Number should be more than 0");
            }

            int[] numberArray = StringToIntArray(number.ToString());
            
            if (IsSortedArray(numberArray))
            {
                return -1;
            }


            int index = IndexOfFirstUnsortedElementFromTheEnd(numberArray);
            if (index == -1)
            {
                return -1;
            }

            int tempIndex = IndexOfTheSmallestDigitGreaterThan(index,numberArray);
            int temp = numberArray[tempIndex];

            SwapingElementWithShifting(numberArray, index, tempIndex);
            Array.Sort(numberArray, index, numberArray.Length - index);


            return IntArrayToInt(numberArray);
        }

        private static void SwapingElementWithShifting(int[] array,int index1,int index2)
        {
            int temp = array[index2];
            for (int k = index2 - 1; k >= index1 - 1; k--)
            {
                array[k + 1] = array[k];
            }
            array[index1 - 1] = temp;
        }
        private static int[] StringToIntArray(string stringNumber)
        {
            const int biasFromCharToInt = 48;
            int[] intArray = new int[stringNumber.Length];
            for(int i=0;i<intArray.Length;i++)
            {
                intArray[i]=Convert.ToInt32(stringNumber[i]-biasFromCharToInt);
            }

            return intArray;
        }

        private static bool IsSortedArray(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] < array[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        private static int IntArrayToInt(int[] array)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (int i in array)
            {
                stringBuilder.Append(i);
            }

            return int.Parse(stringBuilder.ToString());
        }

        private static int IndexOfFirstUnsortedElementFromTheEnd(int[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                if (array[i] > array[i - 1])
                {
                    return i;
                }
            }
            return -1;
        }

        private static int IndexOfTheSmallestDigitGreaterThan(int index,int[] array)
        {
            int tempIndex = 0;
            int temp = 10;
            for (int j = index; j < array.Length; j++)
            {
                if (array[j] > array[index - 1] && array[j] < temp)
                {
                    temp = array[j];
                    tempIndex = j;
                }
            }
            return tempIndex;
        }
    }
}
