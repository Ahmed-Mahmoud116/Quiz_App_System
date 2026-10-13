using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz_App_System.Logic;
namespace Quiz_App_System.Menus
{
    internal class MainMenu
    {
       private static GoToMenus GoToMenus = new GoToMenus();
        private static AdminSystem adminSystem = new AdminSystem();
        public void Show()
        {
            int choice = 0;
            Console.WriteLine("1- Admin\n");
            Console.WriteLine("2- Student\n");
            Console.WriteLine("3- Teacher\n");
            Console.WriteLine("0- Exit\n");
            while (true)
            {
                Console.Write("Choose: ");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        adminSystem.ViewAdmins();
                        GoToMenus.Admin();
                        break;
                    case 2:
                        GoToMenus.Student();
                        break;
                    case 3:
                        GoToMenus.Teacher();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid input\n");
                        break;
                }
            }
        }
    }
}
