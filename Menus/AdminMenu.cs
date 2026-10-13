using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz_App_System.Logic;
using Quiz_App_System.Entities;
namespace Quiz_App_System.Menus
{
    internal class AdminMenu
    {
       private static AdminSystem System = new AdminSystem();
        private static Admin admin = new Admin("temp", "temp", "temp");
        private static AuthenticationSystem authentication = new AuthenticationSystem();
        public void Admin_Menu()
        {
            Console.WriteLine("1- Add course\n");
            Console.WriteLine("2- View courses\n");
            Console.WriteLine("3- View teachers\n");
            Console.WriteLine("4- View students\n");
            Console.WriteLine("0- Exit\n");
            Console.WriteLine("========================\n");
            int choice = 0;
            while(true)
            {
                Console.Write("Choose: ");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch(choice)
                {
                    case 1:
                        System.AddCourse();
                        break;
                    case 2:
                        System.ViewCourses();
                        break;
                    case 3:
                        System.ViewTeachers();
                        break;
                    case 4:
                        System.ViewStudents();
                        break;
                    case 5:
                        authentication.Login(admin);
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid input.\n");
                        break;

                }    
            }
        }
    }
}
