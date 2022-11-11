﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    public class PersonalAccount : Account
    {
        public PersonalAccount(string accNum, float balance) : base(accNum, balance)  
        {
            this.accountNum = accNum;
            this.balance = balance;
        }
    }
}
