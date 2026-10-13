using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Quiz_App_System.Entities;
using Quiz_App_System.Logic;
namespace Quiz_App_System.Configuration
{
    internal class SystemInitializer
    {
        private static Admin Admin1 = new Admin("Admin1", "Admin1@gmail.com", "1234");
        private static Admin Admin2 = new Admin("Admin2", "Admin2@gmail.com", "5678");
        private static Admin Admin3 = new Admin("Admin3", "Admin3@gmail.com", "9101");
        public static void InitializeAdmins()
        {
            AuthenticationSystem.Admins.Add(Admin1);
            AuthenticationSystem.Admins.Add(Admin2);
            AuthenticationSystem.Admins.Add(Admin3);
        }
    }
}
