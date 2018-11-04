using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService
{
    public class SilverCash:Cash
    {
        public SilverCash(int id, Currency currency, CashType cashType) : base(id, currency, cashType)
        {
            ReplenishmentBonusCoefficient = 0.004;
            AmountBonusCoefficient = 0.002;
        }
    }
}
