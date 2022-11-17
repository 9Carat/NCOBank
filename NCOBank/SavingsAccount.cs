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
        public SavingsAccount()
        {
            this.SavingsInterest = savingsInterest;
            this.accountNum = CreateAccount.RndAccNum();
            this.balance = 0;
        }
        public static string CheckInterest(float balance) // lägga till när vi flyttar pengar till sparkonto!!
        {
            float interest = balance * 12 * savingsInterest;
            Console.Write("Current yearly interest based on your monthly savings: ");
            interest.ToString();
            return String.Format("{0:P2}", interest);
        }
        public static string DisplayInterest()
        {
            return String.Format("Current yearly interest rate is {0:P2}", savingsInterest);
        }
    }
}
