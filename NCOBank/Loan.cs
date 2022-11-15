using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    public class Loan
    {
        private float totalPersonal;
        private float totalSaving;
        private float totalLoan;
        private float newLoan;
        public float NewLoan { get; set; }
        public float TotalPersonal { get; set; }
        public float TotalSaving { get; set; }
        public float TotalLoan 
        { 
            get
            {
                return totalLoan;
            }
            set
            {
                totalLoan = 5;
            } 
        }
        public Loan()
        {
            this.NewLoan = newLoan;
            this.TotalPersonal = totalPersonal;
            this.TotalSaving = totalSaving;
            this.TotalLoan = totalLoan;
        }
        public Loan(float newLoan, float answer)
        {

        }


        public static void Run(User user)
        {
            Loan x = new Loan();
            x.MaxLoan(user);
            
        }
        public void MaxLoan(User user)
        {
            // lägga till ränta på lån + press enter

            foreach (var item in AccountManager.personalAccList)
            {
                if (item.Value.Equals(user))
                {
                    totalPersonal = item.Key.balance;
                }
            }
            foreach (var item in AccountManager.savingsAccList)
            {
                if (item.Value.Equals(user))
                {
                    totalSaving = item.Key.balance;
                }
            }
            foreach (var item in AccountManager.loanList)
            {
                if (item.Value.Equals(user))
                {
                    newLoan = item.Value.NumLoans;
                }
            }
            float maxLoan = (totalPersonal + totalSaving) * totalLoan - newLoan;
            if (maxLoan > 0)
            {
                Console.WriteLine($"The max loan is {maxLoan}");
            }
            else
            {
                Console.WriteLine("You have reached the max amount on your loans. \nPlease contact the bank if you want to apply for a new one");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                Console.Clear();
                AccountManager.Run(user);
            } 
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.WriteLine("Apply the amount you want to loan: ");
            float answer;
            float.TryParse(Console.ReadLine(), out answer);
            user.NumLoans += answer;
            
            if (answer > maxLoan)
            {
                Console.WriteLine("The amount you are asking for is too high");
            }
            else
            {
                Console.WriteLine($"Your loan for {answer} has been approved");
                AccountManager.loanList.Add(new Loan(maxLoan, answer), user);
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();


        }
    }
}
