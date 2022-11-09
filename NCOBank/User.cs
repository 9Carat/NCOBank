using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    public class User
    {
        private int userID;
        private double accountBalance;
        private string firstName;
        private string lastName;
        private string passWord;
        public int LogInAttempts { get; set; }
        public bool IsLocked { get; set; }
        public int UserID { get; set; }
        public double AccountBalance { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassWord { get; set; }

        public User()
        {
            this.UserID = userID;
            this.AccountBalance = accountBalance;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PassWord = passWord;
        }
    }
}
