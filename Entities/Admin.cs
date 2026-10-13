using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_App_System.Entities
{
    internal class Admin : Person
    {
        public Admin(string name, string email, string password) : base(name, email, password)
        {
        }
    }
}
