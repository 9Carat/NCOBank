using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    internal class CreateUser
    {
        public static void NewUser()
        {
            Console.WriteLine("Please enter your social security number(yyyymmdd-xxxx). This will be your username.");
            string newUsername = Console.ReadLine();
            Console.WriteLine("Please enter your new password");
            string newPassword = Console.ReadLine();

            BankMenu.userList.Add(new User(newUsername, newPassword));

            Console.WriteLine("User successfully created!");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
            BankMenu.Run();
        }
        public static void LoginUser()
        {
            int attempts = 0;
            bool verifiedUser = false;

            if (BankMenu.lockedOut == false)
            {
                do
                {
                    Console.WriteLine("Please enter your username");
                    string enteredUser = Console.ReadLine();

                    Console.WriteLine("Please enter your password");
                    string enteredPassword = Console.ReadLine();

                    User existingUser = BankMenu.userList.Find(u => u.Username.Contains(enteredUser));
                    User existingPassword = BankMenu.userList.Find(u => u.Password.Contains(enteredPassword));

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
                BankMenu.lockedOut = true;
                Console.WriteLine("You've been locked out! Please contact an admin. Press enter to continue");
                Console.ReadLine();
                Console.Clear();
                BankMenu.Run();
            }
            else
            {
                Console.Clear();
                AccountManager.Run();
            }
        }
        public static void NewAdmin()
        {
            //Creates an admin account if one has not yet been created
            if (BankMenu.adminList.Count == 0)
            {
                BankMenu.adminList.Add(new Admin("admin", "admin"));
            }

            Console.WriteLine("Enter username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password");
            string password = Console.ReadLine();

            Admin existingUser = BankMenu.adminList.Find(a => a.Username.Contains(username));
            Admin existingPassword = BankMenu.adminList.Find(a => a.Password.Contains(password));

            if (existingUser == null || existingPassword == null || existingUser != existingPassword)
            {
                Console.WriteLine("Username or password is incorrect. Press enter to continue.");
                Console.ReadLine();
                Console.Clear();
                BankMenu.Run();
            }
            else if (existingUser != null && existingPassword != null && existingUser == existingPassword)
            {
                Console.WriteLine("Login sucessful! Press enter to continue");
                Console.ReadLine();
                Console.Clear();
                AdminAccess.Run();
            }
        }
    }
}
