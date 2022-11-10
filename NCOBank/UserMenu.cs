using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    public class UserMenu
    {
        
        public static void UsersMenu()
        {
            Console.WriteLine("Välkommen till din bankMeny, vad vill du göra?: !\nFör att gå till dit bankkonto tryck 1: \n2: \n3: \n4:");
            int choice;
            int.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    UserFunctions.BankAccount();
                    break;
                case 2:
                    Console.WriteLine("temp");
                    break;
                case 3:
                    Console.WriteLine("temp");
                    break;
                case 4:
                    Console.WriteLine("temp");
                    break;
                case 5:
                    Console.WriteLine("Gå");
                    break;

            }

        }


    }

}
