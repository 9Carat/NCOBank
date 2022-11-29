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

            TextColor.YellowMessageColor("1. Add user");
            TextColor.YellowMessageColor("2. Unlock user");
            TextColor.YellowMessageColor("3. Set account balance");
            TextColor.YellowMessageColor("4. Uppdate exchangerate on foreign currency");
            TextColor.YellowMessageColor("0. Log out");

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
                TextColor.MessageColor("You have to type the specific key", false);

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
            TextColor.MessageColor("Login lock removed.");
            TextColor.PressEnter();
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

            TextColor.YellowMessageColor("Select user:");
            username = Console.ReadLine();

            foreach (var item in BankMenu.userList)
            {
                if (item.Username == username)
                {
                    user = item;
                    break;
                }
            }

            if (user == null)
            {
                TextColor.MessageColor("User not found. Please try again", false);
                Console.ReadLine();
                Console.Clear();
                Run();
            }
            else
            {
                TextColor.YellowMessageColor("User has the following accounts:");

                foreach (var item in AccountManager.accountList)
                {
                    if (item.Value.Equals(user) && item.Key.accType == "personal")
                    {
                        TextColor.YellowMessageColor($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance} SEK");
                    }
                    else if (item.Value.Equals(user) && item.Key.accType == "savings")
                    {
                        TextColor.YellowMessageColor($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance} SEK - {SavingsAccount.CheckInterest(item.Key.balance)}");
                    }
                    else if (item.Value.Equals(user) && item.Key.accType == "currency")
                    {
                        TextColor.YellowMessageColor($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance} {item.Key.currency}");
                    }
                }
                TextColor.YellowMessageColor("Select account:");
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
                    TextColor.MessageColor("The account you typed in do not exist, please try again: ", false);
                    TextColor.PressEnter();
                    SetBalance();
                }
                TextColor.YellowMessageColor("How much do you want to transfer?: ");
                try
                {
                    amount = float.Parse(Console.ReadLine());
                    if (amount > 0)
                    {

                    }
                    else
                    {
                        TextColor.MessageColor("You cant set 0 or a negative balance", false);
                        TextColor.PressEnter();
                        SetBalance();
                    }

                }
                catch (Exception)
                {
                    TextColor.MessageColor("You have to type in the amount with numbers 0-9 only", false);
                    TextColor.PressEnter();
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

                TextColor.MessageColor("Balance set");
                TextColor.PressEnter();
                Run();
            }

        }
        public static void UppdateExchangeRate()
        {
            float exchangeRate = 0;
            string currency = null;
            bool currencyExist = false;

            TextColor.YellowMessageColor("USD, EUR, DKK");
            TextColor.YellowMessageColor("Type the name of the currency you want to uppdate: ");

            currency = Console.ReadLine().ToUpper();
            if (currency == "USD" || currency == "EUR" || currency == "DKK")
            {
                TextColor.MessageColor("Currency chosen: ");
                currencyExist = true;
            }
            else
            {
                TextColor.MessageColor("You chose a non-viable currency. Try again: ", false);
                TextColor.PressEnter();
                Run();
            }
            TextColor.YellowMessageColor("Type the value of the currency you want to uppdate in this format 0,000: ");

            try
            {
                exchangeRate = float.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                TextColor.MessageColor("When setting value you can only use numbers 0-9.", false);
                TextColor.PressEnter();
                UppdateExchangeRate();
                throw;
            }

            foreach (var item in AccountManager.accountList)
            {
                if (item.Key.accType == "currency")
                {
                    item.Key.balance = item.Key.balance / AccountManager.ExchangeRate[currency];
                }
            }

            AccountManager.ExchangeRate.Remove(currency);
            AccountManager.ExchangeRate.Add(currency, exchangeRate);

            foreach (var item in AccountManager.accountList)
            {
                if (item.Key.accType == "currency")
                {
                    item.Key.balance = item.Key.balance * AccountManager.ExchangeRate[currency];
                }
            }

            TextColor.MessageColor("Currency set");
            TextColor.PressEnter();
            Run();
        }
    }
}
