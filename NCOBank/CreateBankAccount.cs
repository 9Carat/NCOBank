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
            int newAcc = RanNum();
            Console.WriteLine($"Your account number is: {newAcc} ");
            Console.WriteLine("Enter deposit: ");
            int newDeposit;
            int.TryParse(Console.ReadLine(), out newDeposit);

            BankMenu.accList.Add(newAcc, newDeposit);
            Console.WriteLine("Account created!");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
        public static int RanNum()
        {
            Random rnd = new Random();
            HashSet<int> accNum = new HashSet<int>();
            while (accNum.Count < 5)
            {
                accNum.Add(rnd.Next(1, 100));
            }
            int randomNumber = accNum.First();
            return randomNumber;
        }
    }
}
