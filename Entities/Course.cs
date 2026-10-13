using Quiz_App_System.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_App_System.Entities
{
    internal class Course
    {
        private string _courseName;
        private int _courseID;
        private string _courseCategory;
        private int _courseDuration;
        private int _numberOfLessons;
        private Teacher _teacher;
        private List<Quiz> _quizzes = new List<Quiz>();
        private List<Student> _students = new List<Student>();
        public string CourseName
        {
            get { return _courseName; }
            set
            {
                if(string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("value");
                _courseName = value;
            }
        }
        public Teacher Teacher
        {
            get { return  this._teacher; }
            set {  this._teacher = value; }
        }
        public int CourseID
        {
            get { return _courseID; }
        }
        public string CourseCategory
        {
            get { return _courseCategory; }
            set
            {
                if(string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("value");
                _courseCategory = value;
            }
        }
        public int CourseDuration
        {
            get { return _courseDuration; }
            set
            {
                if(value <= 0) throw new ArgumentException("value");
                _courseDuration = value;
            }

        }
        public int NumberOfLessons
        {
            get { return _numberOfLessons; }
            set
            {
                if(value <= 0) throw new ArgumentException("value");
                _numberOfLessons = value;
            }
        }
        public List<Quiz> Quizzes
        {
            get { return _quizzes; }
        }
        public List<Student> Students
        {
            get { return _students; }
        }
        public Course(string courseName, string courseCategory, int courseDuration, int numberOfLessons)
        {
            CourseName = courseName;
            CourseCategory = courseCategory;
            CourseDuration = courseDuration;
            NumberOfLessons = numberOfLessons;
            _courseID = IdGenerator.GenerateID();
        }
    }
}
