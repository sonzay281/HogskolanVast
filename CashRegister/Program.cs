using CashRegister.Controllers;
using CashRegister.DBConnection;
using CashRegister.Models;
using CashRegister.Views.Admin;

namespace CashRegister
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseContext databaseContext=new DatabaseContext();
            UserController userController =new UserController(databaseContext);
            Console.Clear();
            Console.WriteLine("Please Login!");
            Console.Write("Username:");string userName= Console.ReadLine();
            Console.Write("Password:");string password= Console.ReadLine();
            User user = userController.Login(userName, password);
            if (user != null)
            {
                if (user.UserType.Equals(UserTypes.OPERATOR))
                {
                    new AdminUserInterface(databaseContext).GreetAdmin(user);
                }
                else
                {
                    Console.WriteLine("Normal User");
                    Console.Write("Press any key to continue...");
                    Console.ReadLine();
                    //send to normal user menu
                }
            }
            else
                Console.WriteLine("Invalid username and password!");
        }
    }
}