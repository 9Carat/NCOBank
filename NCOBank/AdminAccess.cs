using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    internal class AdminAccess
    {
        public static void Run()
        {
            string selection = null;
            TextMessages.YellowMessageColor("1. Add user");
            TextMessages.YellowMessageColor("2. Unlock user");
            TextMessages.YellowMessageColor("3. Set account balance");
            TextMessages.YellowMessageColor("4. Uppdate exchangerate on foreign currency");
            TextMessages.YellowMessageColor("0. Log out");

            
            do
            {
                selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        AddUser();
                        break;
                    case "2":
                        UnlockUser();
                        break;
                    case "3":
                        SetBalance();
                        break;
                    case "4":
                        UppdateExchangeRate();
                        break;
                    case "0":
                        Console.Clear();
                        BankMenu.Run();
                        break;
                }
                TextMessages.MessageColor("You have to type the specific key", false);

            } while (true);
            
        }
        public static void AddUser()
        {
            BankMenu.CreateAccount();
            Run();
        }
        public static void UnlockUser()
        {
            BankMenu.lockedOut = false;
            TextMessages.MessageColor("Login lock removed.");
            TextMessages.PressEnter();
            Run();
        }
        public static void SetBalance()
        {
            float amount;
            User user = null;
            Account accountNum = null;
            string username;
            string accNum = null;
            bool accountExist = false;

            TextMessages.YellowMessageColor("Select user:");
            username = Console.ReadLine();

            foreach (var item in BankMenu.userList)
            {
                if(item.Username == username)
                {
                    user = item;
                    break;
                }
            }

            if(user == null)
            {
                TextMessages.MessageColor("User not found. Please try again", false);
                Console.ReadLine();
                Console.Clear();
                Run();
            }
            else
            {
                TextMessages.YellowMessageColor("User has the following accounts:");

                foreach (var item in AccountManager.accountList)
                {
                    if (item.Value.Equals(user) && item.Key.accType == "personal")
                    {
                        TextMessages.YellowMessageColor($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance}");
                    }
                    else if (item.Value.Equals(user) && item.Key.accType == "savings")
                    {
                        TextMessages.YellowMessageColor($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance} - Interest rate: {item.Key.savingsInterest}");
                    }
                    else if (item.Value.Equals(user) && item.Key.accType == "currency")
                    {
                        TextMessages.YellowMessageColor($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance} - Currency: {item.Key.currency}");
                    }
                }
                TextMessages.YellowMessageColor("Select account:");
                accNum = Console.ReadLine();
                foreach (var item in AccountManager.accountList)
                {
                    if (item.Value.Equals(user) && item.Key.accountNum == accNum)
                    {
                        accountNum = item.Key;
                        accountExist = true;
                    }
   
                }
                if (!accountExist)
                {
                    TextMessages.MessageColor("the account you typed in do not exist, please try again: ", false);
                    TextMessages.PressEnter();
                    SetBalance();
                }
                TextMessages.YellowMessageColor("How much do you want to transfer?: ");
                try
                {
                    amount = float.Parse(Console.ReadLine());
                    if (amount > 0)
                    {

                    }
                    else
                    {
                        TextMessages.MessageColor("You cant set 0 or a negative balance", false);
                        TextMessages.PressEnter();
                        SetBalance();
                    }
                    
                }
                catch (Exception)
                {
                    TextMessages.MessageColor("You have to type in the amount with numbers 0-9 only", false);
                    TextMessages.PressEnter();
                    SetBalance();
                    throw;
                }
                foreach (var item in AccountManager.accountList)
                {
                    if (item.Value.Equals(user) && item.Key.accountNum == accNum)
                    {
                        item.Key.balance += amount;
                        AccountManager.accountHistory.Add(new KeyValuePair<string, string>(accNum, $"{amount} received - {DateTime.Now.ToString("g")}"));
                    }
                }

                TextMessages.MessageColor("Balance set");
                TextMessages.PressEnter();
                Run();
            }
           
        }
        public static void UppdateExchangeRate()
        {
            float exchangeRate = 0;
            string currency = null;
            bool currencyExist = false;

            if (AccountManager.ExchangeRate.ContainsKey("USD"))
            {
                AccountManager.ExchangeRate.Remove("USD");
            }
            else if (AccountManager.ExchangeRate.ContainsKey("EUR"))
            {
                AccountManager.ExchangeRate.Remove("EUR");
            }
            else if (AccountManager.ExchangeRate.ContainsKey("DKK"))
            {
                AccountManager.ExchangeRate.Remove("DKK");
            }


            TextMessages.YellowMessageColor("USD, EUR, DKK");
            TextMessages.YellowMessageColor("Type the name of the currency you want to uppdate: ");
            currency = Console.ReadLine();
            if (currency == "USD" || currency == "usd" || currency == "EUR" || currency == "eur" || currency == "DKK" || currency == "dkk")
            {
                TextMessages.MessageColor("Currency chosen: ");
                currencyExist = true;
            }
            else
            {
                TextMessages.MessageColor("You chose a non-viable currency. Try again: ", false);
                TextMessages.PressEnter();
                Run();
            }
            TextMessages.YellowMessageColor("Type the value of the currency you want to uppdate in this format 0,000: ");

            try
            {
                exchangeRate = float.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                TextMessages.MessageColor("When setting value you can only use numbers 0-9.", false);
                TextMessages.PressEnter();
                UppdateExchangeRate();
                throw;
            }
            AccountManager.ExchangeRate.Add(currency, exchangeRate);
            TextMessages.MessageColor("Currency set");
            TextMessages.PressEnter();
            Run();
        }
    }
}
