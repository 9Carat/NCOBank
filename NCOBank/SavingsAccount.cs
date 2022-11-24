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
                if (value < 0)
                {
                    throw new Exception("Value can't be negative");
                }
                else
                {
                    savingsInterest = value;
                }
            }
        }
        public SavingsAccount()
        {
            this.SavingsInterest = savingsInterest;
            this.accountNum = CreateAccount.RndAccNum();
            this.balance = 0;
            this.accType = "savings";

        }
        public static string CheckInterest(float balance) // lägga till när vi flyttar pengar till sparkonto!!
        {
            float interest = balance * savingsInterest;
            return $"The yearly savings interest is: {interest}kr";
        }
        public static string DisplayInterest()
        {
            return String.Format("Yearly interest rate: {0:P2}", savingsInterest);
        }
    }
}
