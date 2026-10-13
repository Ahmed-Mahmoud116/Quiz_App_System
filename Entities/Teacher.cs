using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_App_System.Entities
{
    internal class Teacher : Person
    {
        private string _teacherTitle;
        private List<Course> _assignedCourses = new List<Course>();
        
        public string TeacherTitle
        {
            get { return _teacherTitle; }
            set
            {
                if(string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("value");
                _teacherTitle = value;
            }
        }
        public List<Course> AssignedCourses
        {
            get { return _assignedCourses; }
        }
      
        public Teacher(string name,string email,string password,string title):base(name,email,password)
        {
            TeacherTitle = title;
        }
    }
}
