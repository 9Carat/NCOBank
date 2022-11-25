using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    public class AccountManager
    {
        public static List<KeyValuePair<string, string>> accountHistory = new List<KeyValuePair<string, string>>();
        public static Dictionary<Account, User> accountList = new Dictionary<Account, User>();
        public static Dictionary<string, float> ExchangeRate = new Dictionary<string, float>();
        
        public static void Run(User user)
        {
            try
            {
                if (!AccountManager.ExchangeRate.ContainsKey("USD"))
                {
                    AccountManager.ExchangeRate.Add("USD", 0.096f);
                }
                if (!AccountManager.ExchangeRate.ContainsKey("EUR"))
                {
                    AccountManager.ExchangeRate.Add("EUR", 0.093f);
                }
                if (!AccountManager.ExchangeRate.ContainsKey("DKK"))
                {
                    AccountManager.ExchangeRate.Add("DKK", 0.069f);
                }
            }
            catch (Exception)
            {
                AccountManager.ExchangeRate.Remove("currency");
                throw;
            }
            string selection;
            do
            {
                TextColor.MessageColor($"Welcome \"{user.FirstName} {user.LastName}\". Please select an option to continue");
                TextColor.YellowMessageColor("1. Create a personal, savings or currency account");
                TextColor.YellowMessageColor("2. View your current accounts and their balances");
                TextColor.YellowMessageColor("3. Transfer amount to other accounts");
                TextColor.YellowMessageColor("4. Apply for loan");
                TextColor.YellowMessageColor("0. Log out");
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
                        TextColor.MessageColor("Please input your choice using the correct number.", false);
                        TextColor.PressEnter();
                        break;
                }
            }
            while (selection != "0");
        }
    }
}
