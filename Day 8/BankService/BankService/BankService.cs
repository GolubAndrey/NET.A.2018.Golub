using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankService
{
    public class BankService
    {
        public static int maxDebtUSD = 10000;
        /// <summary>
        /// Table with currency transfer
        /// </summary>
        public static double[,] currencyTransferTable;

        /// <summary>
        /// Scorecards table
        /// </summary>
        public static double[,] cashTypeBonusCoefficients;
        private List<Account> accounts { get; set; }
        private List<Cash> cashs { get; set; }

        /// <summary>
        /// Constructor for bank service
        /// </summary>
        public BankService()
        {
            accounts = new List<Account>();
            cashs = new List<Cash>();
        }

        private Account CreateAccount(int accountId,string name,string surname)
        {
            Account account = new Account(accountId, name, surname);
            accounts.Add(account);
            return account;
        }

        /// <summary>
        /// Account closing
        /// </summary>
        /// <param name="accountId">Account ID</param>
        /// <param name="name">Name</param>
        /// <param name="surname">Surname</param>
        private void ClouseAccount(int accountId, string name, string surname)
        {
            accounts.Remove(FindAccount(accountId, name, surname));
        }

        /// <summary>
        /// Cash creating
        /// </summary>
        /// <param name="accountId">Account ID</param>
        /// <param name="name">Name</param>
        /// <param name="surname">Surname</param>
        /// <param name="currency">Currency</param>
        /// <param name="cashId">Cash ID</param>
        /// <param name="cashType">Cash type</param>
        public void CreateCash(int accountId,string name,string surname, Currency currency,int cashId,CashType cashType)
        {
            foreach(Account account in accounts)
            {
                if (account.ID == accountId && account.Name == name && account.Surname == surname)
                {
                    cashs.Add(account.CreateCash(cashId, currency, cashType));
                    return;
                }
            }
            cashs.Add(CreateAccount(accountId, name, surname).CreateCash(cashId, currency, cashType));
        }

        /// <summary>
        /// Cash closing
        /// </summary>
        /// <param name="accountId">Account ID</param>
        /// <param name="name">Name</param>
        /// <param name="surname">Surname</param>
        /// <param name="cashId">Cash ID</param>
        public void CloseCash(int accountId,string name,string surname,int cashId)
        {
            Tuple<Cash, int> turple = FindAccount(accountId, name, surname).CloseCash(cashId);
            if (turple.Item2==0)
            {
                ClouseAccount(accountId, name, surname);
            }
            cashs.Remove(turple.Item1);
        }

        /// <summary>
        /// Watch cash amount
        /// </summary>
        /// <param name="accountId">Account ID</param>
        /// <param name="name">Name</param>
        /// <param name="surname">Surname</param>
        /// <param name="cashId">Cash ID</param>
        /// <returns>String with amount and currency</returns>
        public string WatchCashAmount(int accountId, string name, string surname, int cashId)
        {
            return FindAccount(accountId, name, surname).WatchCashAmount(cashId);
        }

        /// <summary>
        /// Cash replenishment
        /// </summary>
        /// <param name="accountId">Account ID</param>
        /// <param name="name">Name</param>
        /// <param name="surname">Surname</param>
        /// <param name="cashId">Cash ID</param>
        /// <param name="value">Amount</param>
        public void ReplenishCash(int accountId, string name, string surname, int cashId, int value)
        {
            FindAccount(accountId, name, surname).ReplenishCash(cashId, value);
        }

        /// <summary>
        /// Money withdrawing from cash
        /// </summary>
        /// <param name="accountId">Account ID</param>
        /// <param name="name">Name</param>
        /// <param name="surname">Surname</param>
        /// <param name="cashId">Cash ID</param>
        /// <param name="value">Amount</param>
        /// <returns></returns>
        public int WithdrawMoneyFromCash(int accountId, string name, string surname, int cashId,int value)
        {
            return FindAccount(accountId, name, surname).WithdrawMoneyFromCash(cashId, value);
        }

        /// <summary>
        /// Cash currency changing
        /// </summary>
        /// <param name="accountId">Account ID</param>
        /// <param name="name">Name</param>
        /// <param name="surname">Surname</param>
        /// <param name="cashId">Cash ID</param>
        /// <param name="currency">New currency</param>
        public void ChangeCashCurrency(int accountId, string name, string surname, int cashId,Currency currency)
        {
            FindAccount(accountId, name, surname).ChangeCashCurrency(cashId, currency);
        }

        /// <summary>
        /// Cash type changing
        /// </summary>
        /// <param name="accountId">Account ID</param>
        /// <param name="name">Name</param>
        /// <param name="surname">Surname</param>
        /// <param name="cashId">Cash ID</param>
        /// <param name="cashType">New Cash type</param>
        public void ChangeCashType(int accountId, string name, string surname, int cashId, CashType cashType)
        {
            FindAccount(accountId, name, surname).ChangeCashType(cashId, cashType);
        }

        /// <summary>
        /// See bonuses
        /// </summary>
        /// <param name="accountId">Account ID</param>
        /// <param name="name">Name</param>
        /// <param name="surname">Surname</param>
        /// <returns></returns>
        public int SeeBonuses(int accountId, string name, string surname)
        {
            return FindAccount(accountId, name, surname).SeeBonuses();
        }

        /// <summary>
        /// Bonuses withdrawing
        /// </summary>
        /// <param name="accountId">Account ID</param>
        /// <param name="name">Name</param>
        /// <param name="surname">Surname</param>
        /// <param name="value">Amount</param>
        /// <returns></returns>
        public int WithdrawBonuses(int accountId, string name, string surname,int value)
        {
            return FindAccount(accountId, name, surname).WithdrawBonuses(value);
        }

        private Account FindAccount(int accountId, string name, string surname)
        {
            foreach (Account account in accounts)
            {
                if (account.ID == accountId && account.Name == name && account.Surname == surname)
                {
                    return account;
                }
            }
            throw new ArgumentException("No account with such data");
        }
    }
}
