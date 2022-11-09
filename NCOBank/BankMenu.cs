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
                    Login();
                    break;
                case "2":
                    CreateAccount();
                    break;
                case "3":
                    Console.Clear();
                    AdminLogin();
                    break;
                default:
                    Console.WriteLine("Please input your choice using only numbers");
                    break;
            }
        }
        public static void Login()
        {
            int attempts = 0;
            bool verifiedUser = false;

            if (lockedOut == false)
            {
                do
                {
                    Console.WriteLine("Please enter your username");
                    string enteredUser = Console.ReadLine();

                    Console.WriteLine("Please enter your password");
                    string enteredPassword = Console.ReadLine();

                    User existingUser = userList.Find(u => u.Username.Contains(enteredUser));
                    User existingPassword = userList.Find(u => u.Password.Contains(enteredPassword));

                    if (existingUser == null || existingPassword == null || existingUser != existingPassword)
                    {
                        Console.WriteLine("Username or password is incorrect. Please try again. You have {0} attempts left.", 2 - attempts);
                        attempts++;
                    }
                    else if (existingUser != null && existingPassword != null && existingUser == existingPassword)
                    {
                        Console.WriteLine("Login sucessful!");
                        verifiedUser = true;
                        break;
                    }
                }
                while (attempts < 3);
            }

            if (verifiedUser == false)
            {
                lockedOut = true;
                Console.WriteLine("You've been locked out! Please contact an admin. Press enter to continue");
                Console.ReadLine();
                Console.Clear();
                Run();
            }
            else
            {
                Console.Clear();
                AccountManager.Run();
            }
        }
        public static void AdminLogin()
        {
            //Creates an admin account if one has not yet been created
            if (adminList.Count == 0)
            {
                adminList.Add(new Admin("admin", "admin"));
            }

            Console.WriteLine("Enter username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password");
            string password = Console.ReadLine();

            Admin existingUser = adminList.Find(a => a.Username.Contains(username));
            Admin existingPassword = adminList.Find(a => a.Password.Contains(password));

            if (existingUser == null || existingPassword == null || existingUser != existingPassword)
            {
                Console.WriteLine("Username or password is incorrect. Press enter to continue.");
                Console.ReadLine();
                Console.Clear();
                Run();
            }
            else if (existingUser != null && existingPassword != null && existingUser == existingPassword)
            {
                Console.WriteLine("Login sucessful! Press enter to continue");
                Console.ReadLine();
                Console.Clear();
                AdminAccess.Run();
            }
        }
        public static void CreateAccount()
        {
            Console.WriteLine("Please enter your social security number(yyyymmdd-xxxx). This will be your username.");
            string newUsername = Console.ReadLine();
            Console.WriteLine("Please enter your new password");
            string newPassword = Console.ReadLine();

            userList.Add(new User(newUsername,newPassword));

            Console.WriteLine("User successfully created!");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
            Run();
        }
    }
}
