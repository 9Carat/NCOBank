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
        public string MyProperty { get; set; }
        public static void Run(User user)
        {
            Console.WriteLine("Please select one of the following options:");
            Console.WriteLine("1. Create a personal account");
            Console.WriteLine("2. Create a savings account" + " - " + SavingsAccount.DisplayInterest());
            Console.WriteLine("3. Previous menu");
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
            Console.WriteLine($"Personal account {accNum} successfully created. Press enter to continue.");
            Console.ReadLine();
            Console.Clear();
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
            Console.WriteLine($"Savings account {accNum} successfully created. Press enter to continue.");
            Console.ReadLine();
            Console.Clear();
        }
        public static void CreateForeignCurrencyAcc(User user)
        {
            float usd = 0.096f;
            float eur = 0.093f;
            float dkk = 0.069f;
            float newCurrency = 0;
            float oldCurrency;
            string accountName;
            string Currency;
            bool a = true;

            Console.WriteLine("Choose an account number (10 digits)");
            accountName = Console.ReadLine();
            Console.WriteLine("Choose your balance in sek");

            do
            {
                oldCurrency = float.Parse(Console.ReadLine());
                if (oldCurrency > 0)
                {
                    a = false;
                    break;
                }
                else if (oldCurrency <= 0)
                {
                    Console.WriteLine("You cant add a negative number, re-enter the amount you'd like to add");

                }

            } while (a = true);

            Console.WriteLine("in which currency would you like to create your bank account in?");
            string[] CurrencyArray = { "USD ", "EUR ", "DKK " };
            foreach (var item in CurrencyArray)
            {
                Console.WriteLine(item.ToString());
            }
            bool b;
            do
            {
                Currency = Console.ReadLine();
                if (Currency.Equals("USD"))
                {
                    newCurrency = oldCurrency * usd;
                    b = true;
                }
                else if (Currency.Equals("EUR"))
                {
                    newCurrency = oldCurrency * eur;
                    b = true;
                }
                else if (Currency.Equals("DKK"))
                {
                    newCurrency = oldCurrency * dkk;
                    b = true;
                }
                else if (Currency != "USD" || Currency != "EUR" || Currency != "DKK")
                {
                    Console.WriteLine("You need to write in correct currency");
                }

            } while (b = false);

            accountName = accountName + " " + Currency;

            AccountManager.accountList.Add(new CurrencyAccount(Currency), user);

            Console.WriteLine("You have sucessfully created an account in a foreign value: press enter to continue");
            Console.ReadKey();
            Console.Clear();
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
