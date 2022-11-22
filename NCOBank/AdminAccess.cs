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
            Console.WriteLine("1. Add user");
            Console.WriteLine("2. Unlock user");
            Console.WriteLine("3. Set account balance");
            Console.WriteLine("4. Uppdate exchangerate on foreign currency");
            Console.WriteLine("0. Log out");


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
                Console.WriteLine("You have to type the specific key");

            } while (true);

        }
        public static void AddUser()
        {
            Console.WriteLine("State username:");
            string username = Console.ReadLine();
            Console.WriteLine("State password");
            string password = Console.ReadLine();
            Console.WriteLine("State firstname:");
            string firstName = Console.ReadLine().ToUpper();
            Console.WriteLine("State lastname:");
            string lastName = Console.ReadLine().ToUpper();

            BankMenu.userList.Add(new User(username, password, firstName, lastName));

            Console.WriteLine("User successfully added. Press enter to continue");
            Console.ReadLine();
            Console.Clear();
            Run();
        }
        public static void UnlockUser()
        {
            BankMenu.lockedOut = false;
            Console.WriteLine("Login lock removed. Press enter to continue");
            Console.ReadLine();
            Console.Clear();
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

            Console.WriteLine("Select user:");
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
                Console.WriteLine("User not found. Please try again");
                Console.ReadLine();
                Console.Clear();
                Run();
            }
            else
            {
                Console.WriteLine("User has the following accounts:");

                foreach (var item in AccountManager.accountList)
                {
                    if (item.Value.Equals(user) && item.Key.accType == "personal")
                    {
                        Console.WriteLine($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance}");
                    }
                    else if (item.Value.Equals(user) && item.Key.accType == "savings")
                    {
                        Console.WriteLine($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance} - Interest rate: {item.Key.savingsInterest}");
                    }
                    else if (item.Value.Equals(user) && item.Key.accType == "currency")
                    {
                        Console.WriteLine($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance} - Currency: {item.Key.currency}");
                    }
                }
                Console.WriteLine("Select account:");
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
                    Console.WriteLine("the account you typed in do not exist, please try again: ");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    SetBalance();
                }
                Console.WriteLine("How much do you want to transfer?: ");
                try
                {
                    amount = float.Parse(Console.ReadLine());
                    if (amount > 0)
                    {

                    }
                    else
                    {
                        Console.WriteLine("you cant set 0 or a negaative balance");
                        Console.WriteLine("press any ket to continue");
                        Console.ReadKey();
                        Console.Clear();
                        SetBalance();
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("You have to type in the amount with numbers 0-9 only");
                    Console.WriteLine("Restarting set balance function: \nPress any key to continue ");
                    Console.ReadKey();
                    SetBalance();
                    throw;
                }
                foreach (var item in AccountManager.accountList)
                {
                    if (item.Value.Equals(user) && item.Key.accountNum == accNum)
                    {
                        item.Key.balance = amount;
                        AccountManager.accountHistory.Add(new KeyValuePair<string, string>(accNum, $"{amount} received - {DateTime.Now.ToString("g")}"));
                    }
                }

                Console.WriteLine("Balance set. Press enter to continue.");
                Console.ReadKey();
                Console.Clear();
                Run();
            }

        }
        public static void UppdateExchangeRate()
        {
            float exchangeRate = 0;
            string currency = null;
            bool currencyExist = false;

            Console.WriteLine("USD, EUR, DKK");
            Console.WriteLine("Type the name of the currency you want to uppdate: ");
            currency = Console.ReadLine();
            if (currency == "USD" || currency == "usd" || currency == "EUR" || currency == "eur" || currency == "DKK" || currency == "dkk")
            {
                Console.WriteLine("Currency chosen: ");
                currencyExist = true;
            }
            else
            {
                Console.WriteLine("You chose a non-viable currency. Try again: ");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
                Run();
            }
            Console.WriteLine("Type the value of the currency you want to uppdate in this format 0,000: ");

            try
            {
                exchangeRate = float.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("when setting value you can only use numbers 0-9.");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
                UppdateExchangeRate();
                throw;
            }
            AccountManager.ExchangeRate.Remove(currency);
            AccountManager.ExchangeRate.Add(currency, exchangeRate);
            Console.WriteLine("Currency set, press any key to continue");
            Console.ReadKey();
            Console.Clear();
            Run();
        }
    }
}
