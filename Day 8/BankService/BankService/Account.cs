using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService
{
    public class Account
    {
        /// <summary>
        /// Account name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Account surname
        /// </summary>
        public string Surname { get; }

        /// <summary>
        /// Account ID
        /// </summary>
        public int ID { get; }

        private int bonuse;

        private List<Cash> Cashs;
        private CashCreator cashCreator;



        /// <summary>
        /// Account constructor
        /// </summary>
        /// <param name="accountId">Account ID</param>
        /// <param name="name">Name</param>
        /// <param name="surname">Surname</param>
        public Account(int accountId,string name,string surname)
        {
            ID = accountId;
            Name = name;
            Surname = surname;
            Cashs = new List<Cash>();
            cashCreator = new CashCreator();
        }

        /// <summary>
        /// Cash creating
        /// </summary>
        /// <param name="cashId">Cash ID</param>
        /// <param name="currency">Currency</param>
        /// <param name="cashType">Cash type</param>
        /// <exception cref="ArgumentException">When cash with this id was created</exception>
        public Cash CreateCash(int cashId,Currency currency,CashType cashType)
        {
            foreach(Cash cash in Cashs)
            {
                if (cash.ID==cashId)
                {
                    throw new ArgumentException("Cash with this ID was created");
                }
            }
            Cash tempCash = cashCreator.CreateCash(cashId, currency, cashType);
            Cashs.Add(tempCash);
            return tempCash;
        }

        /// <summary>
        /// Cash closing
        /// </summary>
        /// <param name="cashId">Cash ID</param>
        public Tuple<Cash,int> CloseCash(int cashId)
        {
            Cash cash = FindCash(cashId);
            Cashs.Remove(cash);
            return Tuple.Create(cash,Cashs.Count);
        }

        /// <summary>
        /// Cash replelenishment
        /// </summary>
        /// <param name="cashId">Cash ID</param>
        /// <param name="value">Amount</param>
        public void ReplenishCash(int cashId, int value)
        {
            bonuse += FindCash(cashId).ReplenishCash(value);
        }

        /// <summary>
        /// Withdrawing money from cash
        /// </summary>
        /// <param name="cashId">Cash ID</param>
        /// <param name="value">Amount</param>
        /// <returns></returns>
        public int WithdrawMoneyFromCash(int cashId,int value)
        {
            return FindCash(cashId).Withdraw(value);
        }


        /// <summary>
        /// Cash currency changing
        /// </summary>
        /// <param name="cashId">Cash ID</param>
        /// <param name="currency">Currency type</param>
        public void ChangeCashCurrency(int cashId,Currency currency)
        {
            FindCash(cashId).ChangeCurrency(currency);
        }

        /// <summary>
        /// Cash type changing
        /// </summary>
        /// <param name="cashId">Cash ID</param>
        /// <param name="cashType">Cash type</param>
        public void ChangeCashType(int cashId,CashType cashType)
        {
            CashCreator cashCreator = new CashCreator();
            Cash cash = FindCash(cashId);
            int money = cash.Amount;
            cash = cashCreator.CreateCash(cash.ID, cash.Currency, cashType);
            cash.Amount = money;
        }

        /// <summary>
        /// See accaunt bonuses
        /// </summary>
        /// <returns>Bonuses in USD</returns>
        public int SeeBonuses()
        {
            return bonuse;
        }

        /// <summary>
        /// Withdrawing bonuses
        /// </summary>
        /// <param name="value">Amount</param>
        /// <returns>Bonuses in USD</returns>
        /// <exception cref="ArgumentException">When value>bonuses</exception>
        public int WithdrawBonuses(int value)
        {
            if (bonuse-value<0)
            {
                throw new ArgumentException("No so many bonuses");
            }
            bonuse -= value;
            return value;
        }

        /// <summary>
        /// Watch cash amount
        /// </summary>
        /// <param name="cashId">Cash ID</param>
        /// <returns>String with amount and currency</returns>
        public string WatchCashAmount(int cashId)
        {
            return FindCash(cashId).WatchAmount();
        }

        private Cash FindCash(int cashId)
        {
            foreach (Cash cash in Cashs)
            {
                if (cash.ID == cashId)
                {
                    return cash;
                }
            }
            throw new ArgumentException("No cash with this ID");
        }
    }
}
