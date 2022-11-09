using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    public static class BankMenu
    {
        
        public static void FirstMenu()
        {
            CheckUser currentUser = new CheckUser(); // funkar inte, behöver lägga input någon annanstans för att använda nuvarande användare?
            Console.WriteLine("1: Create new account \n2: Login \n3: Exit");
            int select;
            int.TryParse(Console.ReadLine(), out select);
            do
            {   
                switch (select)
                {
                    case 1:
                        currentUser.CreateUser();
                        break;
                    case 2:
                        currentUser.checkUser();
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }

            } while (select != 3);
        }
        
    }
}
