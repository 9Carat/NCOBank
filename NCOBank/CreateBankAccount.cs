using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    internal class CreateBankAccount
    {
        public static void Run()
        {
            Console.WriteLine("Enter account number: ");
            int newAcc;
            int.TryParse(Console.ReadLine(), out newAcc);
            Console.WriteLine("Enter deposit: ");
            int newDeposit;
            int.TryParse(Console.ReadLine(), out newDeposit);

            BankMenu.accList.Add(newAcc, newDeposit);
            Console.WriteLine("Account created!");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
