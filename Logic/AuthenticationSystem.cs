using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz_App_System.Entities;
namespace Quiz_App_System.Logic
{
    internal class AuthenticationSystem
    {
        private static List<Admin> _admins = new List<Admin>();
        private static List<Student> _students = new List<Student>();
        private static List<Teacher> _teachers = new List<Teacher>();
        private static Admin _currentAdmin = null;
        private static Student _currentStudent = null;
        private static Teacher _currentTeacher = null;
        public static Student CurrentStudent
        { get { return _currentStudent; } }
        public static Teacher CurrentTeacher
        { get { return _currentTeacher; } }
        public static List<Admin>Admins { get { return _admins; } }
        public static List<Student> Students { get {return _students; } }
        public static List<Teacher> Teachers { get { return _teachers; } }

        public void Register(Person p)
        {

            Console.WriteLine("Name: \n");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("E-mail: \n");
            string email = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Password: \n");
            string password = Console.ReadLine();
            Console.WriteLine();
            if (p is Student)
            {

                Console.WriteLine("Grade: \n");
                string grade = Console.ReadLine();
                Console.WriteLine();
                Student newStudent = new Student(name, email, password,grade);
                _students.Add(newStudent);
                Console.WriteLine($"Your ID is:  {newStudent.ID } \n");
                Console.WriteLine();
            }

            else
            {
                Console.WriteLine("Title: \n");
                string title = Console.ReadLine();
                Console.WriteLine();
                Teacher newTeacher = new Teacher(name, email, password, title);
                _teachers.Add(newTeacher);
                Console.WriteLine($"Your ID is: {newTeacher.ID}\n");
                Console.WriteLine();
            }

        }
        public bool Login(Person p)
        {

            Console.WriteLine("ID: \n");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            if (id <= 0) throw new ArgumentException("ID");
            Console.WriteLine("Password: \n");
            string password = Console.ReadLine();
            Console.WriteLine();
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentNullException("Password");
            if (p is Student)
            {
                for (int i = 0; i < _students.Count; i++)
                {
                    if(id == _students[i].ID && _students[i].VerifyPassword(password))
                    {
                        Console.WriteLine($"Welcome   { _students[i].Name} !\n");
                        _currentStudent = _students[i];
                        return true;
                    }
                }
                Console.WriteLine("Invalid data.\n");
                return false;
            }
            else if(p is Teacher)
            {
                for(int i = 0; i <= _teachers.Count; i++)
                {
                    if(id == _teachers[i].ID && _teachers[i].VerifyPassword(password))
                    {
                        Console.WriteLine($"Welcome MR. { _teachers[i].Name } !\n");
                        _currentTeacher = _teachers[i];
                        return true;
                    }
                    
                }
                Console.WriteLine("Invalid data.\n");
                return false;
            }
            else if(p is Admin)
            {
                for(int i = 0; i < _admins.Count; i++)
                {
                    if(id == _admins[i].ID && _admins[i].VerifyPassword(password))
                    {
                        Console.WriteLine($"Welcome {_admins[i].Name} !\n");
                        _currentAdmin = _admins[i];
                        return true;
                    }
                }
                return false;
            }
            Console.WriteLine("Unknown error.\n");
            return false;
        }
        public static Admin CurrentAdmin
        {
            get { return _currentAdmin; }
        }
    }
}
