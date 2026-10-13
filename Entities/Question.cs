using Quiz_App_System.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_App_System.Entities
{
    internal class Question
    {
        public enum QuestionsType
        {
            MCQ,
            Essay,
            TrueOrFalse
        }
        private int _questionID;
        private QuestionsType _questionType;
        private string _questionDescription;
        private string _correctAnswer;
        private string _studentAnswer;
        private string _choices;
        public int QuestionID
        {
            get { return _questionID; }
        }
        public string Choices
        {
            get { return _choices; }
            set { _choices = value; }
        }
        public QuestionsType QuestionType
        {
            get { return _questionType; }
            set
            {
                _questionType = value;
            }
        }
        public string QuestionDescription
        {
            get { return _questionDescription; }
            set
            {
                if(string.IsNullOrWhiteSpace(value))throw new ArgumentNullException("Value");
                _questionDescription = value;
            }
        }
        public string StudentAnswer
        { 
            get { return _studentAnswer; } 
            set { if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("Answer"); _studentAnswer = value; }
        }
        public string CorrectAnswer
        {
            get { return _correctAnswer; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException("Value");
                _correctAnswer = value;
            }
        }
        public Question(string correctAnswer, QuestionsType questionType,string questionDescription,string choices = "Not needed")
        {
            
            _choices = choices;
            CorrectAnswer = correctAnswer;
            _questionType = questionType;
            QuestionDescription = questionDescription;
            _questionID = IdGenerator.GenerateID();
        }
    }
}
