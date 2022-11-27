using CashRegister.DBConnection;
using CashRegister.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Controllers
{
    public class ContactController
    {
        DatabaseContext context;
        public ContactController(DatabaseContext context)
        {
            this.context = context;
        }
        public Contact CreateContact(Contact c)
        {
            context.Contacts.Add(c);
            context.SaveChanges();
            return c;
        }
        public void DeleteContact(Contact c) {
        Contact Contact= context.Contacts.Find(c);
            context.Contacts.Remove(Contact);
            context.SaveChanges();
        }

        public void UpdateContact(Contact c) {
            context.Contacts.Update(c);
            context.SaveChanges();
        }

        public Contact GetContact(int id)
        {
            return context.Contacts.Find(id);
        }
    }
}
