using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    public class AccountManager
    {
        public static Dictionary<PersonalAccount, User> personalAccList = new Dictionary<PersonalAccount, User>();
        public static Dictionary<SavingsAccount, User> savingsAccList = new Dictionary<SavingsAccount, User>();
        public static Dictionary<Loan, User> loanList = new Dictionary<Loan, User>();
        //public static Dictionary<CurrencyAccount, User> currencyAccList = new Dictionary<CurrencyAccount, User>();
        public static List<KeyValuePair<string, string>> accountHistory = new List<KeyValuePair<string, string>>();


        public static void Run(User user)
        {
            string selection;
            do
            {
                Console.WriteLine("Welcome \"user\". Please select an option to continue");
                Console.WriteLine("1. Create a personal, savings or currency account");
                Console.WriteLine("2. View your current accounts and their balances");
                Console.WriteLine("3. Transfer amount to other accounts");
                Console.WriteLine("4. Apply for loan");
                Console.WriteLine("0. Log out");
                selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        Console.Clear();
                        CreateAccount.Run(user);
                        break;
                    case "2":
                        Console.Clear();
                        DisplayAccounts.Run(user);
                        break;
                    case "3":
                        Console.Clear();
                        Transfer.Run(user);
                        break;
                    case "4":
                        Loan.Run(user);
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
