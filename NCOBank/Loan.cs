using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
                TextMessages.YellowMessageColor($"The max loan is {maxLoan}");
            }
            else if (maxLoan == 0)
            {
                TextMessages.MessageColor("You don't have enough founds to take a loan", false);
                TextMessages.PressEnter();
                AccountManager.Run(user);
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            TextMessages.YellowMessageColor("Apply the amount you want to loan: ");
            float answer;
            while (!float.TryParse(Console.ReadLine(), out answer))
            {
                TextMessages.MessageColor("Please enter an amount", false);
            }
            if (answer > maxLoan)
            {
                TextMessages.MessageColor("The amount you are asking for is too high", false);
            }
            else if (answer > 0)
            {
                user.NumLoans += answer;
                TextMessages.MessageColor($"Your loan for {answer} has been approved");
                TextMessages.YellowMessageColor(CheckInterest(answer));
                AccountManager.loanList.Add(new Loan(maxLoan, answer), user);
            }
            else
            {
                TextMessages.MessageColor("The amount needs to be greater than 0", false);  
            }
            TextMessages.PressEnter();
        }
        private static float CheckMaxLoan(User user)
        {

            foreach (var item in AccountManager.accountList) // checks total balance on all accounts
            {
                if (item.Value.Equals(user))
                {
                    totalPersonal += item.Key.balance;
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
        public static string CheckInterest(float loan)
        {
            float interest = loan * loanInterest;
            return $"The yearly interest rate on your loan is: {interest}kr";   
        }
    }
}
