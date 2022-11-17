using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    public class SavingsAccount : Account
    {
        private static float savingsInterest = 0.02f;
        public float SavingsInterest 
        { 
            get
            {
                return savingsInterest;
            }
            set
            {
                savingsInterest = value;
            }
        }
        public SavingsAccount(int accNum, float balance) 
        {
            this.SavingsInterest = savingsInterest;
            this.accountNum = accNum;
            this.balance = balance;
        }
        public static float CheckInterest(float balance)
        {
            float interest = balance * 12 * savingsInterest;
            Console.Write("Current yearly interest based on your monthly savings: ");
            return interest;
        }
        public static string DisplayInterest()
        {
            return $"Current interest on a yearly Savings Account {savingsInterest}%";
        }
    }
}
