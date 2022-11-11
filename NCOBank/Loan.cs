using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    internal class Loan
    {
        private float totalPersonal;
        private float totalSaving;
        private float totalLoan;
        public float TotalPersonal { get; set; }
        public float TotalSaving { get; set; }
        public float TotalLoan 
        { 
            get
            {
                return totalLoan;
            }
            set
            {
                totalLoan = 5;
            } 
        }
        public Loan()
        {
            this.TotalPersonal = totalPersonal;
            this.TotalSaving = totalSaving;
            this.TotalLoan = totalLoan;
        }

        public static void Run(User user)
        {
            Loan x = new Loan();
            x.MaxLoan(user);
            
        }
        public void MaxLoan(User user)
        {
            foreach (var item in AccountManager.personalAccList)
            {
                if (item.Value.Equals(user))
                {
                    totalPersonal = item.Key.balance;
                }
            }
            foreach (var item in AccountManager.savingsAccList)
            {
                if (item.Value.Equals(user))
                {
                    totalSaving = item.Key.balance;
                }
            }

            float maxLoan = (totalPersonal + totalSaving) * totalLoan;
            Console.WriteLine($"The max loan is {maxLoan}");
        }
    }
}
