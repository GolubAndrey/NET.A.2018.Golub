using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService
{
    public class CashCreator
    {
        public Cash CreateCash(int id,Currency currency, CashType cashType)
        {
            string fullName = $"{GetType().Namespace}.{cashType.ToString()}";
            return (Cash)Activator.CreateInstance(Type.GetType(fullName), id, currency, cashType);
        }
    }
}
