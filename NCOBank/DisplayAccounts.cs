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
            Console.WriteLine("Please select one of the following options:");
            Console.WriteLine("1. Display your accounts");
            Console.WriteLine("2. Show account history");
            Console.WriteLine("0. Previous menu");
            string selection = Console.ReadLine();

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
            }
        }
        public static void Display(User user)
        {
            Console.WriteLine("You currently have the following accounts:");
            
            foreach(var item in AccountManager.personalAccList)
            {
                if (item.Value.Equals(user))
                {
                    Console.WriteLine($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance}");
                }
            }
            foreach (var item in AccountManager.savingsAccList)
            {
                if (item.Value.Equals(user))
                {
                    Console.WriteLine($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance}");
                }
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
            Run(user);
        }
        public static void DisplayHistory(User user)
        {
            Console.WriteLine("Which account do you want show the history for?");
            int account; 
            int.TryParse(Console.ReadLine(), out account);

            bool isUserAccount = false;
            foreach (var item in AccountManager.personalAccList) // Checks if account belongs to user
            {
                if (item.Key.accountNum == account && item.Value.Equals(user))
                {
                    isUserAccount = true;
                    break;
                }
            }

            if (isUserAccount)
            {
                foreach (KeyValuePair<int, string> acc in AccountManager.accountHistory)
                {
                    if (acc.Key == account)
                        Console.WriteLine($"Account: {acc.Key} - {acc.Value}");

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
