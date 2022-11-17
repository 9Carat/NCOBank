using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    public class PersonalAccount : Account
    {
        public PersonalAccount(int accNum, float balance) 
        {
            this.accountNum = accNum;
            this.balance = balance;
        }
    }
}
