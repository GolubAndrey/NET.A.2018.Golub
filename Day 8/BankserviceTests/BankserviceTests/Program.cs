using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankService;

namespace BankserviceTests
{
    class Program
    {
        static void Main(string[] args)
        {
            BankService.BankService bank = new BankService.BankService();

            bank.CreateAccount(1, "Andrey", "Golub");
            bank.CreateAccount(2, "Victor", "Golub");

            bank.CreateCash(1, "Andrey", "Golub", Currency.USD, 31, CashType.Platinum);
            bank.CreateCash(1, "Andrey", "Golub", Currency.BYN, 32, CashType.Base);

            bank.ReplenishCash(1, "Andrey", "Golub", 31, 12000);
            bank.ReplenishCash(1, "Andrey", "Golub", 31, 15000);
            Console.WriteLine(bank.WatchCashAmount(1, "Andrey", "Golub", 31));
            Console.WriteLine(bank.SeeBonuses(1, "Andrey", "Golub"));
            Console.WriteLine(bank.WithdrawBonuses(1, "Andrey", "Golub", 200));

            bank.ChangeCashCurrency(1, "Andrey", "Golub", 31, Currency.BYN);
            Console.WriteLine(bank.WatchCashAmount(1, "Andrey", "Golub", 31));
            bank.WithdrawMoneyFromCash(1, "Andrey", "Golub", 31, 30000);
            Console.WriteLine(bank.WatchCashAmount(1, "Andrey", "Golub", 31));
            bank.ChangeCashType(1, "Andrey", "Golub", 31, CashType.Base);
            bank.ReplenishCash(1, "Andrey", "Golub", 31, 15000);
            Console.WriteLine(bank.SeeBonuses(1, "Andrey", "Golub"));


            bank.ClouseAccount(2, "Victor", "Golub");
            


            Console.ReadLine();
        }
    }
}
