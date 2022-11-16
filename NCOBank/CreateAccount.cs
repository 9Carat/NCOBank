using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    internal class CreateAccount
    {
        public static void Run(User user)
        {
            Console.WriteLine("Please select one of the following options:");
            Console.WriteLine("1. Create a personal account");
            Console.WriteLine("2. Create a savings account");
            Console.WriteLine("3. Create an account in a new currency");
            Console.WriteLine("4. Transfer sek from a personal account to a new currency account");
            Console.WriteLine("5. Previous menu");
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
                    CurrencyExchange.Run(user);
                    break;
                case "5":
                    Console.Clear();
                    AccountManager.Run(user);
                    break;
            }
        }
        public static void CreatePersonalAcc(User user)
        {
            Console.WriteLine("Choose an account number (xxx xxx xxx-x)");
            string accNum = Console.ReadLine();
            Console.WriteLine("Choose your balance");
            float balance = float.Parse(Console.ReadLine());

            AccountManager.personalAccList.Add(new PersonalAccount(accNum, balance), user); // stores the account in the dictionary
            AccountManager.accountHistory.Add(new KeyValuePair<string, string>(accNum, $"Account created - {DateTime.Now.ToString("g")}")); // logs the creation of the account

            Console.WriteLine("Personal account successfully created. Press enter to continue.");
            Console.ReadLine();
            Console.Clear();
        }
        public static void CreateSavingsAcc(User user)
        {
            SavingsAccount x = new SavingsAccount(" ", 100); //stökig, kolla på fixa sen
            Console.WriteLine(x.DisplayInterest());
            Console.WriteLine("\nPress enter to continue.");
            Console.ReadLine();
            Console.WriteLine("Choose an account number (10 digits)");
            string accNum = Console.ReadLine();
            Console.WriteLine("Choose your balance");
            float balance = float.Parse(Console.ReadLine());
            AccountManager.savingsAccList.Add(new SavingsAccount(accNum, balance), user);
            Console.WriteLine(x.CheckInterest(balance) + "kr");
            Console.WriteLine("Personal account successfully created. Press enter to continue.");
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

            AccountManager.currencyAccList.Add(new CurrencyAccount(accountName, newCurrency), user);

            Console.WriteLine("You have sucessfully created an account in a foreign value: press enter to continue");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
