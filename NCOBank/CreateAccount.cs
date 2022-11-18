using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    internal class CreateAccount
    {
        private static string accNum;
        public string MyProperty { get; set; }
        public static void Run(User user)
        {
            Console.WriteLine("Please select one of the following options:");
            Console.WriteLine("1. Create a personal account");
            Console.WriteLine("2. Create a savings account" + " - " + SavingsAccount.DisplayInterest());
            Console.WriteLine("3. Create a new currency account");
            Console.WriteLine("3. Previous menu");
            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    Console.Clear();
                    CreatePersonalAcc(user);
                    break;
                case "2":
                    Console.Clear();
                    CreateSavingsAcc(user);
                    break; 
                case "3":
                    Console.Clear();
                    CreateForeignCurrencyAcc(user);
                    break;
                case "4":
                    Console.Clear();
                    AccountManager.Run(user);
                    break;
            }
        }
        public static void CreatePersonalAcc(User user)
        {
            AccountManager.accountList.Add(new PersonalAccount(), user); // stores the account in the dictionary

            foreach (var item in AccountManager.accountList)
            {
                if (item.Value.Equals(user))
                {
                     accNum = item.Key.accountNum;
                }
            }
            AccountManager.accountHistory.Add(new KeyValuePair<string, string>(accNum, $"Account created - {DateTime.Now.ToString("g")}")); // logs the creation of the account
            Console.WriteLine($"Personal account {accNum} successfully created. Press enter to continue.");
            Console.ReadLine();
            Console.Clear();
        }
        public static void CreateSavingsAcc(User user)
        {
            AccountManager.accountList.Add(new SavingsAccount(), user);

            foreach (var item in AccountManager.accountList)
            {
                if (item.Value.Equals(user))
                {
                    accNum = item.Key.accountNum;
                }
            }
            AccountManager.accountHistory.Add(new KeyValuePair<string, string>(accNum, $"Account created - {DateTime.Now.ToString("g")}"));
            Console.WriteLine($"Savings account {accNum} successfully created. Press enter to continue.");
            Console.ReadLine();
            Console.Clear();
        }
        public static void CreateForeignCurrencyAcc(User user)
        {

            string Currency;

            Console.WriteLine("USD, EUR, DKK");
            Console.WriteLine("what currency would you like to create your account in");
            Currency = Console.ReadLine();
            AccountManager.accountList.Add(new CurrencyAccount(Currency), user); // stores the account in the dictionary
            foreach (var item in AccountManager.accountList)
            {
                if (item.Value.Equals(user))
                {
                    accNum = item.Key.accountNum;
                }
            }
            AccountManager.accountHistory.Add(new KeyValuePair<string, string>(accNum, $"Account created - {DateTime.Now.ToString("g")}")); // logs the creation of the account
            Console.WriteLine($"Personal account {accNum} successfully created. Press enter to continue.");
            Console.ReadLine();
            Console.Clear();

           
        }
        public static string RndAccNum()
        {
            Random rnd = new Random();
            HashSet<int> accNum = new HashSet<int>();
            while (accNum.Count < 10)
            {
                accNum.Add(rnd.Next(1000000000, 2000000000));
            }
            int randomAccNumber = accNum.First();
            randomAccNumber.ToString();
            return String.Format("{0:000 000 000-0}", randomAccNumber);
        }
    }
}
