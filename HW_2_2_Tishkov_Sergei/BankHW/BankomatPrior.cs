using System;
using System.Collections.Generic;
using System.Text;

using BankHW.Accounts;


namespace BankHW
{
    public class BankomatPrior : BankomatPriorbank
    {
        public BankomatPrior(string address) : base(address)
        { }

        public override double GetMoney(Account account, double amount)
        {
            Console.Write($"Bankomat po adresy {Address} obrabativaet zapros na vidachu deneg:\nna schetu bilo {account.Currency}, zaprosheno {amount}, ");
            double result = account.GetMoney(amount);
            Console.WriteLine($"polucheno {result}, ostatok {account.Currency}");
            return result;
        }

        public override void TakeBonus(Account account)
        {
            if (account is PriorAccount priorAcc)
            {
                priorAcc.GetBonus();
            }
            else
            {
                Console.WriteLine("Prostite, bonusi dostuoni tol'ko abonentam nashego banka.");
            }
        }
    }
}
