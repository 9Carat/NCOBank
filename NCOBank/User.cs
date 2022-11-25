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
        private string _firstName;
        private string _lastName;
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
        public string FirstName 
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value == null || value == string.Empty)
                {
                    _firstName = "Agent";
                }
                else
                {
                    _firstName = value;
                }
            } 
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value == null || value == string.Empty)
                {
                    _lastName = "Smith";
                }
                else
                {
                    _lastName = value;
                }    
            }
        }

        public User(string username, string password, string firstName, string lastName)
        {
            Username = username;
            Password = password;
            UserRole = "user";
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
