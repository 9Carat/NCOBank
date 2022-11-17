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

        public CurrencyAccount(string accNum, float balance)
        {
            this.balance = balance;
            this.accountNum = accNum;
        }
    }
}
