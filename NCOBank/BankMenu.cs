using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    internal class BankMenu
    {
        public static List<Admin> adminList = new List<Admin>();
        public static List<User> userList = new List<User>();
        public static Dictionary<int, int> accList = new Dictionary<int, int>();
        public static bool lockedOut = false;
        public static void Run()
        {
            Console.WriteLine("Welcome to the NCO Bank!");
            Console.WriteLine("Please select one of the following options:");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Create account");
            Console.WriteLine("3. Admin access (admin only)");
            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    BankMenu.Login();
                    break;
                case "2":
                    BankMenu.CreateAccount();
                    break;
                case "3":
                    Console.Clear();
                    BankMenu.AdminLogin();
                    break;
                default:
                    Console.WriteLine("Please input your choice using only numbers");
                    break;
            }
        }
        public static void Login()
        {
            CreateUser.LoginUser();
        }
        public static void AdminLogin()
        {
            CreateUser.NewAdmin();
        }
        public static void CreateAccount()
        {
            CreateUser.NewUser();
        }
        public static void BankAccounts()
        {
            CreateBankAccount.Run();
            AccountManager.Run();
        }
        public static void CheckBalance()
        {
            foreach (var item in accList)
            {
                Console.WriteLine($"Account {item.Key} \nBalance: {item.Value}");
                Console.WriteLine("*************************************");
            }
        }
    }
}
