using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    internal class UserMenu
    {
        public static void UsersMenu()
        {
            Console.WriteLine("Välkommen till ditt bankkonto!\n1: \n2: \n3: \n4:");
            int choice;
            int.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("temp");
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
