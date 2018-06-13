using System;
using System.Collections.Generic;
using System.Text;

using BankHW.Accounts;


namespace BankHW
{
    public abstract class BankomatPriorbank : Bankomat
    {
        public BankomatPriorbank(string address) : base(address)
        { }

        public abstract void TakeBonus(Account account);
    }
}
