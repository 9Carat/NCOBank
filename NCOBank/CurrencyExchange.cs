using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace NCOBank
{

    class CurrencyExchange
    {

        public static Dictionary<PersonalAccount, User> personalAccList = new Dictionary<PersonalAccount, User>();
        
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

            Console.WriteLine("Which account would u like to change currency on?");

            foreach (var item in AccountManager.personalAccList)
            {
                if (item.Value.Equals(user))
                {
                    Console.WriteLine(item.Key.accountNum);
                    
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
                newCurrency = oldCurrency * 0.096;
            }
            void SekToEur(User user)
            {
                newCurrency = oldCurrency * 0.093;
            }
            void SekToDKK(User user)
            {
                newCurrency = oldCurrency * 0.069;
            }
            Console.WriteLine($"{newCurrency}");
            Console.ReadKey();
           
            foreach (var item in AccountManager.personalAccList)
            {
                item.Key.balance = newCurrency;
            }
        }
       
    }
} 

