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
        private static float maxLoan;
        private static float totalPersonal;
        private static float loanInterest = 0.03f;
        private static float totalLoan = 5;
        private static float newLoan;
        public float NewLoan { get; set; }
        public float TotalPersonal { get; set; }
        public float LoanInterest { get; set; }
        public float TotalLoan
        {
            get
            {
                return totalLoan;
            }
        }
        public Loan()
        {
            this.NewLoan = newLoan;
            this.TotalPersonal = totalPersonal;
            this.LoanInterest = loanInterest;
        }
        public Loan(float newLoan, float answer)
        {

        }


        public static void Run(User user)
        {
            Console.WriteLine("Current interest rate on our loan is {0:P2}", loanInterest); // flytta till checkloan metod?
            CheckMaxLoan(user);
            CheckLoan(user);
        }
        private static void CheckLoan(User user)
        {
            if (maxLoan > 0)
            {

                Console.WriteLine($"The max loan is {maxLoan}");
            }
            else if (maxLoan == 0)
            {
                Console.WriteLine("You don't have enough founds to take a loan");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                Console.Clear();
                AccountManager.Run(user);
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.WriteLine("Apply the amount you want to loan: ");
            float answer;
            while (!float.TryParse(Console.ReadLine(), out answer))
            {
                Console.WriteLine("Please enter an amount");
            }
            if (answer > maxLoan)
            {
                Console.WriteLine("The amount you are asking for is too high");
            }
            else
            {
                user.NumLoans += answer;
                Console.WriteLine($"Your loan for {answer} has been approved");
                AccountManager.loanList.Add(new Loan(maxLoan, answer), user);
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
        private static float CheckMaxLoan(User user)
        {
            foreach (var item in AccountManager.accountList) // checks total balance on all accounts
            {
                if (item.Value.Equals(user))
                {
                    totalPersonal = item.Key.balance;
                }
            } 
            foreach (var item in AccountManager.loanList)
            {
                if (item.Value.Equals(user))
                {
                    newLoan = item.Value.NumLoans;
                }
            }
            return maxLoan = totalPersonal * totalLoan - newLoan;
        }
    }
}
