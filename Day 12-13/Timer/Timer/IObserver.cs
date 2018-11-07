using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
    public interface IObserver
    {
        void Update(object sender, MailInfo info);
    }
}
