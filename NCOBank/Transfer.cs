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
            string selection = null;
            TextMessages.YellowMessageColor("Please select one of the following options:");
            TextMessages.YellowMessageColor("1. Transfer amount between acccounts");
            TextMessages.YellowMessageColor("2. Transfer to currency account");
            TextMessages.YellowMessageColor("3. Previous menu");

            do
            {
                selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        Console.Clear();
                        TransferAmount(user);
                        break;
                    case "2":
                        Console.Clear();
                        TransferForeignCurrency(user);
                        break;
                    case "3":
                        Console.Clear();
                        AccountManager.Run(user);
                        break;
                }
                TextMessages.MessageColor("Please enter a valid option", false);
            } while (true);
            
        }
        public static void TransferAmount(User user)
        {
            bool acc1Exists = false;
            bool acc2Exists = false;
            bool a = true;
            string accSend = null;
            string accRecieve = null;
            float amount;
            Account account1 = null;
            Account account2 = null;
            
            foreach (var item in AccountManager.accountList)
            {
                if (item.Value.Equals(user) && item.Key.accType == "personal")
                {
                    TextMessages.YellowMessageColor($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance}");
                }
                else if (item.Value.Equals(user) && item.Key.accType == "savings")
                {
                    TextMessages.YellowMessageColor($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance} - Interest rate: {item.Key.savingsInterest}");
                }
            }
            TextMessages.YellowMessageColor("From which account do you want to transfer from");
            accSend = Console.ReadLine();
            TextMessages.YellowMessageColor("To which account do you want to make the transfer to?");
            accRecieve = Console.ReadLine();
            try
            {
                TextMessages.YellowMessageColor("Select the amount you want to transfer");
                amount = float.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                TextMessages.MessageColor("Please enter numbers only", false);
                TextMessages.PressEnter();
                TransferAmount(user);
                throw;
            }

            foreach (var item in AccountManager.accountList) 
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
                TextMessages.MessageColor("Transfer complete");
                TextMessages.PressEnter();
                Run(user);
            }
            else if (!acc1Exists)
            {
                TextMessages.MessageColor("Error! Your account could not be found or does not have enough coverage. Please try again.", false);
                TextMessages.PressEnter();
                AccountManager.Run(user);
            }
            else if (!acc2Exists)
            {
                TextMessages.MessageColor("Error! The account you entered could not be found. Please try again.", false);
                TextMessages.PressEnter();
                AccountManager.Run(user);
            }
            else if (amount <= 0)
            {
                TextMessages.MessageColor("The amount can not be zero or negative. Please try again.", false);
                TextMessages.PressEnter();
                AccountManager.Run(user);
            }
            Console.ReadLine();
            Console.Clear();
            Run(user);
        }
        public static void TransferForeignCurrency (User user)
        {
            float amount;
            string accountSend;
            string accountRecieve;
            Account accSend = null;
            Account accRecieve = null;
            bool accountRecieveExist = false;
            bool accountSendExist = false;
            try
            {
                if (!AccountManager.ExchangeRate.ContainsKey("USD"))
                {
                    AccountManager.ExchangeRate.Add("USD", 0.096f);
                }
                else if (!AccountManager.ExchangeRate.ContainsKey("EUR"))
                {
                    AccountManager.ExchangeRate.Add("EUR", 0.093f);
                }
                else if (!AccountManager.ExchangeRate.ContainsKey("DKK"))
                {
                    AccountManager.ExchangeRate.Add("DKK", 0.069f);
                }
            }
            catch (Exception)
            {
                AccountManager.ExchangeRate.Remove("currency");
                throw;
            }
    
            foreach (var item in AccountManager.accountList)
            {
                if (item.Value.Equals(user) && item.Key.accType == "personal")
                {
                    TextMessages.YellowMessageColor($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance}");
                }
                else if (item.Value.Equals(user) && item.Key.accType == "savings")
                {
                    TextMessages.YellowMessageColor($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance} - Interest rate: {item.Key.savingsInterest}");
                }
                else if (item.Value.Equals(user) && item.Key.accType == "currency")
                {
                    TextMessages.YellowMessageColor($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance} - Currency: {item.Key.currency}");
                }
            }
            TextMessages.YellowMessageColor("From which account would you like to send from? ");
            accountSend = Console.ReadLine();
            TextMessages.YellowMessageColor("To which account woul you like to make the transfer to?");
            accountRecieve = Console.ReadLine();
            TextMessages.YellowMessageColor("How much would you like to transfer? ");
            try
            {
                amount = float.Parse(Console.ReadLine());

            }
            catch (Exception)
            {
                TextMessages.MessageColor("Please enter numbers only", false);
                TextMessages.PressEnter();
                TransferForeignCurrency(user);
                throw;
            }

            foreach (var item in AccountManager.accountList)
            {
                if (item.Value.Equals(user) && item.Key.accountNum == accountSend && item.Key.balance > amount)
                {
                    accSend = item.Key;
                    accountSendExist = true;
                }
            }

            foreach (var item in AccountManager.accountList)
            {
                if (item.Value.Equals(user) && accountRecieve == item.Key.accountNum && item.Key.accType == "currency")
                {
                    if (item.Key.currency == "USD")
                    {
                        accountRecieveExist = true;
                        accRecieve = item.Key;

                    } else if (item.Key.currency == "EUR")
                    {

                        item.Key.balance += amount * AccountManager.ExchangeRate["EUR"];

                        

                    } else if (item.Key.currency == "DKK")
                    {

                        item.Key.balance += amount * AccountManager.ExchangeRate["DKK"];
                    }

                } 

            }
            if (accountSendExist && accountRecieveExist)
            {
                if (accRecieve.currency == "USD" && accSend.balance > 0)
                {
                    accSend.balance -= amount;
                    accRecieve.balance += amount * AccountManager.ExchangeRate["USD"];
                }
                else if (accRecieve.currency == "EUR")
                {
                    accSend.balance -= amount;
                    accRecieve.balance += amount * AccountManager.ExchangeRate["EUR"];
                }
                else if (accRecieve.currency == "DKK")
                {                    
                    accSend.balance -= amount;
                    accRecieve.balance += amount * AccountManager.ExchangeRate["DKK"];

                }
            }
            else
            {
                TextMessages.MessageColor("One or both of the accounts was not found or did not have enough coverage, please try again", false);
                TextMessages.YellowMessageColor("Press 1 to restart the transfer. \nPress 2 for returning to main menu ");
                do
                {
                    string i = Console.ReadLine();
                    switch (i)
                    {
                        case "1":
                            Console.Clear();
                            TransferForeignCurrency(user);
                            break;
                        case "2":
                            Console.Clear();
                            AccountManager.Run(user);
                            break;
                    }
                    TextMessages.MessageColor("Incorrect input. Press 1 for transfer, 2 for Main menu", false);

                } while (true);
            }
            AccountManager.accountHistory.Add(new KeyValuePair<string, string>(accSend.accountNum, $"Transfered amount: {amount} to account: {accRecieve.accountNum} - {DateTime.Now.ToString("g")}"));
            AccountManager.accountHistory.Add(new KeyValuePair<string, string>(accRecieve.accountNum, $"Recieved amount: {amount} SEK from account: {accSend.accountNum} - {DateTime.Now.ToString("g")}"));
            TextMessages.MessageColor("Transfer complete");
            TextMessages.PressEnter();
            Run(user);
        }
    }
}
