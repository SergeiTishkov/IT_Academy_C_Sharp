using System;
using System.Collections.Generic;
using System.Text;

namespace BankHW.Accounts
{
    public class PriorAccount : Account
    {
        private bool _isBonusGot;

        public PriorAccount(double currency) : base(currency) { }

        internal void GetBonus()
        {
            if (!_isBonusGot)
            {
                Console.WriteLine("Poluchite vash bonus!");
                Console.Write($"Na schetu bilo {Currency}, ");
                Currency *= 1.01;
                Console.WriteLine($"stalo {Currency}");
                _isBonusGot = true;
            }
            else
            {
                Console.WriteLine("Prostite, bonus vidaets'a odin raz na kartochku.");
            }
            
        }
    }
}
