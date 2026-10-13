using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz_App_System.Entities;
using Quiz_App_System.Logic;
namespace Quiz_App_System.Menus
{
    internal class GoToMenus
    {
        private static bool isTrue = false;
       private static Student student = new Student("temp", "temp", "temp", "temp");
        private static Admin admin = new Admin("temp", "temp", "temp");
        private static Teacher teacher = new Teacher("temp", "temp", "temp", "temp");
        AuthenticationSystem System = new AuthenticationSystem();
        private static StudentMenu StudentMenu = new StudentMenu();
        private static AdminMenu adminMenu = new AdminMenu();
        private static TeacherMenu teacherMenu = new TeacherMenu();
        public void Student()
        {
            Console.WriteLine("1- Register.\n");
            Console.WriteLine("2- Login.\n");
            Console.WriteLine("0- Exit");
            int choice = 0;
            while(true)
            {
                Console.Write("Choose: ");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch(choice)
                {
                    case 1:
                        System.Register(student);
                        break;
                    case 2:
                        isTrue = System.Login(student);
                        if(isTrue)
                        {
                            StudentMenu.Student_Menu();
                        }
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid input.\n");
                        break;

                }
            }
        }
        public void Admin()
        {
            Console.WriteLine("1- Login.\n");
            Console.WriteLine("0- Exit.\n");
            int choice = 0;
            while(true)
            {
                Console.Write("Choose: ");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch(choice)
                {
                    case 1:
                       isTrue = System.Login(admin);
                        if(isTrue)
                        {
                            adminMenu.Admin_Menu();
                        }
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid input.\n");
                        break;
                }
            }
        }
        public void Teacher()
        {
            Console.WriteLine("1- Register.\n");
            Console.WriteLine("2- Login.\n");
            Console.WriteLine("0- Exit");
            int choice = 0;
            while (true)
            {
                Console.Write("Choose: ");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        System.Register(teacher);
                        break;
                    case 2:
                       isTrue = System.Login(teacher);
                        if(isTrue)
                        {
                            teacherMenu.Teacher_Menu();
                        }
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
