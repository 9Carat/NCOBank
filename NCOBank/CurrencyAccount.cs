using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    public class CurrencyAccount
    {
        public static Dictionary<CurrencyAccount, User> currencyAccList = new Dictionary<CurrencyAccount, User>();
        public static Dictionary<PersonalAccount, User> personalAccList = new Dictionary<PersonalAccount, User>();
        float usd = 0.096f;
        float eur = 0.093f;
        float dkk = 0.069f;
        private float oldCurrency;
        private float newCurrency;
        private float balance;
        private string accountName;
        private string currency;
        public float OldCurrency { get; set; }
        public float NewCurrency { get; set; }
        public float Balance { get; set; }
        public string AccountName { get; set; }
        public string Currency { get; set; }
        public CurrencyAccount(string accountName, float newCurrency)
        {
            this.OldCurrency = oldCurrency;
            this.NewCurrency = newCurrency;
            this.AccountName = accountName;
            this.Balance = balance;
            this.Currency = currency;
        }
    }
}
