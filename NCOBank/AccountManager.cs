using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    public class AccountManager
    {

        public static Dictionary<Loan, User> loanList = new Dictionary<Loan, User>();
        public static List<KeyValuePair<string, string>> accountHistory = new List<KeyValuePair<string, string>>();
        public static Dictionary<Account, User> accountList = new Dictionary<Account, User>();
        public static Dictionary<string, float> ExchangeRate = new Dictionary<string, float>();


        public static void Run(User user)
        {
            string selection;
            do
            {
                TextMessages.MessageColor($"Welcome \"{user.FirstName} {user.LastName}\". Please select an option to continue");
                TextMessages.YellowMessageColor("1. Create a personal, savings or currency account");
                TextMessages.YellowMessageColor("2. View your current accounts and their balances");
                TextMessages.YellowMessageColor("3. Transfer amount to other accounts");
                TextMessages.YellowMessageColor("4. Apply for loan");
                TextMessages.YellowMessageColor("0. Log out");
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
                    default:
                        TextMessages.MessageColor("Please input your choice using the correct number.", false);
                        TextMessages.PressEnter();
                        break;
                }
            }
            while (selection != "0");
        }
    }
}
