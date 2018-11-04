using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService
{
    public abstract class Cash
    {
        public Account account { get; set; }
        protected double AmountBonusCoefficient { get; set; }

        protected double ReplenishmentBonusCoefficient { get; set; }
        
        public Currency Currency { get; set; }

        /// <summary>
        /// Cash ID
        /// </summary>
        public int ID { get; }

        /// <summary>
        /// Cash amount
        /// </summary>
        public int Amount { get; set; }
        
        /// <summary>
        /// Cash constructor with field initializations
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currency"></param>
        /// <param name="cashType"></param>
        public Cash(int id,Currency currency,CashType cashType)
        {
            ID = id;
            Currency = currency;
            Amount = 0;
        }

        /// <summary>
        /// Cash replenishment
        /// </summary>
        /// <param name="value">Amount</param>
        /// <returns>Reloaded bonuses</returns>
        public int ReplenishCash(int value)
        {
            int accuralBonus = (int)(Amount * AmountBonusCoefficient);
            accuralBonus += (int)(value * ReplenishmentBonusCoefficient);
            Amount += value;
            return accuralBonus;
        }

        /// <summary>
        /// Withdrawing from cash
        /// </summary>
        /// <param name="value">Amount</param>
        /// <returns>Amount withdraw</returns>
        /// <exception cref="ArgumentException">When value more than cash amount</exception>
        public int Withdraw(int value)
        {
            if (Amount-value<-BankService.maxDebtUSD)
            {
                throw new ArgumentException("Maximum debt exceeded");
            }
            Amount -= value;
            return value;
        }

        /// <summary>
        /// Change cash currency
        /// </summary>
        /// <param name="currency">New currency</param>
        public void ChangeCurrency(Currency currency)
        {
            if (Currency != currency)
            {
                Currency = currency;
            }
        }

        /// <summary>
        /// Watching amount
        /// </summary>
        /// <returns>String with amount and currency</returns>
        public string WatchAmount()
        {
            return $"{Amount.ToString()} {Currency.ToString()}";
        }
        
    }
}
