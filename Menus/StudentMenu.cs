using Quiz_App_System.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz_App_System.Entities;
namespace Quiz_App_System.Menus
{
    internal class StudentMenu
    {
        private static StudentSystem System = new StudentSystem();
        public void Student_Menu()
        {
            
            Console.WriteLine("1- View courses.\n");
            Console.WriteLine("2- Enroll course.\n");
            Console.WriteLine("3- View Enrolled courses.\n");
            Console.WriteLine("4- Take quiz.\n");
            Console.WriteLine("5- View taken quizzes.\n");
            Console.WriteLine("6- View taken quiz details.\n");
            Console.WriteLine("0- Exit.\n");
            Console.WriteLine("=================================\n");
            int choice = 0;
            while(true)
            {
                Console.Write("Choose: ");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch(choice)
                {
                    case 1:
                        System.ViewCourses();
                        break;
                    case 2:
                        System.EnrollCourse();
                        break;
                    case 3:
                        System.ViewEnrolledCourses();
                        break;
                    case 4:
                        System.TakeQuiz();
                        break;
                    case 5:
                        System.ViewTakenQuizzes();
                        break;
                    case 6:
                        System.ViewQuizDetails();
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
