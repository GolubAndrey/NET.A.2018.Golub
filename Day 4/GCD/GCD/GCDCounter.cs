using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    public static class GCDCounter
    {
        /// <summary>
        /// Calculate GCD using Euclide's algoritm
        /// </summary>
        /// <param name="time">Method execution time as output parameter</param>
        /// <param name="numbers">Input number array</param>
        /// <returns>GCD of input numbers</returns>
        public static int EuclideCalculate(out long time,params int[] numbers)
        {
            if (!IsNormalArray(numbers))
            {
                throw new ArgumentException();
            }
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            timer.Start();

            int temp = GCDEuclide(numbers[0], numbers[1]);
            for (int i=2;i<numbers.Length && temp!=1;i++)
            {
                temp = GCDEuclide(temp, numbers[i]);
            }
            timer.Stop();
            time = timer.ElapsedMilliseconds;
            return temp;
        }

        /// <summary>
        /// Calculate GCD using Stain's algoritm
        /// </summary>
        /// <param name="time">Method execution time as output parameter</param>
        /// <param name="numbers">Input number array</param>
        /// <returns>GCD of input numbers</returns>
        public static int StainCalculate(out long time, params int[] numbers)
        {
            if (!IsNormalArray(numbers))
            {
                throw new ArgumentException();
            }
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            timer.Start();

            int temp = GCDStain(numbers[0], numbers[1]);
            for (int i = 2; i < numbers.Length && temp != 1; i++)
            {
                temp = GCDStain(temp, numbers[i]);
            }
            timer.Stop();
            time = timer.ElapsedMilliseconds;
            return temp;
        }

        private static bool IsNormalArray(int[] array)
        {
            if (array.Length<2)
            {
                return false;
            }

            for (int i=0;i<array.Length;i++)
            {
                if (array[i]<0)
                {
                    return false;
                }
            }

            return true;
        }

        private static int GCDEuclide(int a,int b)
        {
            while (a!=0 && b!=0)
            {
                if (a>b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }
            return a + b;
        }

        private static int GCDStain(int a, int b)
        {
            int shift;
            
            if (a == 0 || b == 0)
                return a | b;
            
            for (shift = 0; ((a | b) & 1) == 0; ++shift)
            {
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
                a >>= 1;

            while (b != 0)
            {
                while ((b & 1) == 0)
                    b >>= 1;
                
                if (a < b)
                {
                    b -= a;
                }
                else
                {
                    int difference = a - b;
                    a = b;
                    b = difference;
                }
                b >>= 1;
            }

            return a << shift;
        }
    }
}
