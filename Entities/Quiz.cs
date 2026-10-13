using Quiz_App_System.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_App_System.Entities
{
    internal class Quiz
    {
        public enum Results
        {
            Pass,
            Fail
        }
        private Results _result;
        private string _quizName;
        private int _quizID;
        private int _quizDuration;
        private List<Question> _questions = new List<Question>();
        private int _score;
        private List<Student> _students = new List<Student>();
        private Course _course = null;

        public List<Student> Students { get { return _students; } }
        public int Score
        { get { return _score; }
          set { _score = value; }
        }
        public Results Result
        {
            get { return _result; }
            set { _result = value; }
        }
        public string QuizName
        {
            get { return _quizName; }
            set
            {
                if(string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("value");
                _quizName = value;
            }
        }
        public Course Course
            {
            get { return _course; }
            set { _course = value; }
            }
        public int QuizID
        { 
            get { return _quizID; }
            set { _quizID = value; }
        }
        public int QuizDuration
        {
            get { return _quizDuration; }   
            set
            {
                if(value <= 0) throw new ArgumentException("value");
                _quizDuration = value;
            }
        }
        public List<Question> Questions
        {
            get { return _questions; }
            set { _questions = value; }
        }
        public Quiz(string quizName,  int quizDuration )
        {
            QuizName = quizName;
            QuizDuration = quizDuration;
            _quizID = IdGenerator.GenerateID();
        }
    }
}
