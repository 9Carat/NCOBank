using System;
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
            Console.WriteLine("2. Previous menu");
            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    Console.Clear();
                    CreatePersonalAcc(user);
                    break;
                case "2":
                    Console.Clear();
                    AccountManager.Run(user);
                    break;
            }
        }
        public static void CreatePersonalAcc(User user)
        {
            Console.WriteLine("Choose an account number (10 digits)");
            string accNum = Console.ReadLine();
            Console.WriteLine("Choose your balance");
            float balance = float.Parse(Console.ReadLine());

            AccountManager.personalAccList.Add(new PersonalAccount(accNum, balance), user); // stores the account in the dictionary
            AccountManager.accountHistory.Add(new KeyValuePair<string, string>(accNum, $"Account created - {DateTime.Now.ToString("g")}")); // logs the creation of the account

            Console.WriteLine("Personal account successfully created. Press enter to continue.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
