using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    public class Transfer
    {
        public static void Run(User user)
        {
            Console.WriteLine("Please select one of the following options:");
            Console.WriteLine("1. Transfer amount between acccounts");
            Console.WriteLine("2. Previous menu");
            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    TransferAmmount(user);
                    break;
                case "2":
                    AccountManager.Run(user);
                    break;
            }
        }
        public static void TransferAmmount(User user)
        {
            bool acc1Exists = false;
            bool acc2Exists = false;
            Account account1 = null;
            Account account2 = null;
            Console.WriteLine("From which account do you want to transfer from");
            string accSend = Console.ReadLine();
            Console.WriteLine("To which account do you want to make the transfer to?");
            string accRecieve = Console.ReadLine();
            Console.WriteLine("Select the amount you want to transfer");
            float amount = float.Parse(Console.ReadLine());

            foreach (var item in AccountManager.personalAccList) 
            {
                if (item.Key.accountNum == accSend && item.Key.balance > amount && item.Value.Equals(user)) // Checks if sending acc exists, belongs to the user and has enough coverage
                {
                    acc1Exists = true;
                    account1 = item.Key;
                }
               
                else if (item.Key.accountNum == accRecieve)
                {
                    acc2Exists = true;
                    account2 = item.Key;
                }
            }

            if (acc1Exists && acc2Exists && amount > 0) // Goes through with the transfer if both acc exists, sendingacc belongs to user, if amount is positive and acc balance > amount
            {
                account1.balance -= amount;
                account2.balance += amount;
                AccountManager.accountHistory.Add(new KeyValuePair<string, string>(account1.accountNum, $"Transfered amount: {amount} to account: {account2.accountNum} - {DateTime.Now.ToString("g")}")); // Logs the transaction on both accounts
                AccountManager.accountHistory.Add(new KeyValuePair<string, string>(account2.accountNum, $"Recieved amount: {amount} from account: {account1.accountNum} - {DateTime.Now.ToString("g")}"));
                Console.WriteLine("Transfer complete. Press enter to continue.");
                Console.ReadLine();
                Console.Clear();
                Run(user);
            }
            else if (!acc1Exists)
            {
                Console.WriteLine("Error! Your account could not be found or does not have enough coverage. Please try again.");
            }
            else if (!acc2Exists)
            {
                Console.WriteLine("Error! The account you entered could not be found. Please try again.");
            }
            else if (amount <= 0)
            {
                Console.WriteLine("The amount can not be zero or negative. Please try again.");
            }
            Console.ReadLine();
            Console.Clear();
            Run(user);
        }
    }
}
