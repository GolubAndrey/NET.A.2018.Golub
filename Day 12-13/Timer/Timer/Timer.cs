using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Timer
{
    public class Timer:IObservable
    {
        List<IObserver> observers;

        Thread timerThread;

        public int Time { get; private set; }
        
        
        public event Action<Timer, MailInfo> NewMail;

        public Timer()
        {
            observers = new List<IObserver>();
            timerThread = new Thread(new ThreadStart(TimerCounter));
        }

        public void StartTimer(int time)
        {
            Time = time;
            timerThread.Start();
        }

        public void Register(IObserver observer)
        {
            if (ReferenceEquals(observer,null))
            {
                throw new ArgumentNullException($"{nameof(observer)} can't be null");
            }
            observers.Add(observer);
            NewMail += observer.Update;
        }

        public void Unregister(IObserver observer)
        {
            if (ReferenceEquals(observer, null))
            {
                throw new ArgumentNullException($"{nameof(observer)} can't be null");
            }
            observers.Remove(observer);
            NewMail -= observer.Update;
        }

        private void TimerCounter()
        {
            Thread.Sleep(Time);
            MailInfo mailInfo = new MailInfo()
            {
                From = "Timer",
                To = "User",
                Message = "Timer finished work"
            };
            NewMail?.Invoke(this, mailInfo);
            timerThread.Abort();
        }

        public void Notify(MailInfo info)
        {
            foreach(IObserver observer in observers)
            {
                observer.Update(this, info);
            }
        }
    }
}
