using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
    public class Subscriber2 : IObserver
    {
        public void StartMail(IObservable mailManager)
        {
            mailManager.Register(this);
        }
        public void StopMail(IObservable mailManager)
        {
            mailManager.Unregister(this);
        }

        public void Update(object sender, MailInfo mailInfo)
        {
            Console.WriteLine("Paging mail message:");
            Console.WriteLine($"From = {mailInfo.From}, To = {mailInfo.To}, Subject = {mailInfo.Message}");
        }
    }
}
