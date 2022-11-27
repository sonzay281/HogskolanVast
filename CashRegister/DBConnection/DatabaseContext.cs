using CashRegister.Models;
using Microsoft.EntityFrameworkCore;


namespace CashRegister.DBConnection
{
    public class DatabaseContext:DbContext
    {
       public DbSet<Category> Categories { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource = E:\University West\Fullstack  Developer\Programs\CashRegister\CashRegisterDb.db");
        }
    
    }


}
