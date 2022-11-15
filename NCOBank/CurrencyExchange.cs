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
        string Currency;
        float usd = 0.096f;
        float eur = 0.093f;
        float dkk = 0.069f;
        private float oldCurrency;
        private float newCurrency;
        private string accountName;
        
        public float OldCurrency { get; set; }
        public float NewCurrency { get; set; }
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
            string accountNumCur = "placeholder";
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
                    accountNumCur = item.Key.accountNum;
                    
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

            //AccountManager.personalAccList.Keys.
            accountName = accountNumCur + " " + Currency;


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

