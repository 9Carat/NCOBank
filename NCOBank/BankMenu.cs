using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    public class BankMenu
    {
        public static List<Admin> adminList = new List<Admin>();
        public static List<User> userList = new List<User>();
        public static bool lockedOut = false;

        public static void Run()
        {
            string selection;
            do
            {
                TextMessages.BankLogo();
                TextMessages.YellowMessageColor("Welcome to the NCO Bank!");
                TextMessages.YellowMessageColor("Please select one of the following options:");
                TextMessages.YellowMessageColor("1. Login");
                TextMessages.YellowMessageColor("2. Create account");
                TextMessages.YellowMessageColor("3. Admin access (admin only)");
                TextMessages.YellowMessageColor("4. Exit");
                selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        Console.Clear();
                        Login();
                        break;
                    case "2":
                        Console.Clear();
                        CreateAccount();
                        break;
                    case "3":
                        Console.Clear();
                        AdminLogin();
                        break;
                    case "4":
                        Console.WriteLine("Welcome back!");
                        Environment.Exit(0);
                        break;
                    default:
                        TextMessages.MessageColor("Please input your choice using only numbers", false);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            } while (selection != "4");
        }
        public static void Login()
        {
            int attempts = 0;
            bool verifiedUser = false;
            User existingUser = null;
            User existingPassword = null;

            if (lockedOut == false)
            {
                do
                {
                    Console.WriteLine("Please enter your social security number(yyyymmdd-xxxx):");
                    string enteredUser = Console.ReadLine();

                    Console.WriteLine("Please enter your password:");
                    string enteredPassword = Console.ReadLine();

                    existingUser = userList.Find(u => u.Username.Contains(enteredUser));
                    existingPassword = userList.Find(u => u.Password.Contains(enteredPassword));

                    if (existingUser == null || existingPassword == null)
                    {
                        TextMessages.RedMessageColor("Username or password is incorrect. Please try again. You have {0} attempts left.", 2 - attempts);
                        attempts++;
                    }
                    else
                    {
                        if (existingUser.Username != enteredUser || existingPassword.Password != enteredPassword || existingUser != existingPassword)
                        {
                            TextMessages.RedMessageColor("Username or password is incorrect. Please try again. You have {0} attempts left.", 2 - attempts);
                            attempts++;
                        }
                        else if (existingUser.Username == enteredUser && existingPassword.Password == enteredPassword && existingUser == existingPassword)
                        {
                            TextMessages.MessageColor("Login sucessful!");
                            verifiedUser = true;
                            break;
                        }
                    }
                }
                while (attempts < 3);
            }

            if (verifiedUser == false)
            {
                lockedOut = true;
                TextMessages.MessageColor("You've been locked out! Please contact an admin. Press enter to continue", false);
                Console.ReadLine();
                Console.Clear();
                Run();
            }
            else if (verifiedUser == true)
            {
                Console.Clear();
                AccountManager.Run(existingUser); //Opens the account manager along with user account to keep track of changes
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

            if(existingUser == null || existingPassword == null)
            {
                TextMessages.MessageColor("Username or password is incorrect.", false);
                TextMessages.PressEnter();
            }
            else
            {
                if (existingUser.Username != username || existingPassword.Password != password || existingUser != existingPassword)
                {
                    TextMessages.MessageColor("Username or password is incorrect.");
                    TextMessages.PressEnter();
                }
                else if (existingUser.Username == username && existingPassword.Password == password && existingUser == existingPassword)
                {
                    TextMessages.MessageColor("Login sucessful!");
                    TextMessages.PressEnter();
                    AdminAccess.Run();
                }
            }
        }
        public static void CreateAccount()
        {
            Console.WriteLine("Please enter your social security number(yyyymmdd-xxxx). This will be your username.");
            string newUsername;
            bool ok = false;
            do
            {
                newUsername = Console.ReadLine();
                if (!System.Text.RegularExpressions.Regex.IsMatch(newUsername, @"\d{8}-\d{4}")) // checks that username from input is matching (yyyymmdd-xxxx)
                {
                    Console.WriteLine("Enter as yyyymmdd-xxxx!");
                    ok = false;
                }
                else
                {
                    ok = true;
                }

            } while (ok == false);

            Console.WriteLine("Please enter your new password.\nIt has to have a minimum of 8 in lenght and requiers at least one digit, one upper case and one lower case letter."); // skriva om text
            string newPassword;
            do
            {
                newPassword = Console.ReadLine();
                if (!System.Text.RegularExpressions.Regex.IsMatch(newPassword, @"^(?=\D*\d)(?=.*?[A-Za-z]).{8,}$")) // password has to have one digit, one uppercase, one lowercase and at least eight characters
                {
                    TextMessages.MessageColor("Enter password with a minimum of 8 in lenght, at least one digit, one upper case and one lower case letter.", false);
                    ok = false;
                }
                else
                {
                    ok = true;
                }
            } while (ok == false);
            
            Console.WriteLine("Please enter your firstname:");
            string firstName = Console.ReadLine().ToUpper();

            Console.WriteLine("Please enter your lastname:");
            string lastName = Console.ReadLine().ToUpper();

            userList.Add(new User(newUsername, newPassword, firstName, lastName));

            TextMessages.MessageColor("User successfully created!");
            TextMessages.PressEnter();
        }
    }
}
