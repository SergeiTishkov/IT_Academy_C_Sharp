using System;
using System.Collections.Generic;
using System.Text;

namespace BankHW.Accounts
{
    public class Account
    {
        public double Currency { get; internal set; }

        public Account(double currency)
        {
            Currency = currency;
        }

        internal double GetMoney(double amount)
        {
            if(amount <= 0)
            {
                Console.WriteLine("Oshibka! Vveidte pologitel'noe chislo!");
                return 0;
            }
            if (Currency < amount)
            {
                Console.WriteLine("Ne hvataet deneg ns schety!");
                return 0;
            }
            Currency -= amount;
            return amount;
        }

        internal void AddMoney(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Oshibka! Vveidte pologitel'noe chislo!");
                return;
            }
            Currency += amount;
        }
    }
}
