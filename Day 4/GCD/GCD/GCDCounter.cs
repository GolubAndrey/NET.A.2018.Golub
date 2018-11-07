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
        public static int GCDEuclideCalculate(out long time,params int[] numbers)
        {
            if (!IsNormalArray(numbers))
            {
                throw new ArgumentException();
            }
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            timer.Start();
            int temp = GCDFind(GCDEuclide, numbers);
            timer.Stop();
            time = timer.ElapsedMilliseconds;
            return temp;
        }

        /// <summary>
        /// Calculate GCD using Euclide's algoritm
        /// </summary>
        /// <param name="time">Method execution time as output parameter</param>
        /// <param name="number1">Input number 1</param>
        /// <param name="number2">Input number 2</param>
        /// <returns>GCD of input numbers</returns>
        public static int GCDEuclideCalculate(out long time,int number1,int number2)
        {
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            timer.Start();
            int result=GCDEuclide(number1, number2);
            timer.Stop();
            time = timer.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// Calculate GCD using Euclide's algoritm
        /// </summary>
        /// <param name="time">Method execution time as output parameter</param>
        /// <param name="number1">Input number 1</param>
        /// <param name="number2">Input number 2</param>
        /// <param name="number3">Input number 3</param>
        /// <returns>GCD of input numbers</returns>
        public static int GCDCEuclideCalculate(out long time, int number1, int number2,int number3)
        {
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            timer.Start();
            int result = GCDFind(GCDEuclide, number1, number2, number3);
            timer.Stop();
            time = timer.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// Calculate GCD using Stain's algoritm
        /// </summary>
        /// <param name="time">Method execution time as output parameter</param>
        /// <param name="numbers">Input number array</param>
        /// <returns>GCD of input numbers</returns>
        public static int GCDStainCalculate(out long time, params int[] numbers)
        {
            if (!IsNormalArray(numbers))
            {
                throw new ArgumentException();
            }
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            timer.Start();
            int temp = GCDFind(GCDStain, numbers);
            timer.Stop();
            time = timer.ElapsedMilliseconds;
            return temp;
        }

        /// <summary>
        /// Calculate GCD using Stain's algoritm
        /// </summary>
        /// <param name="time">Method execution time as output parameter</param>
        /// <param name="number1">Input number 1</param>
        /// <param name="number2">Input number 2</param>
        /// <returns>GCD of input numbers</returns>
        public static int GCDStainCalculate(out long time, int number1, int number2)
        {
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            timer.Start();
            int result = GCDStain(number1, number2);
            timer.Stop();
            time = timer.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// Calculate GCD using Stain's algoritm
        /// </summary>
        /// <param name="time">Method execution time as output parameter</param>
        /// <param name="number1">Input number 1</param>
        /// <param name="number2">Input number 2</param>
        /// <param name="number3">Input number 3</param>
        /// <returns>GCD of input numbers</returns>
        public static int GCDCStainCalculate(out long time, int number1, int number2, int number3)
        {
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            timer.Start();
            int result = GCDFind(GCDStain, number1, number2, number3);
            timer.Stop();
            time = timer.ElapsedMilliseconds;
            return result;
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

        private static int GCDFind(Func<int, int, int> function, int number1, int number2, int number3)
            => function(function(number1, number2), number3);

        private static int GCDFind(Func<int,int,int> function,params int[] array)
        {
            int result = array[0];
            for (int i=1;i<array.Length;i++)
            {
                result = function(result, array[i]);
            }
            return result;
        }
    }
}
