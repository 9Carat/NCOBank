using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    class user
    {
        public double money { get; set; }
        public string Username { get; set; }
        public bool Adminrole;
        public string Password { get; set; }

        public user(string username = "Null", string password = "null", bool adminrole = false, double money = 0000)
        {
            this.money = money;
            this.Username = username;
            this.Password = password;
            this.Adminrole = adminrole;
        }

    }
}
