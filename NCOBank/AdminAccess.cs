using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    internal class AdminAccess
    {
        public static void Run()
        {
            Console.WriteLine("1. Add user");
            Console.WriteLine("2. Unlock user");
            Console.WriteLine("3. Log out");
            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    AddUser();
                    break;
                case "2":
                    UnlockUser();
                    break;
                case "3":
                    Console.Clear();
                    BankMenu.Run();
                    break;
            }
        }
        public static void AddUser()
        {
            Console.WriteLine("State username:");
            string username = Console.ReadLine();
            Console.WriteLine("State password");
            string password = Console.ReadLine();

            BankMenu.userList.Add(new User(username, password));

            Console.WriteLine("User successfully added. Press enter to continue");
            Console.ReadLine();
            Console.Clear();
            Run();
        }
        public static void UnlockUser()
        {
            BankMenu.lockedOut = false;
            Console.WriteLine("Login lock removed. Press enter to continue");
            Console.ReadLine();
            Console.Clear();
            Run();
        }
    }
}
