using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz_App_System.Entities;
namespace Quiz_App_System.Logic
{
    internal class AdminSystem
    {
        private static List<Course> _courses = new List<Course>();
        public static List<Course> Courses { get { return _courses; } }
        public void AddCourse()
        {
            Console.WriteLine("Course name: \n");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Course category: \n");
            string category = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Course duration: \n");
            int duration = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Number of lessons: \n");
            int lessons = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Course newCourse = new Course(name, category, duration, lessons);
            _courses.Add(newCourse);
            Console.WriteLine($"Course ID is: {newCourse.CourseID}\n");
            Console.WriteLine($"Course was added by : {AuthenticationSystem.CurrentAdmin.Name}");
        }
        public void ViewCourses()
        {
            for (int i = 0; i < _courses.Count; i++)
            {
                Console.WriteLine($"Course name: {_courses[i].CourseName}\n");
                Console.WriteLine($"Teacher name: MR.{_courses[i].Teacher.Name} \n" );
                Console.WriteLine($"Duration: {_courses[i].CourseDuration} month\n");
                Console.WriteLine($"Number of lessons: {_courses[i].NumberOfLessons}\n" );
                Console.WriteLine($"Number of quizzes: {_courses[i].Quizzes.Count()}\n");
                Console.WriteLine($"Number of students: {_courses[i].Students.Count()}\n" );
                Console.WriteLine($"Category: {_courses[i].CourseCategory}\n");
                Console.WriteLine("==================================");
                Console.WriteLine($"Students in {_courses[i].CourseName}: \n");
                for(int j = 0; j < _courses[i].Students.Count; j++)
                {
                    Console.WriteLine((j+1)+"- " +_courses[i].Students[j].Name+"\n");
                    Console.WriteLine("=================================");
                }
            }
        }
        public void ViewTeachers()
        {
            for (int i = 0; i < AuthenticationSystem.Teachers.Count; i++)
            {
                Console.WriteLine($"Teacher name: MR.{AuthenticationSystem.Teachers[i].Name}\n");
                Console.WriteLine($"Teacher email: {AuthenticationSystem.Teachers[i].Email}\n");
                Console.WriteLine($"Teacher title: {AuthenticationSystem.Teachers[i].Name}\n");
                Console.WriteLine($"Teacher courses count: {AuthenticationSystem.Teachers[i].AssignedCourses.Count}\n");
                Console.WriteLine("=================================\n");
                Console.WriteLine($"Courses with MR.{AuthenticationSystem.Teachers[i].Name}: \n");
                for(int j = 0;j < AuthenticationSystem.Teachers[i].AssignedCourses.Count; j++)
                {
                    Console.WriteLine($"Course name: {AuthenticationSystem.Teachers[i].AssignedCourses[j].CourseName}\n");
                    Console.WriteLine($"Course category: {AuthenticationSystem.Teachers[i].AssignedCourses[j].CourseCategory}\n");
                    Console.WriteLine($"Number of quizzes in {AuthenticationSystem.Teachers[i].AssignedCourses[j]}: {AuthenticationSystem.Teachers[i].AssignedCourses[j].Quizzes.Count}\n");
                    Console.WriteLine("===============================\n");
                }
                Console.WriteLine("=====================================\n");
                Console.WriteLine($"Quizzes were created by MR.{AuthenticationSystem.Teachers[i].Name}\n");
                for(int course = 0; course < AuthenticationSystem.Teachers[i].AssignedCourses.Count; course++)
                {
                    for(int quiz = 0; quiz < AuthenticationSystem.Teachers[i].AssignedCourses[course].Quizzes.Count; quiz++)
                    {
                        Console.WriteLine($"Quiz name: {AuthenticationSystem.Teachers[i].AssignedCourses[course].Quizzes[quiz].QuizName}\n");
                        Console.WriteLine($"Quiz ID: {AuthenticationSystem.Teachers[i].AssignedCourses[course].Quizzes[quiz].QuizID}\n");
                        Console.WriteLine("===================================\n");
                    }
                }
                
            }
        }
        public void ViewAdmins()
        {
            for(int i = 0; i < AuthenticationSystem.Admins.Count; i++)
            {
                Console.WriteLine($"Admin name: {AuthenticationSystem.Admins[i].Name}\n");
                Console.WriteLine($"Admin ID: {AuthenticationSystem.Admins[i].ID}\n");
                Console.WriteLine("=============================\n");
            }
        }
        public void ViewStudents()
        {
            for(int i = 0; i < AuthenticationSystem.Students.Count; i++)
            {
                Console.WriteLine($"Student name: {AuthenticationSystem.Students[i].Name}\n");
                Console.WriteLine($"Student email: {AuthenticationSystem.Students[i].Email}\n");
                Console.WriteLine($"Student grade: {AuthenticationSystem.Students[i].StudentGrade}\n");
                Console.WriteLine($"Number of enrolled courses: {AuthenticationSystem.Students[i].EnrolledCourses.Count}\n");
                Console.WriteLine($"Number of taken quizzes: {AuthenticationSystem.Students[i].TakenQuizzes.Count}\n");
                Console.WriteLine("=====================================");
                Console.WriteLine($"Enrolled courses by {AuthenticationSystem.Students[i].Name}:\n");
                for(int j = 0; j < AuthenticationSystem.Students[i].EnrolledCourses.Count; j++)
                {
                    Console.WriteLine($"{j+1}- {AuthenticationSystem.Students[i].EnrolledCourses[j].CourseName}\n");
                    Console.WriteLine("=================================");
                }
                Console.WriteLine("==============================");
                Console.WriteLine($"Taken quizzes by {AuthenticationSystem.Students[i].Name}: \n");
                for(int k = 0; k < AuthenticationSystem.Students[i].TakenQuizzes.Count; k++)
                {
                    Console.WriteLine(AuthenticationSystem.Students[i].TakenQuizzes[k].QuizName + "\n");
                    Console.WriteLine("=====================================");
                }
            }
        }
    }
}
