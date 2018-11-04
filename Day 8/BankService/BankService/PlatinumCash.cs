using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService
{
    public class PlatinumCash:Cash
    {
        public PlatinumCash(int id, Currency currency, CashType cashType) : base(id, currency, cashType)
        {
            ReplenishmentBonusCoefficient = 0.006;
            AmountBonusCoefficient = 0.004;
        }
    }
}
