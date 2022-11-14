using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    internal class Loan
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

            float maxLoan = (totalPersonal + totalSaving) * totalLoan;
            Console.WriteLine($"The max loan is {maxLoan}");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.WriteLine("Apply the amount you want to loan: ");
            float answer;
            float.TryParse(Console.ReadLine(), out answer);
            if (answer > maxLoan)
            {
                Console.WriteLine("The amount you are asking for is too high");
            }
            else
            {
                Console.WriteLine($"Your loan for {answer} has been approved");
                answer = newLoan; //använda för att kolla fler lån?
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
