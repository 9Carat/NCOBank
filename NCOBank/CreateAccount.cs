﻿using System;
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
            Console.WriteLine("2. Create a Foreign currency account");
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
                    CreateForeignCurrencyAcc(user);
                    break;
                case "3":
                    Console.Clear();
                    AccountManager.Run(user);
                    break;
                    //valuta konto
            }
        }
        public static void CreatePersonalAcc(User user)
        {
            Console.WriteLine("Choose an account number (10 digits)");
            string accNum = Console.ReadLine();
            Console.WriteLine("Choose your balance");
            float balance = float.Parse(Console.ReadLine());

            AccountManager.personalAccList.Add(new PersonalAccount(accNum, balance), user);

            Console.WriteLine("Personal account successfully created. Press enter to continue.");
            Console.ReadLine();
            Console.Clear();
        }
        public static void CreateForeignCurrencyAcc(User user)
        {
            float balance;
            float usd = 0.096f;
            float eur = 0.093f;
            float dkk = 0.069f;
            float newCurrency = 0;
            float oldCurrency;
            string accountName;
            string Currency;

            Console.WriteLine("Choose an account number (10 digits)");
            accountName = Console.ReadLine();
            Console.WriteLine("Choose your balance in sek");
            float.TryParse(Console.ReadLine(), out oldCurrency);

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
 
           

            accountName = accountName +" " + Currency;

            AccountManager.currencyAccList.Add(new CurrencyAccount(accountName, newCurrency), user);

            Console.WriteLine("You have sucessfully created an account in a foreign value: press enter to continue");
            Console.ReadKey();

        }
    }
}
