using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    internal class UserFunctions
    {
        public static Dictionary<string, decimal> dict = new Dictionary<string, decimal>();
        public static List<user> userList = new List<user>();

        internal static void BankAccount()
        {
            int Leave = 1;

            decimal InsertMoney;

            Console.WriteLine("Hej och välkommen till dina bankkonton");
            Console.WriteLine("Skapa konto tryck 1: \nVisa dina konton, tryck 2: \nGå tillbaka till Usermeny tryck 3: \nGå tillbaka till meny tryck 5: ");
            int choice;
            int.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    CreateAccount();
                    break;
                case 2:
                    DisplayAccounts();
                    break;
                case 5:
                    UserMenu.UsersMenu();
                    break;

            }

            void CreateAccount()
            {
                while (Leave != null)
                {
                    if (Leave == 1)
                    {
                        Console.WriteLine("Skriv kontonamn: ");
                        string AccountName = Console.ReadLine();
                        Console.WriteLine("Vänligen fyll in hur mycket kronor du vill sätta in på kontot: ");
                        decimal.TryParse(Console.ReadLine(), out InsertMoney);
                        dict.Add(AccountName, InsertMoney);

                        AccountName = null;
                        InsertMoney = 0;
                        Console.WriteLine("skapa nytt konto tryck 1, om du vill lämna tryck 5: ");
                        int.TryParse(Console.ReadLine(), out Leave);
                    }
                    else
                    {
                        BankAccount();

                    }
                }

            }
            void DisplayAccounts()
            {
                int choice;
                string[] Currency = { "Kr", "Eur", "DKK", "USD" };

                foreach (KeyValuePair<string, decimal> kvp in dict)
                {
                    Console.WriteLine($"Kontonamn: {kvp.Key}: Account Pengar: {kvp.Value}\n");
                }

                CurrencyExchange();
                Console.Clear();

                void CurrencyExchange()
                {

                    Console.WriteLine("Välj vilken valuta du vill föra över till: ");
                    foreach (var cur in Currency)
                    {
                        Console.WriteLine(cur);
                    }
                    Console.WriteLine(" 1 för sek till USD");
                    int.TryParse(Console.ReadLine(), out choice);
                    switch (choice)
                    {
                        case 1:
                            SektoUSD();
                            break;


                    }
                    static void SektoUSD()
                    {
                        decimal Sek;
                        dict = dict.ToDictionary(kvp => kvp.Key, kvp => kvp.Value / 11);

                    }
                }
                void BindCurrency()
                {
                    DataTable dtCurrency = new DataTable();
                    dtCurrency.Columns.Add("text");
                    dtCurrency.Columns.Add("Value");

                    dtCurrency.Rows.Add("Select", 0);
                    dtCurrency.Rows.Add("USD", 11);
                    dtCurrency.Rows.Add("EUR", 10);
                    dtCurrency.Rows.Add("SEK", 0);
                    dtCurrency.Rows.Add("DKK", 5);
                    DisplayAccounts();
                }
            }


        }
    }
}
