using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Quiz_App_System.Entities;

namespace Quiz_App_System.Logic
{
    internal class StudentSystem
    {
        
        public void ViewCourses()
        {
            for (int i = 0; i < AdminSystem.Courses.Count; i++)
            {
                Console.WriteLine($"Course name: {AdminSystem.Courses[i].CourseName}\n");
                if (AdminSystem.Courses[i].Teacher != null)
                {
                    Console.WriteLine($"Teacher name: {AdminSystem.Courses[i].Teacher.Name}\n");
                }
                Console.WriteLine($"Course duration: {AdminSystem.Courses[i].CourseDuration} month\n");
                Console.WriteLine($"Number of lessons: {AdminSystem.Courses[i].NumberOfLessons}\n");
                Console.WriteLine($"Course category: {AdminSystem.Courses[i].CourseCategory}\n");
               
                Console.WriteLine("==============================");
                if (AdminSystem.Courses[i].Quizzes.Count > 0)
                {
                    Console.WriteLine($"Number of quizzes: {AdminSystem.Courses[i].Quizzes.Count}\n");
                    Console.WriteLine($"Quizzes in {AdminSystem.Courses[i].CourseName}: \n");
                    for (int j = 0; j < AdminSystem.Courses[i].Quizzes.Count; j++)
                    {
                        Console.WriteLine($"Quiz name: {AdminSystem.Courses[i].Quizzes[j].QuizName}.\n");
                        Console.WriteLine($"Quiz ID: {AdminSystem.Courses[i].Quizzes[j].QuizID}.\n");
                        Console.WriteLine("===========================");
                    }
                }
            }
        }
        public void EnrollCourse()
        {

            Console.WriteLine("Enter course ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            if(id <= 0) { Console.WriteLine("Invalid id.\n"); return; }
            for(int i = 0; i < AdminSystem.Courses.Count; i++)
            {
                if(id == AdminSystem.Courses[i].CourseID)
                {
                    if (AdminSystem.Courses[i].Teacher != null)
                    {
                        AuthenticationSystem.CurrentStudent.EnrolledCourses.Add(AdminSystem.Courses[i]);
                        AdminSystem.Courses[i].Students.Add(AuthenticationSystem.CurrentStudent);
                        Console.WriteLine("Course enrolled successfully.\n");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("This course has no teacher yet.\n");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("this course is not exist.\n");
                    return;
                }
            }
        }
        public void ViewEnrolledCourses()
        {
            if(AuthenticationSystem.CurrentStudent.EnrolledCourses.Count == 0)
            {
                Console.WriteLine("You have not enrolled any courses yet.\n");
                return;
            }
            for(int i = 0; i < AuthenticationSystem.CurrentStudent.EnrolledCourses.Count;i++)
            {
                Console.WriteLine($"Course name: {AuthenticationSystem.CurrentStudent.EnrolledCourses[i].CourseName}\n");
                Console.WriteLine($"Course ID: {AuthenticationSystem.CurrentStudent.EnrolledCourses[i].CourseID}\n");
                Console.WriteLine($"Teacher name: {AuthenticationSystem.CurrentStudent.EnrolledCourses[i].Teacher.Name}\n");
                Console.WriteLine($"Course duration: {AuthenticationSystem.CurrentStudent.EnrolledCourses[i].CourseDuration} month\n");
                Console.WriteLine($"Number of lessons: {AuthenticationSystem.CurrentStudent.EnrolledCourses[i].NumberOfLessons}\n");
                Console.WriteLine($"Course category: {AuthenticationSystem.CurrentStudent.EnrolledCourses[i].CourseCategory}\n");

                Console.WriteLine("==============================");
                if (AuthenticationSystem.CurrentStudent.EnrolledCourses[i].Quizzes.Count > 0)
                {
                    Console.WriteLine($"Number of quizzes: {AuthenticationSystem.CurrentStudent.EnrolledCourses[i].Quizzes.Count}\n");
                    Console.WriteLine($"Quizzes in {AuthenticationSystem.CurrentStudent.EnrolledCourses[i].CourseName}: \n");
                    for (int j = 0; j < AuthenticationSystem.CurrentStudent.EnrolledCourses[i].Quizzes.Count; j++)
                    {
                        Console.WriteLine(AuthenticationSystem.CurrentStudent.EnrolledCourses[i].Quizzes[j].QuizName + "\n");
                        Console.WriteLine("===========================");
                    }
                }
            }
        }
        public void TakeQuiz()
        {
           
            Quiz OriginalQuiz = null;
            List<int> questions = new List<int>();
            bool isTimeUp = false;
            Quiz quiz = null;
            bool isFound = false;
            if(AuthenticationSystem.CurrentStudent.EnrolledCourses.Count == 0)
            { Console.WriteLine("You have not enrolled any courses yet.\n"); return; }
            
            Console.WriteLine("Enter course ID: ");
            int courseID = Convert.ToInt32(Console.ReadLine());
            if(courseID <= 0 ) { Console.WriteLine("Invalid ID.\n"); return; }
            Console.WriteLine("Enter quiz ID: ");
            int quizID = Convert.ToInt32(Console.ReadLine());
            if (quizID <= 0)
            {
                Console.WriteLine("Invalid ID.\n");
                return;
            }
            for(int i = 0; i < AuthenticationSystem.CurrentStudent.EnrolledCourses.Count;i++)
            {
                if(courseID == AuthenticationSystem.CurrentStudent.EnrolledCourses[i].CourseID)
                {
                   
                    for(int j = 0; j < AuthenticationSystem.CurrentStudent.EnrolledCourses[i].Quizzes.Count;j++)
                    {
                        OriginalQuiz = AuthenticationSystem.CurrentStudent.EnrolledCourses[i].Quizzes[j];
                        if (quizID == AuthenticationSystem.CurrentStudent.EnrolledCourses[i].Quizzes[j].QuizID)
                        {
                            if (AuthenticationSystem.CurrentStudent.TakenQuizzes.Contains(AuthenticationSystem.CurrentStudent.EnrolledCourses[i].Quizzes[j]))
                            {
                                Console.WriteLine("You have taken this quiz once\n");
                                return;
                            }
                            quiz = new Quiz(AuthenticationSystem.CurrentStudent.EnrolledCourses[i].Quizzes[j].QuizName, AuthenticationSystem.CurrentStudent.EnrolledCourses[i].Quizzes[j].QuizDuration);
                            quiz.QuizName = AuthenticationSystem.CurrentStudent.EnrolledCourses[i].Quizzes[j].QuizName;
                            quiz.QuizID = AuthenticationSystem.CurrentStudent.EnrolledCourses[i].Quizzes[j].QuizID;
                            quiz.Course = AuthenticationSystem.CurrentStudent.EnrolledCourses[i].Quizzes[j].Course;
                            quiz.QuizDuration = AuthenticationSystem.CurrentStudent.EnrolledCourses[i].Quizzes[j].QuizDuration;
                            quiz.Questions = new List<Question>();

                            foreach (Question question in OriginalQuiz.Questions)
                            {
                                Question copiedQuestion = new Question(
                                    question.CorrectAnswer,
                                    question.QuestionType,
                                    question.QuestionDescription,
                                    question.Choices
                                );

                                quiz.Questions.Add(copiedQuestion);
                            }

                            isFound = true;
                            break;
                        }
                    }
                  
                }
                if (isFound)
                    break;
                
            }
            if(!isFound)
            {
                Console.WriteLine("Error.\n");
                return;
            }
            else
            {
                AuthenticationSystem.CurrentStudent.TakenQuizzes.Add(quiz);

                OriginalQuiz.Students.Add(AuthenticationSystem.CurrentStudent);
                int remainingSeconds = 20 * 60;
                System.Timers.Timer timer = new System.Timers.Timer(1000);
                timer.Elapsed += (sender, e) =>
                {
                    remainingSeconds--;
                    if (remainingSeconds <= 0)
                    {
                        timer.Stop();
                        isTimeUp = true;   
                    }
                };
                timer.Start();
                for (int i = 0; i < quiz.Questions.Count; i++)
                {
                    Console.WriteLine($"{i+1}- {quiz.Questions[i].QuestionDescription}\n");
                    if (quiz.Questions[i].QuestionType == Question.QuestionsType.MCQ || quiz.Questions[i].QuestionType == Question.QuestionsType.TrueOrFalse)
                    {
                        Console.WriteLine(quiz.Questions[i].Choices + "\n");
                    }
                }
                int choice = 0;
                
                while(!isTimeUp)
                {
                    if(questions.Count == AuthenticationSystem.CurrentStudent.TakenQuizzes[AuthenticationSystem.CurrentStudent.TakenQuizzes.Count - 1].Questions.Count)
                    {

                        if (AuthenticationSystem.CurrentStudent.TakenQuizzes[AuthenticationSystem.CurrentStudent.TakenQuizzes.Count - 1].Questions.Count > (AuthenticationSystem.CurrentStudent.TakenQuizzes[AuthenticationSystem.CurrentStudent.TakenQuizzes.Count - 1].Score))
                        {
                            AuthenticationSystem.CurrentStudent.TakenQuizzes[AuthenticationSystem.CurrentStudent.TakenQuizzes.Count - 1].Result = Quiz.Results.Fail;
                        }
                        else
                        {
                            AuthenticationSystem.CurrentStudent.TakenQuizzes[AuthenticationSystem.CurrentStudent.TakenQuizzes.Count - 1].Result = Quiz.Results.Pass;
                        }
                        Console.WriteLine($"Your score is: {AuthenticationSystem.CurrentStudent.TakenQuizzes[AuthenticationSystem.CurrentStudent.TakenQuizzes.Count - 1].Score} out of {AuthenticationSystem.CurrentStudent.TakenQuizzes[AuthenticationSystem.CurrentStudent.TakenQuizzes.Count - 1].Questions.Count*2}\n");
                        Console.WriteLine($"Result: {AuthenticationSystem.CurrentStudent.TakenQuizzes[AuthenticationSystem.CurrentStudent.TakenQuizzes.Count - 1].Result}");
                        return;
                    }
                    Console.WriteLine("Enter question number: \n");
                    
                    choice = Convert.ToInt32(Console.ReadLine());
                    if(choice <= 0 || choice > quiz.Questions.Count)
                    {
                        Console.WriteLine("Invalid choice try again\n");
                        continue;
                    }
                    if(!questions.Contains(choice))
                    {
                        questions.Add(choice);
                    }
                    else
                    {
                        Console.WriteLine("You have already answered this question.\n");
                        continue;
                    }

                        Console.WriteLine();
                    Console.WriteLine("Enter your answer: \n");
                    quiz.Questions[choice - 1].StudentAnswer = Console.ReadLine();
                    if(quiz.Questions[choice - 1].StudentAnswer.ToLower() == AuthenticationSystem.CurrentStudent.TakenQuizzes[AuthenticationSystem.CurrentStudent.TakenQuizzes.Count - 1].Questions[choice - 1].CorrectAnswer.ToLower())
                    {
                        AuthenticationSystem.CurrentStudent.TakenQuizzes[AuthenticationSystem.CurrentStudent.TakenQuizzes.Count - 1].Score += 2;
                    }
                }
                if (AuthenticationSystem.CurrentStudent.TakenQuizzes[AuthenticationSystem.CurrentStudent.TakenQuizzes.Count - 1].Questions.Count > (AuthenticationSystem.CurrentStudent.TakenQuizzes[AuthenticationSystem.CurrentStudent.TakenQuizzes.Count - 1].Score))
                {
                    AuthenticationSystem.CurrentStudent.TakenQuizzes[AuthenticationSystem.CurrentStudent.TakenQuizzes.Count - 1].Result = Quiz.Results.Fail;
                }
                else
                {
                    AuthenticationSystem.CurrentStudent.TakenQuizzes[AuthenticationSystem.CurrentStudent.TakenQuizzes.Count - 1].Result = Quiz.Results.Pass;
                }
                    Console.WriteLine("Time's up\n");
                Console.WriteLine($"Your score is: {AuthenticationSystem.CurrentStudent.TakenQuizzes[AuthenticationSystem.CurrentStudent.TakenQuizzes.Count - 1].Score} out of {AuthenticationSystem.CurrentStudent.TakenQuizzes[AuthenticationSystem.CurrentStudent.TakenQuizzes.Count - 1].Questions.Count * 2}\n");
                Console.WriteLine($"Your result: {AuthenticationSystem.CurrentStudent.TakenQuizzes[AuthenticationSystem.CurrentStudent.TakenQuizzes.Count - 1].Result}");
                return;

            }
        }
        public void ViewTakenQuizzes()
        {
            if(AuthenticationSystem.CurrentStudent.TakenQuizzes.Count == 0)
            {
                Console.WriteLine("You have not taken any quizzes yet.\n");
                return;
            }
            for(int i = 0; i < AuthenticationSystem.CurrentStudent.TakenQuizzes.Count; i++)
            {
                Console.WriteLine($"Quiz name: {AuthenticationSystem.CurrentStudent.TakenQuizzes[i].QuizName}\n");
                Console.WriteLine($"Quiz ID: {AuthenticationSystem.CurrentStudent.TakenQuizzes[i].QuizID}\n");
                Console.WriteLine($"Quiz duration: {AuthenticationSystem.CurrentStudent.TakenQuizzes[i].QuizDuration}\n");
                Console.WriteLine($"Quiz score: {AuthenticationSystem.CurrentStudent.TakenQuizzes[i].Score}\n");
                Console.WriteLine($"Quiz result: {AuthenticationSystem.CurrentStudent.TakenQuizzes[i].Result}\n");
                Console.WriteLine("=====================================");
            }
        }
        public void ViewQuizDetails()
        {
            if(AuthenticationSystem.CurrentStudent.TakenQuizzes.Count == 0)
            {
                Console.WriteLine("You have not taken any quizzes yet.\n");
                return;
            }
            Console.WriteLine("Enter quiz ID: \n");
            int quizID = Convert.ToInt32(Console.ReadLine());
            if(quizID <= 0)
            {
                Console.WriteLine("Invalid ID.\n");
                return;
            }
            for(int i = 0; i < AuthenticationSystem.CurrentStudent.TakenQuizzes.Count;i++)
            {
                if (quizID == AuthenticationSystem.CurrentStudent.TakenQuizzes[i].QuizID)
                {
                    Console.WriteLine($"Quiz name: {AuthenticationSystem.CurrentStudent.TakenQuizzes[i].QuizName}\n");
                    Console.WriteLine($"Course name: {AuthenticationSystem.CurrentStudent.TakenQuizzes[i].Course.CourseName}\n");
                    Console.WriteLine($"Quiz duration: {AuthenticationSystem.CurrentStudent.TakenQuizzes[i].QuizDuration} minutes");
                    Console.WriteLine($"Score: {AuthenticationSystem.CurrentStudent.TakenQuizzes[i].Score} out of {AuthenticationSystem.CurrentStudent.TakenQuizzes[i].Questions.Count * 2}\n");
                    Console.WriteLine($"Result: {AuthenticationSystem.CurrentStudent.TakenQuizzes[i].Result}\n");
                    Console.WriteLine("=========================");
                    Console.WriteLine("Quiz questions: \n");
                    for (int j = 0; j < AuthenticationSystem.CurrentStudent.TakenQuizzes[i].Questions.Count; j++)
                    {
                        Console.WriteLine($"{j + 1}- {AuthenticationSystem.CurrentStudent.TakenQuizzes[i].Questions[j].QuestionDescription}\n");
                        Console.WriteLine("============================================");
                    }
                    Console.WriteLine("Your answers: ");
                    for (int k = 0; k < AuthenticationSystem.CurrentStudent.TakenQuizzes[i].Questions.Count; k++)
                    {
                        Console.WriteLine($"{k + 1}- {AuthenticationSystem.CurrentStudent.TakenQuizzes[i].Questions[k].StudentAnswer}\n");
                        Console.WriteLine("===================================");
                    }
                    Console.WriteLine("Correct Answers: \n");
                    for (int w = 0; w < AuthenticationSystem.CurrentStudent.TakenQuizzes[i].Questions.Count; w++)
                    {
                        Console.WriteLine($"{w+1}- {AuthenticationSystem.CurrentStudent.TakenQuizzes[i].Questions[w].CorrectAnswer}\n");
                        Console.WriteLine("=======================================");
                    }

                }

            }
        }

    }
}
