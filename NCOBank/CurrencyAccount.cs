using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    public class CurrencyAccount
    {
        double usd = 0.096;
        double eur = 0.093;
        double dkk = 0.069;
        private double oldCurrency;
        private double newCurrency;
        private double balance;
        private string accountName;
        public double OldCurrency { get; set; }
        public double Balance { get; set; }
        public double NewCurrency { get; set; }
        public string AccountName { get; set; }
        public CurrencyAccount(string accountName, double newCurrency)
        {
            this.OldCurrency = oldCurrency;
            this.NewCurrency = newCurrency;
            this.AccountName = accountName;
            this.Balance = balance;
        }
    }
}
