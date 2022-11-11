using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    public class User
    {
        private string _username;
        private string _password;
        private string _userRole;
        public Dictionary<string, int> accountList;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
        public string UserRole
        {
            get
            {
                return _userRole;
            }
            set
            {
                _userRole = value;
            }
        }

        public User(string username, string password)
        {
            _username = username;
            _password = password;
            _userRole = "user";
        }
    }
}
