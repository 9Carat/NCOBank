﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    public class PersonalAccount : Account
    {
        public PersonalAccount() 
        {
            this.accountNum = CreateAccount.RndAccNum();
            this.balance = 0;
            this.accType = "personal";
        }
    }
}
