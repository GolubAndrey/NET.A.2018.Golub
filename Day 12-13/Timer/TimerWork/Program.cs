using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer;

namespace TimerWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer.Timer timer = new Timer.Timer();

            Subscriber1 subscriber1 = new Subscriber1();
            subscriber1.StartMail(timer);

            Subscriber2 subscriber2 = new Subscriber2();
            subscriber2.StartMail(timer);

            timer.StartTimer(5000);

            Console.ReadLine();
        }
    }
}
