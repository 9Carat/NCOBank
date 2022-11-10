using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    internal class AccountManager
    {
        public Dictionary<string, int> accountList = new Dictionary<string, int>();

        public static void Run()
        {
            string selection;
            do
            {
                Console.WriteLine("Welcome \"user\". Please select an option to continue");
                Console.WriteLine("1. Create a personal or savings account");
                Console.WriteLine("2. View your current accounts and their balances");
                Console.WriteLine("3. Transfer amount to other accounts");
                Console.WriteLine("4. Apply for loan");
                Console.WriteLine("0. Log out");
                selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        BankMenu.BankAccounts();
                        break;
                    case "2":
                        BankMenu.CheckBalance();
                        break;
                    case "3":
                        Transfer.Run();
                        break;
                    case "4":
                        Loan.Run();
                        break;
                    case "0":
                        Console.Clear();
                        BankMenu.Run();
                        break;
                }
            }
            while (selection != "0");
        }
    }
}
