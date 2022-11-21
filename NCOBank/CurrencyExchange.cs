using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    class CurrencyExchange
    {
        public static void Run(User user)
        {
            CurrencyExchange CE = new CurrencyExchange();
            CE.CurrencyTransfer(user);

        }

        public void CurrencyTransfer(User user)
        {
            float usd = 0.096f;
            float eur = 0.093f;
            float dkk = 0.069f;
            float newCurrency = 0;
            float oldCurrency;
            Account accountSend = null;
            Account accountRecieve = null;
            string accountName;
            string Currency;
            bool b = false;
            bool c = false;
            bool d = true;

            Console.WriteLine("These are your personal accounts: ");
            foreach (var item in AccountManager.accountList)
            {
                Console.WriteLine($"{item.Key.accountNum}");
            }

            Console.WriteLine("Type the exact name of the one you would like to choose: ");
            accountName = Console.ReadLine();

            do
            {
                foreach (var item in AccountManager.accountList)
                {
                    if (accountName == item.Key.accountNum)
                    {
                        accountSend = item.Key;
                        b = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You have to type in the account exacly as it is named");
                    }
                }

            } while (b = false);


            Console.WriteLine("How much would you like to transfer to the new currency?");
            do
            {
                oldCurrency = float.Parse(Console.ReadLine());
                if (oldCurrency > 0)
                {
                    c = false;
                    break;
                }
                else if (oldCurrency <= 0)
                {
                    Console.WriteLine("You cant add a negative number, re-enter the amount you'd like to add");
                }
            } while (c = true);

            accountSend.balance -= oldCurrency;

            Console.WriteLine("in which currency would you like to create your bank account in?");

            string[] CurrencyArray = { "USD ", "EUR ", "DKK " };
            foreach (var item in CurrencyArray)
            {
                Console.WriteLine(item.ToString());
            }
            do
            {
                Currency = Console.ReadLine();
                if (Currency.Equals("USD"))
                {
                    newCurrency = oldCurrency * AccountManager.ExchangeRate["USD"];
                    c = true;
                }
                else if (Currency.Equals("EUR"))
                {
                    newCurrency = oldCurrency * AccountManager.ExchangeRate["EUR"];
                    c = true;
                }
                else if (Currency.Equals("DKK"))
                {
                    newCurrency = oldCurrency * AccountManager.ExchangeRate["DKK"];
                    c = true;
                }
                else if (Currency != "USD" || Currency != "EUR" || Currency != "DKK")
                {
                    Console.WriteLine("You need to write in correct currency");
                }

            } while (c = false);
            c = false;

            Console.WriteLine("In which account would ");
            string newAccount = Console.ReadLine();
            foreach (var item in AccountManager.accountList)
            {
                if (newAccount == item.Key.accountNum && item.Key.accType == "currency")
                {
                    accountRecieve = item.Key;
                    b = true;
                    break;
                }
                else
                {
                    Console.WriteLine("You have to type in the account exacly as it is named");
                    Console.WriteLine("Account could not be found, you have to type the currency account: ");
                }
            }

                accountName = accountName + " " + Currency;
            accountRecieve.balance += newCurrency;
            Console.ReadKey();
            Console.Clear();

        }
    }
}


