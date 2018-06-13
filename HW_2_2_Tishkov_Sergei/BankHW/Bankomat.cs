using System;
using System.Collections.Generic;
using System.Text;

using BankHW.Accounts;


namespace BankHW
{
    public abstract class Bankomat
    {
        public string Address { get; protected set; }
        public abstract double GetMoney(Account account, double amount);

        public Bankomat(string address)
        {
            Address = address;
        }
    }
}
