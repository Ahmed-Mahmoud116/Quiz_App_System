using Quiz_App_System.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_App_System.Menus
{
    internal class TeacherMenu
    {
        private static TeacherSystem System = new TeacherSystem();
        public void Teacher_Menu()
        {
            Console.WriteLine("1- Assign course.\n");
            Console.WriteLine("2- View Assigned courses.\n");
            Console.WriteLine("3- View Unassigned courses.\n");
            Console.WriteLine("4- View quiz details.\n");
            Console.WriteLine("5- Create quiz.\n");
            Console.WriteLine("6- Edit quiz.\n");
            Console.WriteLine("0- Exit.\n");
            int choice = 0;
            while(true)
            {
                Console.Write("Choose: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        System.AssignCourse();
                        break;
                    case 2:
                        System.ViewAssignedCourses();
                        break;
                    case 3:
                        System.ViewUnassignedCourses();
                        break;
                    case 4:
                        System.ViewQuizDetails();
                        break;
                    case 5:
                        System.CreateQuiz();
                        break;
                    case 6:
                        System.EditQuiz();
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
