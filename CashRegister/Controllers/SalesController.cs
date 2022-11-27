using CashRegister.DBConnection;
using CashRegister.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CashRegister.Controllers
{
    public class SaleController
    {
        DatabaseContext context;
       public SaleController(DatabaseContext context)
        {
            this.context = context;
        }

        public Sale CreateSale(Sale sale)
        {
            InventoryController inventoryController=new InventoryController(context);
            foreach(SaleItem s in sale.Items)
            {
                Inventory i = inventoryController.GetInventory(s.Inventory.Id);
                i.Quantity = i.Quantity-s.Quantity;
                int res= inventoryController.UpdateInventory(i);
                //implement validations
            }
            context.Sales.Add(sale);
            context.SaveChanges();
            return sale;
        }
        public void DeleteSale(Sale sale)
        {
            Sale Sale = context.Sales.Find(sale);
            context.Sales.Remove(Sale);
            context.SaveChanges();
        }

        public void UpdateSale(Sale sale)
        {
            context.Sales.Update(sale);
            context.SaveChanges();
        }

        public Sale GetSale(int id)
        {
            return context.Sales.Find(id);
        }
        public List<Sale> GetAllSalesReport(string groupBy="date")
        {
            switch (groupBy)
            {
                case "date":
                    return context.Sales.GroupBy(s=>s.SalesDateTime.Date).Select(s=>new Sale()
                    {
                        TotalAmount = s.Sum(s => s.TotalAmount),
                        DiscountAmount= s.Sum(s => s.DiscountAmount),
                        SalesDateTime=s.Key.Date
                    }).ToList();
                case "operator":
                    return context.Sales.GroupBy(s => s.Operator).Select(s => new Sale()
                    {
                        TotalAmount = s.Sum(s => s.TotalAmount),
                        DiscountAmount = s.Sum(s => s.DiscountAmount),
                        Operator = s.Key
                    }).ToList();
                case "customer":
                    return context.Sales.GroupBy(s => s.User).Select(s => new Sale()
                    {
                        TotalAmount = s.Sum(s => s.TotalAmount),
                        DiscountAmount = s.Sum(s => s.DiscountAmount),
                        User = s.Key
                    }).ToList();
                default:
                    return context.Sales.ToList();
            }
          
        }
    }
}
