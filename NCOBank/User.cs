using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCOBank
{
    public class User
    {
        private float _numLoans;
        private string _username;
        private string _password;
        private string _userRole;
        public Dictionary<string, int> accountList;
        public float NumLoans 
        { 
            get
            {
                return _numLoans;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("The amount can't be under 0");
                }
                else
                {
                    _numLoans = value;
                }
            }
        }
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
            //this.NumLoans = _numLoans;
            _username = username;
            _password = password;
            _userRole = "user";
        }
    }
}
