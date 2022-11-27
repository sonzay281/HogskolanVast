using CashRegister.DBConnection;
using CashRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Controllers
{
    public class CategoryController
    {
        DatabaseContext context = new DatabaseContext();
       public CategoryController(DatabaseContext context)
        {
            this.context = context;
        }

        public Category CreateCategory(Category c)
        {
            context.Categories.Add(c);
            context.SaveChanges();
            return c;
        }
        public void DeleteCategory(Category c)
        {
            Category Category = context.Categories.Find(c);
            context.Categories.Remove(Category);
            context.SaveChanges();
        }

        public void UpdateCategory(Category c)
        {
            context.Categories.Update(c);
            context.SaveChanges();
        }

        public Category GetCategory(int id)
        {
            return context.Categories.Find(id);
        }
        public List<Category> GetAllCategory() 
        { 
            return context.Categories.ToList();
        }
    }
}
