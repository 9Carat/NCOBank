using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    internal class AdminAccess
    {
        public static void Run()
        {
            Console.WriteLine("1. Add user");
            Console.WriteLine("2. Unlock user");
            Console.WriteLine("3. Set account balance");
            Console.WriteLine("0. Log out");
            string selection = Console.ReadLine();

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
                case "0":
                    Console.Clear();
                    BankMenu.Run();
                    break;
            }
        }
        public static void AddUser()
        {
            Console.WriteLine("State username:");
            string username = Console.ReadLine();
            Console.WriteLine("State password");
            string password = Console.ReadLine();

            BankMenu.userList.Add(new User(username, password));

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
            Console.WriteLine("Select user:");
            string username = Console.ReadLine();
            User user = null;

            foreach(var item in BankMenu.userList)
            {
                if(item.Username == username)
                {
                    user = item;
                    break;
                }
            }

            if(user == null)
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
                string accNum = Console.ReadLine();
                Console.WriteLine("Select balance:");
                float amount = float.Parse(Console.ReadLine());

                foreach (var item in AccountManager.accountList)
                {
                    if (item.Value.Equals(user) && item.Key.accountNum == accNum)
                    {
                        item.Key.balance = amount;
                        AccountManager.accountHistory.Add(new KeyValuePair<string, string>(accNum, $"{amount} received - {DateTime.Now.ToString("g")}"));
                    }
                }
               
                Console.WriteLine("Balance set. Press enter to continue.");
                Console.ReadLine();
                Console.Clear();
                Run();
            }
        }
    }
}
