using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    public class Loan : Account
    {
        private static float maxLoan;
        private static float loanInterest = 0.03f;
        private static float maxLoanSum = 5;
        public float LoanInterest 
        {
            get
            {
                return loanInterest;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Value can't be negative");
                }
                else
                {
                    loanInterest = value;
                }
            }
        }
        public float MaxLoanSum
        {
            get
            {
                return maxLoanSum;
            }
        }
        public Loan(float answer)
        {
            this.accountNum = CreateAccount.RndAccNum();
            this.accType = "loan";
            this.LoanInterest = loanInterest;
            this.balance = answer;
        } 
        public static void Run(User user)
        {
            TextColor.YellowMessageColor(DisplayInterest());
            CheckMaxLoan(user);
            CheckLoan(user);
        }
        private static void CheckLoan(User user) 
        {
            if (maxLoan > 0)
            {
                TextColor.YellowMessageColor($"The max loan is {maxLoan}");
            }
            else 
            {
                TextColor.MessageColor("You don't have enough founds to take a loan", false);
                TextColor.PressEnter();
                AccountManager.Run(user);
            }
            TextColor.YellowMessageColor("Do you want to apply for a loan? Write Yes or No");
            string loanAnswer = Console.ReadLine();
            if (loanAnswer == "Yes")
            {
                TextColor.YellowMessageColor("Apply the amount you want to loan: ");
                float answer;
                while (!float.TryParse(Console.ReadLine(), out answer))
                {
                    TextColor.MessageColor("Please enter an amount", false);
                }
                if (answer > maxLoan)
                {
                    TextColor.MessageColor("The amount you are asking for is too high", false);
                }
                else if (answer > 0)
                {
                    TextColor.MessageColor($"Your loan for {answer} has been approved");
                    TextColor.YellowMessageColor(CheckInterest(answer));
                    AccountManager.accountList.Add(new Loan(answer), user);
                }
                else
                {
                    TextColor.MessageColor("The amount needs to be greater than 0", false);
                }
                TextColor.PressEnter();
            }
            else if (loanAnswer == "No")
            {
                TextColor.PressEnter();
                AccountManager.Run(user);
            }
            else
            {
                Console.WriteLine("Make sure you write Yes or No. Please try again.");
            }
        }
        private static float CheckMaxLoan(User user)
        {
            float newLoan = 0;
            float tot = 0;
            foreach (var item in AccountManager.accountList) // checks total balance on all accounts
            {
                if (item.Value.Equals(user) && item.Key.accType == "personal")
                {
                    tot += item.Key.balance;
                }
                if (item.Value.Equals(user) && item.Key.accType == "savings")
                {
                    tot += item.Key.balance;
                }
            }

            foreach (var item in AccountManager.accountList) // check total debt from previous loans
            {
                if (item.Value.Equals(user) && item.Key.accType == "loan")
                {
                    newLoan += item.Key.balance;
                }
            }
            return maxLoan = tot * maxLoanSum - newLoan; 
             
        }
        public static string CheckInterest(float loan)
        {
            float interest = loan * loanInterest;
            return $"The yearly interest rate on your loan is: {interest}kr";   
        }
        public static string DisplayInterest()
        {
            return String.Format("Current interest rate on our loan is {0:P2}", loanInterest);
        }
    }
}
