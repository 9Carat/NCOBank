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
                TextColor.YellowMessageColor("Please select one of the following options:");
                TextColor.YellowMessageColor("1. Display your accounts");
                TextColor.YellowMessageColor("2. Show account history");
                TextColor.YellowMessageColor("0. Previous menu ");
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
                        TextColor.MessageColor("Please input your choice using the correct number.", false);
                        TextColor.PressEnter();
                        break;
                }
            } while (selection != "0");
            
        }
        public static void Display(User user)
        {
            TextColor.YellowMessageColor("You currently have the following accounts:");

            foreach (var item in AccountManager.accountList)
            {
                if (item.Value.Equals(user) && item.Key.accType == "personal")
                {
                    TextColor.YellowMessageColor($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance} SEK");
                }
                else if (item.Value.Equals(user) && item.Key.accType == "savings")
                {
                    TextColor.YellowMessageColor($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance} SEK - {SavingsAccount.CheckInterest(item.Key.balance)} ");
                }
                else if (item.Value.Equals(user) && item.Key.accType == "currency")
                {
                    TextColor.YellowMessageColor($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance} {item.Key.currency}");
                }
                else if (item.Value.Equals(user) && item.Key.accType == "loan")
                {
                    TextColor.YellowMessageColor($"Loan nr: {item.Key.accountNum} - Loan debt: {item.Key.balance} SEK - {Loan.CheckInterest(item.Key.balance)}");
                }
            }

            TextColor.PressEnter();
            Run(user);
        }
        public static void DisplayHistory(User user)
        {
            TextColor.YellowMessageColor("You currently have the following accounts:");

            foreach (var item in AccountManager.accountList)
            {
                if (item.Value.Equals(user) && item.Key.accType == "personal")
                {
                    TextColor.YellowMessageColor($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance} SEK");
                }
                else if (item.Value.Equals(user) && item.Key.accType == "savings")
                {
                    TextColor.YellowMessageColor($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance} SEK - {SavingsAccount.CheckInterest(item.Key.balance)}");
                }
                else if (item.Value.Equals(user) && item.Key.accType == "currency")
                {
                    TextColor.YellowMessageColor($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance} {item.Key.currency}");
                }
            }

            TextColor.YellowMessageColor("Which account do you want show the history for?");
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
                        TextColor.YellowMessageColor($"Account: {item.Key} - {item.Value}");
                }
            }
            else
                TextColor.MessageColor("Account not found. Please try again", false);

            TextColor.YellowMessageColor("\nPress 1 to show a different account\nPress 2 to return to the previous menu");
            while (true)
            {
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        DisplayHistory(user);
                        break;
                    case "2":
                        Run(user);
                        TextColor.PressEnter();
                        break;
                    default:
                        TextColor.MessageColor("Please enter option 1 or 2", false);
                        break;
                }
            }
        }
    }
}
