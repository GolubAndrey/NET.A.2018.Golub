using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService
{
    public class BaseCash:Cash
    {
        public BaseCash(int id, Currency currency, CashType cashType) : base(id, currency, cashType)
        {
            ReplenishmentBonusCoefficient = 0;
            AmountBonusCoefficient = 0;
        }
    }
}
