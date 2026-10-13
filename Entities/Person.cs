using Quiz_App_System.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_App_System.Entities
{
    internal  class Person
    {
        protected string _name;
        protected string _email;
        protected string _password;
        protected int _id;
        
        public Person(string name, string email,string password)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");
            if(string.IsNullOrWhiteSpace(email)) throw new ArgumentNullException("email");
            if(string.IsNullOrWhiteSpace(password) || password.Length < 4) throw new ArgumentNullException("password");
            _name = name;
            _email = email;
            _password = password;
            _id = IdGenerator.GenerateID();
           
        }
        public string Name
        {
            get { return _name; } 
        }
        public string Email
        {
            get { return _email; }
        }
        public int ID
        {
            get { return _id; }
        }
        public bool VerifyPassword(string password)
        {
            return this._password == password;
        }
    }
}
