using Quiz_App_System.Configuration;
using Quiz_App_System.Logic;
using Quiz_App_System.Menus;

namespace Quiz_App_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            AdminSystem adminSystem = new AdminSystem();
            MainMenu mainMenu = new MainMenu();
            SystemInitializer.InitializeAdmins();
            mainMenu.Show();
        }
    }
}
