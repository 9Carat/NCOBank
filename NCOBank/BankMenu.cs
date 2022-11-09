using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    class BankMenu
    {
        //List<Admin> adminList = new List<Admin>();
        List<user> userList = new List<user>();
        UserMenu baseMenu = new UserMenu();
        AdminMenu adminMenu = new AdminMenu();

        user user1 = new user("Oskar", "inlogg", true, 50000);

        public void chooseOption()
        {
            int choice;

            Console.WriteLine("Hej och välkommen till NCO Bank. Gör ditt val: 1 för logga in, 2 för skapa konto ");
            int.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    loggin();
                    break;
                case 2:
                    CreateAccount();
                    break;

            }
        }
        internal void loggin()
        {
            bool b = true;
            bool role;
            string done = null;
            int attempts = 0;
            int amount = 3;


            do
            {
                Console.WriteLine("Skriv ditt användarnamn: ");
                string enteredUser = Console.ReadLine();
                Console.WriteLine("Skriv ditt lösenord: ");
                string enteredPassword = Console.ReadLine();

                user existingUser = userList.Find(u => u.Username.Contains(enteredUser));

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        Console.WriteLine("Skriv in ditt användarnamn igen: ");
                        enteredUser = Console.ReadLine();
                        Console.WriteLine("skirv in ditt lösenord igen: ");
                        enteredPassword = Console.ReadLine();
                        j++;
                    }

                    if (existingUser.Password.Equals(enteredPassword))
                    {
                        Console.WriteLine("Du har lyckats loggat in på ditt konto");
                        i = 4;
                        b = false;
                        break;

                    }
                    else
                    {
                        Console.WriteLine("Du misslyckades med inloggningen, försök igen.");
                        attempts++;
                        Console.WriteLine($"Du har gjort {attempts} försök");
                        amount--;
                        Console.WriteLine($"Du har {amount} kvar");

                    }

                }

                if (b == true)
                {
                    Console.WriteLine("Ditt konto är nu låst, kontakta en administratör");
                }
                else
                {
                    if (existingUser.Adminrole)
                    {
                        AdminMenu.AdminMenus();
                    }
                    else
                    {
                        UserMenu.UsersMenu();
                    }
                }


            } while (done != null);



        }
        internal void CreateAccount()
        {
            string userName;
            string passaWord;
            bool Admin;

            Console.WriteLine("Var vänlig och fyll ut ditt användarnamn:");
            userName = Console.ReadLine();
            Console.WriteLine("Var vänlig och fyll ut ditt lösenord: ");
            passaWord = Console.ReadLine();
            Console.WriteLine("Ska den här användaren vara en admin? Y för ja, och N för nej");
            string adminCheck = Console.ReadLine();
            if (adminCheck == "Y" || adminCheck == "y")
            {
                Admin = true;
            }
            else
            {
                Admin = false;
            }


            userList.Add(new user(userName, passaWord, Admin));
            Console.WriteLine("Tack för att du ansökt om ett konto på NCO-bank, en Admin kommer att lägga in dig senare.");
            Console.WriteLine("Tryck på en tangent för att gå vidare");
            Console.ReadKey();
            Console.Clear();
            chooseOption();
        }

    }
}
