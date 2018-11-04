using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCD
{
    public static class GCDCounter
    {
        private delegate int GCDCalculatorFor2Params(out long time, int number1, int number2);
        private delegate int GCDCalculatorFor3Params(out long time, int number1, int number2, int number3);
        private delegate int GCDCalculatorForNParams(out long time, params int[] numbers);

        public delegate int GCDCalculators(int a, int b);
        /// <summary>
        /// Calculate GCD
        /// </summary>
        /// <param name="calculator">Delegate with method of counting GCD</param>
        /// <param name="time">Method execution time as output parameter</param>
        /// <param name="numbers">Input number array</param>
        /// <returns>GCD of input numbers</returns>
        public static int GCDCalculate(GCDCalculators calculator,out long time,params int[] numbers)
        {
            if (!IsNormalArray(numbers))
            {
                throw new ArgumentException();
            }
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            timer.Start();

            int temp = calculator(numbers[0], numbers[1]);
            for (int i=2;i<numbers.Length && temp!=1;i++)
            {
                temp = calculator(temp, numbers[i]);
            }
            timer.Stop();
            time = timer.ElapsedMilliseconds;
            return temp;
        }

        /// <summary>
        /// Calculate GCD using delegate with calculating method
        /// </summary>
        /// <param name="calculator">Delegate with method of counting GCD</param>
        /// <param name="time">Method execution time as output parameter</param>
        /// <param name="number1">Input number 1</param>
        /// <param name="number2">Input number 2</param>
        /// <returns>GCD of input numbers</returns>
        public static int GCDCalculate(GCDCalculators calculator,out long time,int number1,int number2)
        {
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            timer.Start();
            int result=calculator(number1, number2);
            timer.Stop();
            time = timer.ElapsedMilliseconds;
            return result;
        }

        /// <summary>
        /// Calculate GCD using delegate with calculating method
        /// </summary>
        /// <param name="calculator">Delegate with method of counting GCD</param>
        /// <param name="time">Method execution time as output parameter</param>
        /// <param name="number1">Input number 1</param>
        /// <param name="number2">Input number 2</param>
        /// <param name="number3">Input number 3</param>
        /// <returns>GCD of input numbers</returns>
        public static int GCDCalculate(GCDCalculators calculator, out long time, int number1, int number2,int number3)
        {
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            timer.Start();
            int result = calculator(calculator(number1, number2),number3);
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

        public static int GCDEuclide(int a,int b)
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

        public static int GCDStain(int a, int b)
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
