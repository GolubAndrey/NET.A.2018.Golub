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
        private const int currencyNumber = 4;
        private const int cashTypeNumber = 4;
        private const int bonusCoefficientsNumber = 2;
        private string currencyTransferWay = @"E:\EPAM\NET.A.2018.Golub\Day 8\BankService\BankService\CurrencyTransfers.txt";
        private string cashTypeCoefficientsWay = @"E:\EPAM\NET.A.2018.Golub\Day 8\BankService\BankService\CashTypeCoefficients.txt";

        /// <summary>
        /// Table with currency transfer
        /// </summary>
        public static double[,] currencyTransferTable;

        /// <summary>
        /// Scorecards table
        /// </summary>
        public static double[,] cashTypeBonusCoefficients;
        private List<Account> accounts { get; set; }

        /// <summary>
        /// Constructor for bank service
        /// </summary>
        public BankService()
        {
            currencyTransferTable = new double[currencyNumber,currencyNumber];
            GetCurrencyTransfer();
            cashTypeBonusCoefficients = new double[bonusCoefficientsNumber, cashTypeNumber];
            GetCashTypeBonusCoefficients();
            accounts = new List<Account>();
        }

        /// <summary>
        /// Creating account
        /// </summary>
        /// <param name="accountId">Account ID</param>
        /// <param name="name">Name</param>
        /// <param name="surname">Surname</param>
        /// <exception cref="ArgumentException">When this id or name and surname are already used</exception>
        public void CreateAccount(int accountId,string name,string surname)
        {
            foreach (Account account in accounts)
            {
                if (account.ID == accountId)
                {
                    throw new ArgumentException("This ID is used by another account");
                }
                if (account.Name == name && account.Surname == surname)
                {
                    throw new ArgumentException("An account with the same name has already been created");
                }
            }
            accounts.Add(new Account(accountId, name, surname));
        }

        /// <summary>
        /// Account closing
        /// </summary>
        /// <param name="accountId">Account ID</param>
        /// <param name="name">Name</param>
        /// <param name="surname">Surname</param>
        public void ClouseAccount(int accountId, string name, string surname)
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
            FindAccount(accountId, name, surname).CreateCash(cashId, currency,cashType);
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
            FindAccount(accountId,name,surname).CloseCash(cashId);
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
        
        /// <summary>
        /// Currency converting
        /// </summary>
        /// <param name="currency1">From this currency</param>
        /// <param name="currency2">To this currency</param>
        /// <param name="value">Amount</param>
        /// <returns></returns>
        public static int CurrencyConverter(Currency currency1,Currency currency2,int value)
        {
            return (int)(value * currencyTransferTable[(int)currency1, (int)currency2]);
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

        private void GetCurrencyTransfer()
        {
            try
            {
                string[] lines = File.ReadAllLines(currencyTransferWay);
                for (int i=0;i<lines.Length;i++)
                {
                    string[] words = lines[i].Split(' ');
                    currencyTransferTable[(int)Enum.Parse(typeof(Currency), words[0]), 
                        (int)Enum.Parse(typeof(Currency), words[1])] = Convert.ToDouble(words[2]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private void GetCashTypeBonusCoefficients()
        {
            try
            {
                string[] lines = File.ReadAllLines(cashTypeCoefficientsWay);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] words = lines[i].Split(' ');
                    int cashType = (int)Enum.Parse(typeof(CashType),words[0]);
                    cashTypeBonusCoefficients[0,cashType]= Convert.ToDouble(words[1]);
                    cashTypeBonusCoefficients[1, cashType] = Convert.ToDouble(words[2]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
