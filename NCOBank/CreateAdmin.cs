using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    internal class CreateAdmin
    {
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
