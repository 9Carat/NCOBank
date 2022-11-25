using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    internal class CreateAccount
    {
        private static string accNum;
        public static void Run(User user)
        {
            TextColor.YellowMessageColor("Please select one of the following options:");
            TextColor.YellowMessageColor("1. Create a personal account");
            TextColor.YellowMessageColor("2. Create a savings account" + " - " + SavingsAccount.DisplayInterest());
            TextColor.YellowMessageColor("3. Create a new currency account");
            TextColor.YellowMessageColor("3. Previous menu");
            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    Console.Clear();
                    CreatePersonalAcc(user);
                    break;
                case "2":
                    Console.Clear();
                    CreateSavingsAcc(user);
                    break; 
                case "3":
                    Console.Clear();
                    CreateForeignCurrencyAcc(user);
                    break;
                case "4":
                    Console.Clear();
                    AccountManager.Run(user);
                    break;
            }
        }
        public static void CreatePersonalAcc(User user)
        {
            AccountManager.accountList.Add(new PersonalAccount(), user); // stores the account in the dictionary

            foreach (var item in AccountManager.accountList)
            {
                if (item.Value.Equals(user))
                {
                     accNum = item.Key.accountNum;
                }
            }
            AccountManager.accountHistory.Add(new KeyValuePair<string, string>(accNum, $"Account created - {DateTime.Now.ToString("g")}")); // logs the creation of the account
            TextColor.MessageColor($"Personal account {accNum} successfully created.");
            TextColor.PressEnter();
        }
        public static void CreateSavingsAcc(User user)
        {
            AccountManager.accountList.Add(new SavingsAccount(), user);

            foreach (var item in AccountManager.accountList)
            {
                if (item.Value.Equals(user))
                {
                    accNum = item.Key.accountNum;
                }
            }
            AccountManager.accountHistory.Add(new KeyValuePair<string, string>(accNum, $"Account created - {DateTime.Now.ToString("g")}"));
            TextColor.MessageColor($"Savings account {accNum} successfully created.");
            TextColor.PressEnter();
        }
        public static void CreateForeignCurrencyAcc(User user)
        {
            string Currency;
            bool validCurrency = false;
            do
            {
                TextColor.YellowMessageColor("USD, EUR, DKK");
                TextColor.YellowMessageColor("What currency would you like to create your account in");
                Currency = Console.ReadLine().ToUpper();
                if (Currency == "USD" || Currency == "EUR" || Currency == "DKK")
                {
                    validCurrency = true;
                }
                else
                {
                    TextColor.MessageColor("Please enter USD, EUR or DKK", false);
                    TextColor.PressEnter();
                }
            } while (!validCurrency);
            AccountManager.accountList.Add(new CurrencyAccount(Currency), user); // stores the account in the dictionary
            foreach (var item in AccountManager.accountList)
            {
                if (item.Value.Equals(user))
                {
                    accNum = item.Key.accountNum;
                }
            }

            AccountManager.accountHistory.Add(new KeyValuePair<string, string>(accNum, $"Account created - {DateTime.Now.ToString("g")}")); // logs the creation of the account
            TextColor.MessageColor($"Currency account {accNum} successfully created.");
            TextColor.PressEnter();
        }
        public static string RndAccNum()
        {
            Random rnd = new Random();
            HashSet<int> accNum = new HashSet<int>();
            while (accNum.Count < 10)
            {
                accNum.Add(rnd.Next(1000000000, 2000000000));
            }
            int randomAccNumber = accNum.First();
            randomAccNumber.ToString();
            return String.Format("{0:000 000 000-0}", randomAccNumber);
        }
    }
}
