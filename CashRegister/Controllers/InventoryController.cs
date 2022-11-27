using CashRegister.DBConnection;
using CashRegister.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Controllers
{
    public class InventoryController
    {
        DatabaseContext context;
        public InventoryController(DatabaseContext databaseContext) { 
        this.context = databaseContext;
        }
        public Inventory CreateInventory(Inventory i)
        {
            context.Inventories.Add(i);
            context.SaveChanges();
            return i;
        }
        public void DeleteInventory(Inventory i)
        {
            Inventory Inventory = context.Inventories.Find(i);
            context.Inventories.Remove(Inventory);
            context.SaveChanges();
        }

        public int UpdateInventory(Inventory i)
        {
           context.Inventories.Update(i);
           return context.SaveChanges();
        }

        public Inventory GetInventory(int id)
        {
            return context.Inventories.Find(id);
        }

        public List<Inventory> GetAllInventory()
        {
            return context.Inventories.Include(i=>i.Product).ToList();
        }
    }
}
