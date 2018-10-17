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
                throw new ArgumentOutOfRangeException();
            }
            
            int[] numberArray = new int[number.ToString().Length];
            for (int i = 0; i < numberArray.Length; i++)
            {
                numberArray[i] = int.Parse(number.ToString()[i].ToString());
            }

            
            bool flag = false;
            for (int i=0;i< numberArray.Length-1;i++)
            {
                if (numberArray[i] < numberArray[i + 1])
                    flag = true;
            }
            if (!flag)
            {
                return -1;
            }



            flag = false;
            for (int i = numberArray.Length-1; i > 0; i--)
            {
                if (numberArray[i] > numberArray[i - 1])
                {
                    int index = 0;
                    int temp = 10;
                    for (int j = i; j < numberArray.Length; j++)
                    {
                        if (numberArray[j] > numberArray[i-1] && numberArray[j] < temp)
                        {
                            temp = numberArray[j];
                            index = j;
                        }
                    }
                    for (int k = index - 1; k >= i - 1; k--)
                    {
                        numberArray[k + 1] = numberArray[k];
                    }
                    numberArray[i - 1] = temp;
                    Array.Sort(numberArray, i, numberArray.Length - i);
                    break;
                }
            }
            StringBuilder stringBuilder = new StringBuilder();
            foreach (int i in numberArray)
            {
                stringBuilder.Append(i);
            }

            return int.Parse(stringBuilder.ToString());
        }
    }
}
