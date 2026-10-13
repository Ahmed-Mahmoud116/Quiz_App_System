using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz_App_System.Entities;
namespace Quiz_App_System.Logic
{
    internal class TeacherSystem
    {
        public void AssignCourse()
        {
            Console.WriteLine("Enter course ID: \n");
            int id = Convert.ToInt32(Console.ReadLine());
            if (id <= 0)
            {
                Console.WriteLine("Invalid id.\n"); return;
            }
            Console.WriteLine();
            for (int i = 0; i < AdminSystem.Courses.Count; i++)
            {
                if(id == AdminSystem.Courses[i].CourseID)
                {
                    if (AdminSystem.Courses[i].Teacher != null)
                    {
                        Console.WriteLine("This course has a teacher already.\n");
                        return;
                    }
                    else
                    {
                        AuthenticationSystem.CurrentTeacher.AssignedCourses.Add(AdminSystem.Courses[i]);
                        AdminSystem.Courses[i].Teacher = AuthenticationSystem.CurrentTeacher;
                        Console.WriteLine("Course has been assigned successfully!\n");
                        return;
                    }
                }
                
            }

            Console.WriteLine("This course is not exist.\n");
            return;
        }
        public void ViewAssignedCourses()
        {
            if(AuthenticationSystem.CurrentTeacher.AssignedCourses.Count == 0)
            {
                Console.WriteLine("You have not assigned any courses yet.\n");
                return;
            }
            for(int i = 0; i < AuthenticationSystem.CurrentTeacher.AssignedCourses.Count; i++)
            {
                Console.WriteLine($"Course name: {AuthenticationSystem.CurrentTeacher.AssignedCourses[i].CourseName}\n");
                Console.WriteLine($"Course category: {AuthenticationSystem.CurrentTeacher.AssignedCourses[i].CourseCategory}\n");
                Console.WriteLine($"Course duration: {AuthenticationSystem.CurrentTeacher.AssignedCourses[i].CourseDuration} months\n");
                Console.WriteLine($"Number of lessons: {AuthenticationSystem.CurrentTeacher.AssignedCourses[i].NumberOfLessons}\n");
                Console.WriteLine($"Number of quizzes: {AuthenticationSystem.CurrentTeacher.AssignedCourses[i].Quizzes.Count}\n");
            }
        }
        public void ViewUnassignedCourses()
        {
            bool isExist = false;
            if (AdminSystem.Courses.Count == 0)
            {
                Console.WriteLine("There is no courses yet.\n");
                return;
            }
            for (int i = 0; i < AdminSystem.Courses.Count; i++)
            {
                if (AdminSystem.Courses[i].Teacher == null)
                {
                    isExist = true;
                    Console.WriteLine($"Course name: {AdminSystem.Courses[i].CourseName}\n");
                    Console.WriteLine($"Course ID : {AdminSystem.Courses[i].CourseID}\n");
                    Console.WriteLine($"Course category: {AdminSystem.Courses[i].CourseCategory}\n");
                    Console.WriteLine($"Course duration: {AdminSystem.Courses[i].CourseDuration} months\n");

                }
            }
            if(!isExist)
            {
                Console.WriteLine("All courses are assigned to other teachers.\n");
                return;
            }
        }
        public void ViewQuizDetails()
        {
            Console.WriteLine("Enter quiz ID: \n");
            int id = Convert.ToInt32(Console.ReadLine());
            if (id <= 0)
            {
                Console.WriteLine("Invalid id.\n");
                return;
            }
            for (int i = 0; i < AuthenticationSystem.CurrentTeacher.AssignedCourses.Count; i++)
            {
                for (int j = 0; j < AuthenticationSystem.CurrentTeacher.AssignedCourses[i].Quizzes.Count; j++)
                {
                    if (id == AuthenticationSystem.CurrentTeacher.AssignedCourses[i].Quizzes[j].QuizID)
                    {
                        Console.WriteLine($"Quiz name: {AuthenticationSystem.CurrentTeacher.AssignedCourses[i].Quizzes[j].QuizName}\n");
                        Console.WriteLine($"Quiz ID: {AuthenticationSystem.CurrentTeacher.AssignedCourses[i].Quizzes[j].QuizID}\n");
                        Console.WriteLine($"Quiz duration: {AuthenticationSystem.CurrentTeacher.AssignedCourses[i].Quizzes[j].QuizDuration} minutes");
                        Console.WriteLine($"Number of students: {AuthenticationSystem.CurrentTeacher.AssignedCourses[i].Quizzes[j].Students.Count}\n");
                        Console.WriteLine("===================================\n");
                        Console.WriteLine("Quiz Questions: \n");
                        for (int k = 0; k < AuthenticationSystem.CurrentTeacher.AssignedCourses[i].Quizzes[j].Questions.Count; k++)
                        {
                            Console.WriteLine($"{j + 1}- {AuthenticationSystem.CurrentTeacher.AssignedCourses[i].Quizzes[j].Questions[k].QuestionDescription} -> Question ID: {AuthenticationSystem.CurrentTeacher.AssignedCourses[i].Quizzes[j].Questions[k].QuestionID}\n");
                            Console.WriteLine("===================================\n");
                        }
                    }
                }
            }
        }
        public void CreateQuiz()
        {
            if (AuthenticationSystem.CurrentTeacher.AssignedCourses.Count == 0)
            {
                Console.WriteLine("You can't create quiz if you haven't assigned a course. \n");
                return;
            }
            Console.WriteLine("Enter course ID: \n");
            int id = Convert.ToInt32(Console.ReadLine());
            if (id <= 0) { Console.WriteLine("Invalid id.\n"); return; }
            for(int i = 0; i < AuthenticationSystem.CurrentTeacher.AssignedCourses.Count; i++)
            {
                if(id == AuthenticationSystem.CurrentTeacher.AssignedCourses[i].CourseID)
                {
                    Console.WriteLine("Enter quiz name: \n");
                    string name = Console.ReadLine();
                    Console.WriteLine();

                    int duration = 20;
                    Console.WriteLine();
                    Console.WriteLine("Enter number of questions: \n");
                    int n = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    if(n <= 0)
                    {
                        Console.WriteLine("Invalid number.\n");
                        return;
                    }
                    Quiz quiz = new Quiz(name, duration);
                    for (int j = n - 1; j >= 0; j--)
                    {

                        Console.WriteLine($"Enter question type for question number {n - j}: \n");
                        Console.WriteLine("1- MCQ");
                        Console.WriteLine("2- True/False");
                        Console.WriteLine("3- Essay");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        Question.QuestionsType type = new Question.QuestionsType();
                        string choose = null;
                        switch(choice)
                        {
                            case 1:
                                type = Question.QuestionsType.MCQ; break;
                            case 2:
                                type = Question.QuestionsType.TrueOrFalse; break;
                            case 3:
                                type = Question.QuestionsType.Essay; break;
                            default:
                                Console.WriteLine("Invalid type try again.\n");
                                while(choice != 1 || choice != 2 || choice != 3)
                                {
                                    choice = Convert.ToInt32(Console.ReadLine());
                                    if(choice == 1)
                                    {
                                        type = Question.QuestionsType.MCQ; break;
                                    }
                                    else if(choice == 2)
                                    {
                                        type = Question.QuestionsType.TrueOrFalse; break;
                                    }
                                    else if(choice == 3)
                                    {
                                        type = Question.QuestionsType.Essay; break;
                                    }
                                }
                                break;
                        }
                        Console.WriteLine($"Enter question description for question number{n-j}: \n");
                        string description = Console.ReadLine();
                     
                        
                        if (type == Question.QuestionsType.MCQ || type == Question.QuestionsType.TrueOrFalse)
                        {
                            Console.WriteLine($"Enter choices for question number {n-j}: \n");
                            choose = Console.ReadLine();
                            
                            
                        }

                        Console.WriteLine($"Enter the correct answer for question number {n-j}: \n");
                        string ans = Console.ReadLine();
                        Question question = new Question(ans, type, description, choose);
                        quiz.Questions.Add(question);
                    }
                    AuthenticationSystem.CurrentTeacher.AssignedCourses[i].Quizzes.Add(quiz);
                    quiz.Course = AuthenticationSystem.CurrentTeacher.AssignedCourses[i];
                    Console.WriteLine($"Quiz {quiz.QuizID} was added successfully!\n");
                    return;
                }
                else
                {
                    Console.WriteLine("You have not assigned this course.\n");
                    return;
                }
            }
        }
        public void EditQuiz()
        {
            bool isFound = false;
            if(AuthenticationSystem.CurrentTeacher.AssignedCourses.Count == 0)
            {
                Console.WriteLine("You have not assigned any courses yet.\n");
                return;
            }
            Console.WriteLine("Enter quiz ID: \n");
            int id = Convert.ToInt32(Console.ReadLine());
            if (id <= 0) { Console.WriteLine("Invalid id.\n"); return; }
            Console.WriteLine();
            for (int i = 0; i < AuthenticationSystem.CurrentTeacher.AssignedCourses.Count; i++)
            {
                for(int j = 0; j < AuthenticationSystem.CurrentTeacher.AssignedCourses[i].Quizzes.Count; j++)
                {
                    if(id == AuthenticationSystem.CurrentTeacher.AssignedCourses[i].Quizzes[j].QuizID)
                    {
                        isFound = true;
                        if (AuthenticationSystem.CurrentTeacher.AssignedCourses[i].Quizzes[j].Students.Count == 0)
                        {
                            Console.WriteLine("1- Remove question.\n");
                            Console.WriteLine("2- Add question.\n");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            switch(choice)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("Enter question ID: \n");
                                        int questionID = Convert.ToInt32(Console.ReadLine());
                                        if(questionID <= 0)
                                        {
                                            Console.WriteLine("Invalid id.\n");
                                            return;
                                        }
                                        for(int k = 0; k < AuthenticationSystem.CurrentTeacher.AssignedCourses[i].Quizzes[j].Questions.Count;k++)
                                        {
                                            if(questionID == AuthenticationSystem.CurrentTeacher.AssignedCourses[i].Quizzes[j].Questions[k].QuestionID)
                                            {
                                                AuthenticationSystem.CurrentTeacher.AssignedCourses[i].Quizzes[j].Questions.Remove(AuthenticationSystem.CurrentTeacher.AssignedCourses[i].Quizzes[j].Questions[k]);
                                                Console.WriteLine("Question has been removed successfully!\n");
                                                return;
                                            }
                                        }
                                        Console.WriteLine("This question is not exist.\n");
                                        return;
                                    }
                                    
                                case 2:
                                    {

                                        Console.WriteLine($"Enter question type: \n");
                                        Console.WriteLine("1- MCQ");
                                        Console.WriteLine("2- True/False");
                                        Console.WriteLine("3- Essay");
                                        int choice2 = Convert.ToInt32(Console.ReadLine());
                                        Question.QuestionsType type = new Question.QuestionsType();
                                        string choose = null;
                                        
                                            switch (choice2)
                                            {
                                                case 1:
                                                    type = Question.QuestionsType.MCQ; break;
                                                case 2:
                                                    type = Question.QuestionsType.TrueOrFalse; break;
                                                case 3:
                                                    type = Question.QuestionsType.Essay; break;
                                                default:
                                                    Console.WriteLine("Invalid type try again.\n");
                                                    while (choice != 1 || choice != 2 || choice != 3)
                                                    {
                                                        choice = Convert.ToInt32(Console.ReadLine());
                                                        if (choice == 1)
                                                        {
                                                            type = Question.QuestionsType.MCQ; break;
                                                        }
                                                        else if (choice == 2)
                                                        {
                                                            type = Question.QuestionsType.TrueOrFalse; break;
                                                        }
                                                        else if (choice == 3)
                                                        {
                                                            type = Question.QuestionsType.Essay; break;
                                                        }
                                                    }
                                                    break;
                                            }
                                            Console.WriteLine($"Enter question description: \n");
                                            string description = Console.ReadLine();
                                            if (string.IsNullOrWhiteSpace(description)) { Console.WriteLine("Invalid input.\n"); return; }

                                            if (type == Question.QuestionsType.MCQ || type == Question.QuestionsType.TrueOrFalse)
                                            {
                                                Console.WriteLine($"Enter choices: \n");
                                                choose = Console.ReadLine();
                                                if (string.IsNullOrWhiteSpace(choose)) { Console.WriteLine("Invalid input.\n"); return; }
                                            }
                                           
                                            Console.WriteLine($"Enter the correct answer: \n");
                                            string ans = Console.ReadLine();
                                            Question question = new Question(ans, type, description, choose);
                                            AuthenticationSystem.CurrentTeacher.AssignedCourses[i].Quizzes[j].Questions.Add(question);
                                            Console.WriteLine("Question was added successfully.\n");
                                            return;
                                        
                                    }

                                
                                default:
                                    Console.WriteLine("Invalid choice.\n");
                                    return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Can't edit this quiz because some students have already taken it.\n");
                            return;
                        }
                    }
                  
                }
                if(!isFound)
                {
                    Console.WriteLine("This quiz is not exist.\n");
                    return;
                }
            }
        }
    }
}
