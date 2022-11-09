using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    internal class Admin
    {
        public bool IsAdmin { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }

        public Admin()
        {
            this.IsAdmin = true;
            this.UserName = "Admin";
            this.PassWord = "admin";
        }
    }
}
