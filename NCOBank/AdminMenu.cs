using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    internal class AdminMenu
    {
        public static void AdminMenus()
        {
            List<user> userList = new List<user>();
            UserMenu us1 = new UserMenu();
            Console.WriteLine("Välkommen till ditt AdminKonto!\n1:Ändra ValutaKurs \n2:Lägg till användare \n3:\"Lås upp användare \n4: Gå till användarMeny\n5: Logga ut");
            int choice;
            int.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Ändra ValutaKurs");
                    break;
                case 2:
                    Console.WriteLine("Temp");
                    break;
                case 3:
                    Console.WriteLine("Lås upp användare");
                    break;
                case 4:
                    Console.WriteLine("Gå till användarMeny");
                    UserMenu.UsersMenu();
                    break;
                case 5:
                    Console.WriteLine("Logga ut");
                    break;

            }

        }
    
    }

}  
