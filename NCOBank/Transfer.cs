﻿using System;
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
            Console.WriteLine("Please select one of the following options:");
            Console.WriteLine("1. Transfer amount between acccounts");
            Console.WriteLine("2. Transfer to currency account");
            Console.WriteLine("3. Previous menu");

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
                Console.WriteLine("Please enter a valid option");
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
                    Console.WriteLine($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance}");
                }
                else if (item.Value.Equals(user) && item.Key.accType == "savings")
                {
                    Console.WriteLine($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance} - Interest rate: {item.Key.savingsInterest}");
                }
            }
            Console.WriteLine("From which account do you want to transfer from");
            accSend = Console.ReadLine();
            Console.WriteLine("To which account do you want to make the transfer to?");
            accRecieve = Console.ReadLine();
            try
            {
                Console.WriteLine("Select the amount you want to transfer");
                amount = float.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter numbers only");
                Console.WriteLine("Restarting the transfer \nPress a key to continue");
                Console.ReadLine();
                Console.Clear();
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
                Console.WriteLine("Transfer complete. Press enter to continue.");
                Console.ReadLine();
                Console.Clear();
                Run(user);
            }
            else if (!acc1Exists)
            {
                Console.WriteLine("Error! Your account could not be found or does not have enough coverage. Please try again.");
                Console.WriteLine("Sending you back to the menu \nPress a key to continue");
                Console.ReadLine();
                Console.Clear();
                AccountManager.Run(user);
            }
            else if (!acc2Exists)
            {
                Console.WriteLine("Error! The account you entered could not be found. Please try again.");
                Console.WriteLine("Sending you back to the menu \nPress a key to continue");
                Console.ReadLine();
                Console.Clear();
                AccountManager.Run(user);
            }
            else if (amount <= 0)
            {
                Console.WriteLine("The amount can not be zero or negative. Please try again.");
                Console.WriteLine("Sending you back to the menu \nPress a key to continue");
                Console.ReadLine();
                Console.Clear();
                AccountManager.Run(user);
            }
            Console.ReadLine();
            Console.Clear();
            Run(user);
        }
        public static void TransferForeignCurrency(User user)
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

            foreach (var item in AccountManager.accountList)
            {
                if (item.Value.Equals(user) && item.Key.accType == "personal")
                {
                    Console.WriteLine($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance}");
                }
                else if (item.Value.Equals(user) && item.Key.accType == "savings")
                {
                    Console.WriteLine($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance} - Interest rate: {item.Key.savingsInterest}");
                }
                else if (item.Value.Equals(user) && item.Key.accType == "currency")
                {
                    Console.WriteLine($"Account nr: {item.Key.accountNum} - Balance: {item.Key.balance} - Currency: {item.Key.currency}");
                }
            }
            Console.WriteLine("From which account would you like to send from? ");
            accountSend = Console.ReadLine();
            Console.WriteLine("To which account woul you like to make the transfer to?");
            accountRecieve = Console.ReadLine();
            Console.WriteLine("How much would you like to transfer? ");
            try
            {
                amount = float.Parse(Console.ReadLine());

            }
            catch (Exception)
            {
                Console.WriteLine("Please enter numbers only");
                Console.WriteLine("Restarting the transfer. \nPress a key to continue");
                Console.ReadLine();
                Console.Clear();
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
                    accRecieve = item.Key;
                    accountRecieveExist = true;


                }

            }
            if (accountSendExist && accountRecieveExist)
            {
                if (accRecieve.currency == "USD" && accSend.balance > 0)
                {
                    accSend.balance -= amount;
                    accRecieve.balance += amount * AccountManager.ExchangeRate["USD"];
                }
                else if (accRecieve.currency == "EUR" && accSend.balance > 0)
                {
                    accSend.balance -= amount;
                    accRecieve.balance += amount * AccountManager.ExchangeRate["EUR"];
                }
                else if (accRecieve.currency == "DKK" && accSend.balance > 0)
                {
                    accSend.balance -= amount;
                    accRecieve.balance += amount * AccountManager.ExchangeRate["DKK"];

                }
            }
            else
            {
                Console.WriteLine("One or both of the accounts was not found or did not have enough coverage, please try again");
                Console.WriteLine("Press 1 to restart the transfer. \nPress 2 for returning to main menu ");
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
                    Console.WriteLine("Incorrect input. Press 1 for transfer, 2 for Main menu");

                } while (true);
            }
            AccountManager.accountHistory.Add(new KeyValuePair<string, string>(accSend.accountNum, $"Transfered amount: {amount} to account: {accRecieve.accountNum} - {DateTime.Now.ToString("g")}"));
            AccountManager.accountHistory.Add(new KeyValuePair<string, string>(accRecieve.accountNum, $"Recieved amount: {amount} SEK from account: {accSend.accountNum} - {DateTime.Now.ToString("g")}"));
            Console.WriteLine("Transfer complete");
            Console.ReadLine();
            Console.Clear();
            Run(user);
        }
    }
}
