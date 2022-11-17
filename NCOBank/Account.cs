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
        public string accType;
        public float savingsInterest;
        public string currency;
    }
}
