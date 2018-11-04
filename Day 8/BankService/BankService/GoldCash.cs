using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService
{
    public class GoldCash:Cash
    {
        public GoldCash(int id, Currency currency, CashType cashType) : base(id, currency, cashType)
        {
            ReplenishmentBonusCoefficient = 0.005;
            AmountBonusCoefficient = 0.003;
        }
    }
}
