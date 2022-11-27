using CashRegister.DBConnection;
using CashRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Controllers
{
    public class UserController
    {
        DatabaseContext context;
        public UserController(DatabaseContext databaseContext)
        {
            context = databaseContext;
        }

        public User CreateUser(User u)
        {
            try
            {
                context.Users.Add(u);
                context.SaveChanges();
                return u;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new User();
            }
        }
        public void DeleteUser(User u) {
            try
            {
                User user= context.Users.Find(u);
            context.Users.Remove(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void UpdateUser(User u) {
            try
            {
                context.Users.Update(u);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
          
        }

        public User GetUser(int id)
        {
            try
            {
                return context.Users.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new User();
            }
        }
        public User Login(string username,string password)
        {
            try
            {

                return context.Users.Where(u=>u.UserName==username && u.Password==password).FirstOrDefault();
        }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new User();
            }
}
    }
}
