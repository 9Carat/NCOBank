using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    internal class CheckUser 
    {
        bool ok = false;
        int count = 0;
        User currentUser;
        List<User> userList = new List<User>
        {
            new User {UserID = 880409, AccountBalance = 30000, FirstName = "Niklas", LastName = "Sendelbach", PassWord = "niklas"},
            new User {UserID = 870508, AccountBalance = 36000, FirstName = "Frida", LastName = "Sendelbach", PassWord = "frida"},
            new User {UserID = 151228, AccountBalance = 66000, FirstName = "Belle", LastName = "Sendelbach", PassWord = "belle"},
            new User {UserID = 181123, AccountBalance = 5000, FirstName = "Julian", LastName = "Sendelbach", PassWord = "julian"}
        };
        public void CreateUser()
        {
            Admin admin = new Admin();
            admin.UserName = "Admin";
            admin.PassWord = "admin";
            while (ok == false)
            {
                Console.WriteLine("Admin username: ");
                string username = Console.ReadLine();
                Console.WriteLine("Admin password: ");
                string password = Console.ReadLine();
                if (admin.UserName.Equals(username))
                {

                    if (admin.PassWord.Equals(password))
                    {
                        ExtraMethods.MessageColor("OK");
                        ok = true;
                        break;
                    }
                }
                if (admin.PassWord != password)
                {
                    ExtraMethods.MessageColor("Wrong username or password", false);
                    ok = false;
                    count++;
                }
            }
            Console.WriteLine("Enter new username: ");
            int newUserName;
            int.TryParse(Console.ReadLine(), out newUserName);
            Console.WriteLine("Enter new password: ");
            string newPassWord = Console.ReadLine();

            userList.Add(new User { UserID = newUserName, PassWord = newPassWord });

            Console.WriteLine("New user created!");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
            BankMenu.FirstMenu();
        }
        public void checkUser()
        {
            do
            {
                Console.WriteLine("Enter your username: ");
                int username;
                int.TryParse(Console.ReadLine(), out username);
                Console.WriteLine("Enter your password: ");
                string password = Console.ReadLine();
                foreach (User user in userList)
                {
                    currentUser = user;
                    if (currentUser.UserID.Equals(username))
                    {
                        if (currentUser.PassWord.Equals(password))
                        {
                            ExtraMethods.MessageColor("OK");
                            ok = true;
                            break;
                        }
                    }
                }
                if (currentUser.PassWord != password)
                {
                    ExtraMethods.MessageColor("Wrong username or password", false);
                    count++;
                    if (count == 3)
                    {
                        ExtraMethods.MessageColor("Your account is locked", false);
                        // currentUser.IsLocked? 
                        Environment.Exit(1);
                    }
                }
            } while (count < 3 && ok == false);
            BankMenu.FirstMenu();
        }
    }
}
