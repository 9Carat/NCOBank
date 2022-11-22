using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    internal class DisplayAccounts
    {
        public static void Run(User user)
        {
            string selection;
            do
            {
                Console.WriteLine("Please select one of the following options:");
                Console.WriteLine("1. Display your accounts"); // Same method for both options?
                Console.WriteLine("2. Show account history");
                Console.WriteLine("0. Previous menu ");
                selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        Console.Clear();
                        Display(user);
                        break;
                    case "2":
                        Console.Clear();
                        DisplayHistory(user);
                        break;
                    case "0":
                        Console.Clear();
                        AccountManager.Run(user);
                        break;
                    default:
                        Console.WriteLine("Please input your choice using the correct number. Press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            } while (selection != "0");
            
        }
        public static void Display(User user)
        {
            Console.WriteLine("You currently have the following accounts:");

            foreach (var item in AccountManager.accountList)
            {
                if (item.Value.Equals(user) && item.Key.accType == "personal")
                {
                    Console.WriteLine($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance}");
                }
                else if (item.Value.Equals(user) && item.Key.accType == "savings")
                {
                    Console.WriteLine($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance} - Interest rate: {SavingsAccount.CheckInterest(item.Key.balance)} ");
                }
                else if (item.Value.Equals(user) && item.Key.accType == "currency")
                {
                    Console.WriteLine($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance} - Currency: {item.Key.currency}");
                }
            }

            foreach (var item in AccountManager.loanList)
            {
                if (item.Value.Equals(user))
                {
                    Console.WriteLine($"Loan account - Balance: {item.Value.NumLoans} - Interest: {item.Key.LoanInterest} "); // Add correct method
                }
            }

            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
            Run(user);
        }
        public static void DisplayHistory(User user)
        {
            Console.WriteLine("You currently have the following accounts:");

            foreach (var item in AccountManager.accountList)
            {
                if (item.Value.Equals(user) && item.Key.accType == "personal")
                {
                    Console.WriteLine($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance}");
                }
                else if (item.Value.Equals(user) && item.Key.accType == "savings")
                {
                    Console.WriteLine($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance} - Interest rate: {item.Key.savingsInterest}");
                }
                else if (item.Value.Equals(user) && item.Key.accType == "currency")
                {
                    Console.WriteLine($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance} - Currency: {item.Key.currency}");
                }
            }

            Console.WriteLine("Which account do you want show the history for?");
            string account = Console.ReadLine();

            bool isUserAccount = false;
            foreach (var item in AccountManager.accountList) // Checks if account belongs to user
            {
                if (item.Key.accountNum == account && item.Value.Equals(user))
                {
                    isUserAccount = true;
                    break;
                }
            }

            if (isUserAccount)
            {
                foreach (KeyValuePair<string, string> item in AccountManager.accountHistory)
                {
                    if (item.Key == account)
                        Console.WriteLine($"Account: {item.Key} - {item.Value}");
                }
            }
            else
                Console.WriteLine("Account not found. Please try again");
            
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
            Run(user);
        }
    }
}
