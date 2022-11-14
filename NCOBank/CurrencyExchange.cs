using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;

namespace NCOBank
{

    class CurrencyExchange
    {
        public static Dictionary<CurrencyAccount, User> currencyAccList = new Dictionary<CurrencyAccount, User>();
        public static Dictionary<PersonalAccount, User> personalAccList = new Dictionary<PersonalAccount, User>();
        double usd = 0.096;
        double eur = 0.093;
        double dkk = 0.069;
        private double oldCurrency;
        private double newCurrency;
        private string accountName;
        public double OldCurrency { get; set; }
        public double NewCurrency { get; set; }
        public string AccountName { get; set; }
        public CurrencyExchange()
        {
            this.OldCurrency = oldCurrency;
            this.NewCurrency = newCurrency;
            this.AccountName = accountName;
        }

        public static void Run(User user)
        {
            CurrencyExchange CE = new CurrencyExchange();
            CE.CurrencySaver(user);

        }

        public void CurrencySaver(User user)
        {
            foreach (var item in AccountManager.personalAccList)
            {
                if (item.Value.Equals(user))
                {
                    oldCurrency = item.Key.balance;
                }
            }
            foreach (var item in AccountManager.personalAccList)
            {
                if (item.Key.Equals(user))
                {
                    accountName = item.Key.accountNum;
                }
            }
            foreach (var item in AccountManager.personalAccList)
            {
                if (item.Value.Equals(user))
                {
                    Console.WriteLine(item.Key.accountNum);
                    
                }
            }
            Console.WriteLine("Which account would u like to change currency on?");

            var account = "hello";
            while (account != AccountName)
            {
                foreach (var item in AccountManager.personalAccList)
                {
                    account = Console.ReadLine();
                    if (item.Key.accountNum.Equals(account))
                    {
                        Console.WriteLine("Proceed to choose the currency you would like to change to: ");
                        account = accountName;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You need to type in the exact account name");
                        
                    }

                }
                
            }
            
    
            Console.WriteLine("Which currency would u like to change to?");
            Console.WriteLine("1: Sek to USD");
            Console.WriteLine("2: Sek to Eur");
            Console.WriteLine("3: Sek to DKK");
            int choice;
            int.TryParse(Console.ReadLine(), out choice);
            switch (choice)
            {
                case 1:
                    SekToUSD(user);
                    Console.Clear();
                    break;
                case 2:
                    SekToEur(user);
                    Console.Clear();
                    break;
                case 3:
                    SekToDKK(user);
                    Console.Clear();
                    break;
                    
            }
            void SekToUSD(User user)
            {
                newCurrency = oldCurrency * usd;
            }
            void SekToEur(User user)
            {
                newCurrency = oldCurrency * eur;
            }
            void SekToDKK(User user)
            {
                newCurrency = oldCurrency * dkk;
            }
            foreach (var item in AccountManager.personalAccList)
            {
                if (choice == 1)
                {
                  accountName = item.Key.accountNum + "USD";
                }
                else if (choice == 2)
                {
                    accountName = item.Key.accountNum + "Eur";
                }
                else if (choice == 3)
                {
                    accountName = item.Key.accountNum + "DKK";
                }
            }
            foreach (var item in AccountManager.currencyAccList)
            {
                item.Key.Balance = newCurrency;
                item.Key.AccountName = accountName;
            }
            //Implementera en minus funktion på personalAcclist
            AccountManager.currencyAccList.Add(new CurrencyAccount(accountName, newCurrency), user);
            Console.WriteLine("===========================================");

            foreach (var item in AccountManager.personalAccList)
            {
                Console.WriteLine(item.Key.accountNum);
                Console.WriteLine(item.Key.balance);
            }
            Console.WriteLine("===========================================");
            foreach (var item in AccountManager.currencyAccList)
            {
                Console.WriteLine(item.Key.AccountName);
                Console.WriteLine(item.Key.NewCurrency);
            }
            Console.WriteLine("===========================================");

            Console.ReadKey();
            Console.Clear();
        }

       
    }
} 

