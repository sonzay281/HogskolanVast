using CashRegister.Controllers;
using CashRegister.DBConnection;
using CashRegister.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Views.Admin
{
    public class AdminUserInterface
    {
        DatabaseContext context=new DatabaseContext();
        public AdminUserInterface(DatabaseContext databaseContext ) {
        this.context = databaseContext;
        }
        public void GreetAdmin(User u)
        {
          
            int exit = 0;
            while (exit==0)
            {
                Console.Clear();
                Console.WriteLine("Welcome {0} \n", u.Name);
                Console.WriteLine("1. Sales \n2. Report \n3. Inventory \n4. Products \n5. New Product");
                Console.WriteLine("6. New Inventory \n7. New User \n8. Exit\n");

                Console.Write("Select operation:");
                int operation = 0;
                operation=int.Parse(Console.ReadLine());

                if (operation != 0)
                {
                    switch (operation)
                    {
                        case 1:
                            AddSales(u,context);
                            break;
                        
                        case 2:
                            ReportInterface(u, context);
                            break;
                        
                        case 3:
                            InventoryListInterface(context); 
                            break;
                        
                        case 4:
                            ProductListInterface(context); 
                            break;

                        case 5:
                            NewProduct(context);
                            break;
                        
                        case 6:
                            NewInventory(context);
                            break;
                        
                        case 7:
                            NewUser(context);
                            break;

                        case 8:
                            Console.Clear();
                            Console.WriteLine("Thank you!");
                            exit = 1;
                            break;
                    }
                }
            }
        }

        private void NewUser(DatabaseContext databaseContext)
        {
            Console.Clear();
            UserController userController = new UserController(databaseContext);
            ContactController contactController = new ContactController(databaseContext);
            User user = new User();
            Contact contact = new Contact() { City=null};
            Console.WriteLine("========================\nNew User Registration\n========================");
            Console.Write("Enter User type([0]USER,[1]OPERATOR):"); int userType= int.Parse(Console.ReadLine());
            user.UserType = userType==0?UserTypes.USER:UserTypes.OPERATOR;

            Console.WriteLine("\nEnter Contact detail:");
            Console.Write("\tEmail:");contact.Email = Console.ReadLine();
            Console.Write("\tPhone number:"); contact.Phone= Console.ReadLine();
            Console.Write("\tAddress:"); contact.Address= Console.ReadLine();
            Console.Write("\tCity:");contact.City = Console.ReadLine();
            Console.WriteLine("\n Enter User Detail");
            Console.Write("\tName:"); user.Name= Console.ReadLine();
            Console.Write("\tDesignation:"); user.Designation = Console.ReadLine();
            Console.Write("\tUsername:"); user.UserName = Console.ReadLine();
            Console.Write("\tPassword:"); user.Password = Console.ReadLine();

            Contact c= contactController.CreateContact(contact);
            user.Contact = c;

            User result = userController.CreateUser(user);
            if (result.Id != 0)
            {
                Console.WriteLine("User Added!");
                Console.Write("Press any key to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Something went wrong.");
            }
            Console.ReadLine();

        }
        private void ProductListInterface(DatabaseContext databaseContext)
        {
            Console.Clear();
            ProductController productController = new ProductController(databaseContext);
            CategoryController categoryController=new CategoryController(databaseContext);

            List<Product> products= productController.GetAllProduct();
            Console.WriteLine("List of Products");
            Console.WriteLine("ID\tName");
            foreach (Product p in products)
            {
                Console.WriteLine("{0}\t{1}", p.Id, p.Name);
            }
            Console.WriteLine("\n=========================================================");
            Console.WriteLine("1.Add new \t2.Update Product \t 3.Exit");
            Console.WriteLine("=============================================================");
            Console.Write("Select operation:");
            string opt = Console.ReadLine();
            int invId;
            Product product;
            switch (opt)
            {
                case "1":
                    NewProduct(databaseContext); break;

                case "2":
                    Console.Write("\nEnter product ID:"); invId = int.Parse(Console.ReadLine());
                    product = productController.GetProduct(invId);
                    if (product != null)
                    {
                    List<Category> categories=categoryController.GetAllCategory();
                        Console.WriteLine("Available categories:");
                       
                        foreach (Category c in categories)
                        {
                            Console.WriteLine("{0}.{1}", c.Id, c.CategoryName);
                        }
                        Console.Write("\nEnter Category ID:"); int catId = int.Parse(Console.ReadLine());
                        Category cat = categories.Find(c => c.Id == catId);
                        if (cat != null)
                        {
                            product.Category = cat;
                        }
                        else
                        {
                            Console.WriteLine("Invalid category id.");
                            break;
                        }
                        Console.Write("\nEnter name:"); string name = Console.ReadLine();
                        product.Name = name;
                        
                        productController.UpdateProduct(product);
                        Console.WriteLine("Product name updated.");
                    }
                    break;
                default:
                    break;


            }

            Console.Write("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        private void InventoryListInterface(DatabaseContext databaseContext)
        {
            Console.Clear();
            InventoryController inventoryController = new InventoryController(databaseContext);
            List<Inventory> inventories = inventoryController.GetAllInventory();
            Console.WriteLine("List of Inventories");
            Console.WriteLine("ID\tQty\tPID\tName");
            foreach (Inventory i in inventories)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", i.Id, i.Quantity, i.Product.Id, i.Product.Name);
            }
            Console.WriteLine("\n=======================================================================");
            Console.WriteLine("1.Add new \t2.Update Inventory \t 3.Delete inventory \t 4. Exit");
            Console.WriteLine("=======================================================================");
            Console.Write("Select operation:");
            string opt = Console.ReadLine();
            int invId;
            Inventory inventory;
            switch (opt)
            {
                case "1":
                    NewInventory(databaseContext); break;

                case "2":
                    Console.Write("\nEnter inventory ID:");  invId = int.Parse(Console.ReadLine());
                    inventory = inventoryController.GetInventory(invId);
                    if (inventory != null)
                    {
                        Console.Write("\nEnter additional quantity:"); int qty = int.Parse(Console.ReadLine());
                        inventory.Quantity += qty;
                        inventoryController.UpdateInventory(inventory);
                        Console.WriteLine("Quantity updated.");
                    }
                    break;
                case "3":
                    Console.Write("\nEnter inventory ID:");  invId = int.Parse(Console.ReadLine());
                    inventory = inventoryController.GetInventory(invId);
                    if (inventory != null)
                    {
                        inventoryController.DeleteInventory(inventory);
                        Console.WriteLine("Inventory Deleted.");
                    }
                    break;
                default:
                    break;


            }

            Console.Write("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }
        
        private void NewInventory(DatabaseContext databaseContext)
        {
            Console.Clear();
            ProductController productController = new ProductController(databaseContext);
            InventoryController inventoryController = new InventoryController(databaseContext);
            Inventory i = new Inventory();
            Console.WriteLine("Available products:");
            List<Product> products= productController.GetAllProduct();
            foreach (Product p in products)
            {
                Console.WriteLine("{0}.{1}", p.Id, p.Name);
            }

            Console.Write("\nEnter Product ID:");
            int productId = int.Parse(Console.ReadLine());
            i.Product = products.Find(p => p.Id == productId);
            Console.Write("\nEnter Product Price:");i.Price=int.Parse(Console.ReadLine());
            Console.Write("\nEnter  Product Discount:"); i.Discount = int.Parse(Console.ReadLine());
            Console.Write("Quantity:"); i.Quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter expiry days:");
            int days=int.Parse(Console.ReadLine());
            i.ExpiryDate = DateTime.Now.AddDays(days).Date;
            Console.WriteLine(i.ExpiryDate);
           
            if (inventoryController.CreateInventory(i).Id != null)
            {
                Console.Clear();
                Console.WriteLine("Inventory Added!");
            }

        }

        private void NewProduct(DatabaseContext databaseContext)
        {
            Console.Clear();
            ProductController productController=new ProductController(databaseContext);
            CategoryController categoryController=new CategoryController(databaseContext);
            Product p = new Product();
            Console.WriteLine("Available categories:");
            List<Category> categories = categoryController.GetAllCategory();
            foreach (Category cat in categories)
            {
                Console.WriteLine("{0}.{1}",cat.Id,cat.CategoryName);
            }
            
            Console.Write("\nEnter Category ID:");
            int catId= int.Parse(Console.ReadLine());
            p.Category = categories.Find(c=>c.Id==catId);
            Console.Write("\nEnter Product Name:"); 
            p.Name = Console.ReadLine();
            Console.Write("\nEnter Product Description:"); 
            p.Description= Console.ReadLine();

            if (productController.CreateProduct(p).Id != null)
            {
                Console.WriteLine("Product Added!");
                Console.Write("Press any key to continue...");
                Console.ReadLine();
            }

        }

        private void AddSales(User u,DatabaseContext databaseContext)
        {
            Console.Clear();
            SaleController saleController = new SaleController(databaseContext);
            InventoryController inventoryController = new InventoryController(databaseContext);
            UserController userController = new UserController(databaseContext);

            Sale sale = new Sale();
            sale.SalesDateTime = DateTime.Now;
            sale.Operator = u;

            Console.WriteLine("Available products:");
            List<Inventory> inventories= inventoryController.GetAllInventory();
            foreach (Inventory i in inventories)
            {
                Console.WriteLine("{0}.{1}", i.Id, i.Product.Name);
            }
            List<SaleItem> saleItems = new List<SaleItem>();
            bool isContinue = true;
            while (isContinue)
            {
                SaleItem saleItem = new SaleItem();
                Console.Write("Enter product Id:");int invId = int.Parse(Console.ReadLine());
                saleItem.Inventory = inventories.Find(i=>i.Id== invId);
                Console.Write("Enter quantity:");
                saleItem.Quantity = int.Parse(Console.ReadLine());
                saleItems.Add(saleItem);
                sale.TotalAmount += saleItem.Inventory.Price*saleItem.Quantity;
                sale.DiscountAmount += saleItem.Inventory.Discount * saleItem.Quantity;

                Console.WriteLine("Add more items?[Y/N]");
                string opt = Console.ReadLine();
                if (opt.Equals("N")||opt.Equals("n"))
                {
                    Console.WriteLine("Have membership?[Y/N]");
                    string havememberShip = Console.ReadLine();

                    if (havememberShip.Equals("Y") || havememberShip.Equals("y"))
                    {
                        Console.Write("Enter membership id:");
                        int userId=int.Parse(Console.ReadLine());
                        User usr = userController.GetUser(userId);
                        if(usr!= null) {
                            sale.User = usr;
                        }
                    }
                    sale.Items= saleItems;
                    Sale saleDetail=saleController.CreateSale(sale);
                    isContinue = false;
                    Console.WriteLine("Print Receipt?[Y/N]");
                    opt = Console.ReadLine();
                    if (opt.Equals("Y") || opt.Equals("y"))
                    {
                        Console.Clear();
                        Console.WriteLine("Operator : {0}", sale.Operator.Name);
                        Console.WriteLine("=============================");
                        Console.WriteLine("Amt \t Products");
                        float total = 0;
                        float totalSum = 0;
                        
                        foreach(SaleItem s in sale.Items)
                        {
                            float sum = s.Quantity * s.Inventory.Price;
                            totalSum += sum;
                            Console.WriteLine("{2} \t {0}*{1}",s.Inventory.Product.Name,s.Quantity,sum);
                            Console.WriteLine("\t  (discount:{0}*{1})",s.Inventory.Discount,s.Quantity);
                            total += (s.Quantity * (s.Inventory.Price - s.Inventory.Discount));
                        }
                        Console.WriteLine("{0} \t :Grand Total", total);
                        Console.WriteLine("=============================");

                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
            }
        }
        
        private void ReportInterface(User u,DatabaseContext context)
        {
            SaleController saleController = new SaleController(context);
            int exit = 0;
            while (exit == 0)
            {
                Console.Clear();
                Console.WriteLine("Reports\n========================");
                Console.WriteLine("1. Daily Sales Report \t2.Operator Report\t3. Customer Sales Report \t4. Back");
                Console.Write("Select option:"); int opt = int.Parse(Console.ReadLine());

                switch (opt)
                {
                    case 1:
                        {

                            Console.WriteLine("Daily Sales Report");
                            List<Sale> sales = saleController.GetAllSalesReport();
                            foreach (Sale sale in sales)
                            {
                                Console.WriteLine("{0} \t {1}",sale.SalesDateTime.Date,sale.TotalAmount-sale.DiscountAmount);
                            }
                            Console.Write("Press any key to continue...");
                            Console.ReadLine();
                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine("Operator Sales Report");
                            List<Sale> sales = saleController.GetAllSalesReport("operator");
                            foreach (Sale sale in sales)
                            {
                                Console.WriteLine("{1} \t {0}", sale.Operator.Name, sale.TotalAmount - sale.DiscountAmount);
                            }
                            Console.Write("Press any key to continue...");
                            Console.ReadLine();
                            break;
                        }

                    case 3:
                        {
                            Console.WriteLine("Customer Sales Report");
                            List<Sale> sales = saleController.GetAllSalesReport("customer");
                            foreach (Sale sale in sales)
                            {
                                Console.WriteLine("{1} \t {0}", sale.User!=null?sale.User.Name:"Unregistered Customer", sale.TotalAmount - sale.DiscountAmount);
                            }
                            Console.Write("Press any key to continue...");
                            Console.ReadLine();
                            break;
                        }
                    default:
                        exit = 1;
                        break;
                }

            }
        }
    }

}
