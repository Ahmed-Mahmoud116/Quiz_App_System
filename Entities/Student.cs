using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_App_System.Entities
{
    internal class Student : Person
    {
        private string _studentGrade;
        private List<Course> _enrolledCourses = new List<Course>();
        private List<Quiz> _takenQuizzes = new List<Quiz>();
        public string StudentGrade
        {
            get { return _studentGrade; }
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {  throw new ArgumentNullException("value"); }
                _studentGrade = value;
            }

        }
        public List<Quiz> TakenQuizzes
        {
            get { return _takenQuizzes; }
        }

        public List<Course> EnrolledCourses
        { get { return _enrolledCourses; } }

        public Student(string name, string email, string password, string grade) : base(name, email, password)
        {
            StudentGrade = grade;
        }
    }
}
