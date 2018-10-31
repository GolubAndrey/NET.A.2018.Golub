using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService
{
    public class Cash
    {
        private double AmountBonusCoefficient { get; set; }

        private double ReplenishmentBonusCoefficient { get; set; }

        private CashType CashType { get; set; }
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
            CashType = cashType;
            AmountBonusCoefficient = BankService.cashTypeBonusCoefficients[0,(int)CashType];
            ReplenishmentBonusCoefficient = BankService.cashTypeBonusCoefficients[1, (int)CashType];
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
            if (Amount-value<0)
            {
                throw new ArgumentException("No so much money in the cash");
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
                Amount = BankService.CurrencyConverter(Currency, currency, Amount);
                Currency = currency;
            }
        }

        /// <summary>
        /// Change cash type
        /// </summary>
        /// <param name="cashType">New cash type</param>
        public void ChangeCashType(CashType cashType)
        {
            if (CashType!=cashType)
            {
                CashType = cashType;
                AmountBonusCoefficient = BankService.cashTypeBonusCoefficients[0, (int)CashType];
                ReplenishmentBonusCoefficient = BankService.cashTypeBonusCoefficients[1, (int)CashType];
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
