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
            Console.WriteLine("From which account do you transfer from");
            string accSend = Console.ReadLine();
            Console.WriteLine("To which account do you want to make the transfer to?");
            string accRecieve = Console.ReadLine();
            Console.WriteLine("Select the amount you want to transfer");
            float amount = float.Parse(Console.ReadLine());

            foreach (var item in AccountManager.personalAccList) // User can transfer funds from other users accounts to himself (fix)
            {
                if (item.Key.accountNum == accSend)
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

            if(acc1Exists && acc2Exists) // User can once again steal money from other users if amount is negative (fix)
            {
                account1.balance -= amount;
                account2.balance += amount;
            }

            Console.WriteLine("Transfer complete. Press enter to continue.");
            Console.ReadLine();
            Console.Clear();
            Run(user);
        }
    }
}
