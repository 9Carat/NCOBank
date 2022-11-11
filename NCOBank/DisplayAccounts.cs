using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    internal class DisplayAccounts
    {
        public static void Run(User user)
        {
            Console.WriteLine("Please select one of the following options:");
            Console.WriteLine("1. Display your accounts");
            Console.WriteLine("2. Previous menu");
            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    Console.Clear();
                    Display(user);
                    break;
                case "2":
                    Console.Clear();
                    AccountManager.Run(user);
                    break;
            }
        }
        public static void Display(User user)
        {
            Console.WriteLine("You currently have the following accounts:");
            
            foreach(var item in AccountManager.personalAccList)
            {
                if (item.Value.Equals(user))
                {
                    Console.WriteLine($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance}");
                }
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
            Run(user);
        }
    }
}
