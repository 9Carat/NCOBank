using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    internal class BankMenu
    {
        private List<Admin> _adminList = new List<Admin>();
        private List<User> _userList = new List<User>();
        
        public void Run()
        {
            Console.WriteLine("Welcome to the NCO Bank!");
            Console.WriteLine("Please select one of the following options:");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Create account");
            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    Login();
                    break;
                case "2":
                    CreateAccount();
                    break;
                default:
                    Console.WriteLine("Please input your choice using only numbers");
                    break;
            }
        }
        public void Login()
        {
            int attempts = 0;
            bool loggedIn = false;

            do
            {
                Console.WriteLine("Please enter your username");
                string enteredUser = Console.ReadLine();

                Console.WriteLine("Please enter your password");
                string enteredPassword = Console.ReadLine();

                //Checks if username and password exists in list, otherwise returns null
                User existingUser = _userList.Find(u => u.Username.Contains(enteredUser));
                User existingPassword = _userList.Find(u => u.Password.Contains(enteredPassword));

                if (existingUser == null || existingPassword == null || existingUser != existingPassword)
                {
                    Console.WriteLine("Username or password is incorrect. Please try again. You have {0} attempts left.", 2 - attempts);
                    attempts++;
                }
                else if (existingUser != null && existingPassword != null && existingUser == existingPassword)
                {
                    Console.WriteLine("Login successful!");
                    loggedIn = true; 
                    break;
                }
            }
            while (attempts < 3);

            if(loggedIn == false)
            {
                Console.WriteLine("You've been locked out! Please contact an admin.");
            }
        }
        public void CreateAccount()
        {
            Console.WriteLine("Please enter your social security number(yyyymmdd-xxxx). This will be your username.");
            string newUsername = Console.ReadLine();
            Console.WriteLine("Please enter your new password");
            string newPassword = Console.ReadLine();

            _userList.Add(new User(newUsername,newPassword));

            Console.WriteLine("User successfully created!");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
            Run();
        }
    }
}
