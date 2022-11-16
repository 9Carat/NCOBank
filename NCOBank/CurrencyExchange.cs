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
            string accountName;
            string Currency;
            bool b = false;
            bool c = false;
            bool d = true;

            Console.WriteLine("These are your personal accounts: ");
            foreach (var item in AccountManager.personalAccList)
            {
                Console.WriteLine($"{item.Key.accountNum}");
            }

            Console.WriteLine("Type the exact name of the one you would like to choose: ");
            accountName = Console.ReadLine();

            do
            {
                foreach (var item in AccountManager.personalAccList)
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
                    newCurrency = oldCurrency * usd;
                    c = true;
                }
                else if (Currency.Equals("EUR"))
                {
                    newCurrency = oldCurrency * eur;
                    c = true;
                }
                else if (Currency.Equals("DKK"))
                {
                    newCurrency = oldCurrency * dkk;
                    c = true;
                }
                else if (Currency != "USD" || Currency != "EUR" || Currency != "DKK")
                {
                    Console.WriteLine("You need to write in correct currency");
                }

            } while (c = false);
            c = false;

            accountName = accountName + " " + Currency;
            AccountManager.currencyAccList.Add(new CurrencyAccount(accountName, newCurrency), user);

            Console.ReadKey();
            Console.Clear();
        }
    }
}


