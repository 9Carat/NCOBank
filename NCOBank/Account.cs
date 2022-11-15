using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    public abstract class Account
    {
        public string accountNum;
        public float balance;

        public Account(string accNum, float balance)
        {
            this.accountNum = accNum;
            this.balance = balance;
        }
    }
}
