using CashRegister.DBConnection;
using CashRegister.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Controllers
{
    public class ProductController
    {
        DatabaseContext context;
        public ProductController(DatabaseContext context)
        {
            this.context = context;
        }

        public Product CreateProduct(Product p)
        {
            context.Products.Add(p);
            context.SaveChanges();
            return p;
        }
        public void DeleteProduct(Product p)
        {
            Product Product = context.Products.First(pro=>p.Id==pro.Id);
            context.Products.Remove(Product);
            context.SaveChanges();
        }

        public void UpdateProduct(Product p)
        {
            context.Products.Update(p);
            context.SaveChanges();
        }

        public Product GetProduct(int id)
        {
            return context.Products.Find(id);
        }
        public List<Product> GetAllProduct()
        {
            return context.Products.ToList();
        }
    }
}
