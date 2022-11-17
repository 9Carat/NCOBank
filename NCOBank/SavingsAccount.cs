using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    public class SavingsAccount : Account
    {
        public float SavingsInterest { get; }
        public SavingsAccount(string accNum)
        {
            this.SavingsInterest = 0.02f;
            this.accountNum = accNum;
            this.balance = 0;
            this.accType = "savings";
        }
        public float CheckInterest(float balance)
        {
            float interest = balance * 12 * SavingsInterest;
            Console.Write("Current yearly interest based on your monthly savings: ");
            return interest;
        }
        public string DisplayInterest()
        {
            return $"Current interest on a yearly Savings Account {SavingsInterest}%";
        }
    }
}
