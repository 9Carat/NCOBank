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
                TextColor.BankLogo();
                TextColor.YellowMessageColor("Welcome to the NCO Bank!");
                TextColor.YellowMessageColor("Please select one of the following options:");
                TextColor.YellowMessageColor("1. Login");
                TextColor.YellowMessageColor("2. Create account");
                TextColor.YellowMessageColor("3. Admin access (admin only)");
                TextColor.YellowMessageColor("4. Exit");
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
                        TextColor.YellowMessageColor("Welcome back!");
                        Environment.Exit(0);
                        break;
                    default:
                        TextColor.MessageColor("Please input your choice using only numbers", false);
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
                    TextColor.YellowMessageColor("Please enter your social security number(yyyymmdd-xxxx):");
                    string enteredUser = Console.ReadLine();

                    TextColor.YellowMessageColor("Please enter your password:");
                    string enteredPassword = Console.ReadLine();

                    existingUser = userList.Find(u => u.Username.Contains(enteredUser));
                    existingPassword = userList.Find(u => u.Password.Contains(enteredPassword));

                    if (existingUser == null || existingPassword == null)
                    {
                        TextColor.MessageColor($"Username or password is incorrect. Please try again. You have {2 - attempts} attempts left.", false);
                        attempts++;
                    }
                    else
                    {
                        if (existingUser.Username != enteredUser || existingPassword.Password != enteredPassword || existingUser != existingPassword)
                        {
                            TextColor.MessageColor($"Username or password is incorrect. Please try again. You have {2 - attempts} attempts left.", false);
                            attempts++;
                        }
                        else if (existingUser.Username == enteredUser && existingPassword.Password == enteredPassword && existingUser == existingPassword)
                        {
                            TextColor.MessageColor("Login sucessful!");
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
                TextColor.MessageColor("You've been locked out! Please contact an admin. Press enter to continue", false);
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

            TextColor.YellowMessageColor("Enter username");
            string username = Console.ReadLine();
            TextColor.YellowMessageColor("Enter password");
            string password = Console.ReadLine();

            Admin existingUser = adminList.Find(a => a.Username.Contains(username));
            Admin existingPassword = adminList.Find(a => a.Password.Contains(password));

            if(existingUser == null || existingPassword == null)
            {
                TextColor.MessageColor("Username or password is incorrect.", false);
                TextColor.PressEnter();
            }
            else
            {
                if (existingUser.Username != username || existingPassword.Password != password || existingUser != existingPassword)
                {
                    TextColor.MessageColor("Username or password is incorrect.");
                    TextColor.PressEnter();
                }
                else if (existingUser.Username == username && existingPassword.Password == password && existingUser == existingPassword)
                {
                    TextColor.MessageColor("Login sucessful!");
                    TextColor.PressEnter();
                    AdminAccess.Run();
                }
            }
        }
        public static void CreateAccount()
        {
            TextColor.YellowMessageColor("Please enter your social security number(yyyymmdd-xxxx). This will be your username.");
            string newUsername;
            bool ok = false;
            do
            {
                newUsername = Console.ReadLine();
                if (!System.Text.RegularExpressions.Regex.IsMatch(newUsername, @"\d{8}-\d{4}")) // checks that username from input is matching (yyyymmdd-xxxx)
                {
                    TextColor.MessageColor("You have to enter your social security number as yyyymmdd-xxxx!", false);
                    TextColor.YellowMessageColor("Please enter again: ");
                    ok = false;
                }
                else
                {
                    ok = true;
                }

            } while (ok == false);

            TextColor.YellowMessageColor("Please enter your new password.\nIt has to have a minimum of 8 in length and requires at least one digit, one upper case and one lower case letter.");
            string newPassword;
            do
            {
                newPassword = Console.ReadLine();
                if (!System.Text.RegularExpressions.Regex.IsMatch(newPassword, @"^(?=\D*\d)(?=.*?[A-Za-z]).{8,}$")) // password has to have one digit, one uppercase, one lowercase and at least eight characters
                {
                    TextColor.MessageColor("Enter password with a minimum of 8 in lenght, at least one digit, one upper case and one lower case letter.", false);
                    TextColor.YellowMessageColor("Please enter your new password: ");
                    ok = false;
                }
                else
                {
                    ok = true;
                }
            } while (ok == false);

            TextColor.YellowMessageColor("Please enter your firstname:");
            string firstName = Console.ReadLine().ToUpper();

            TextColor.YellowMessageColor("Please enter your lastname:");
            string lastName = Console.ReadLine().ToUpper();

            userList.Add(new User(newUsername, newPassword, firstName, lastName));

            TextColor.MessageColor("User successfully created!");
            TextColor.PressEnter();
        }
    }
}
