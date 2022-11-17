using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    public class CurrencyAccount : Account
    {
        public static Dictionary<CurrencyAccount, User> currencyAccList = new Dictionary<CurrencyAccount, User>();

        public CurrencyAccount(string currency)
        {
            this.balance = 0;
            this.accountNum = CreateAccount.RndAccNum();
            this.accType = "currency";
            this.currency = currency;
        }
    }
}
