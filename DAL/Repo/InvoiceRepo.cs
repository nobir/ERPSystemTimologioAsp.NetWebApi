using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class InvoiceRepo : IRepo<Invoice, int,bool>
    {
        private static TimologioContext db;

        public InvoiceRepo(TimologioContext db)
        {
            InvoiceRepo.db = db;
        }
        public bool Create(Invoice obj)
        {
            InvoiceRepo.db.Invoices.Add(obj);

            return InvoiceRepo.db.SaveChanges() > 0;

        }

        public bool Delete(int id)
        {
            var invoice = InvoiceRepo.db.Invoices.Find(id);

            if (invoice == null)
            {
                return false;
            }
            invoice.CategoryInvoices.Clear();
            InvoiceRepo.db.Customers.Remove(invoice.Customer);
            InvoiceRepo.db.Invoices.Remove(invoice);

            return InvoiceRepo.db.SaveChanges() > 0;
        }

        public Invoice Get(int id)
        {
            return InvoiceRepo.db.Invoices.Find(id);
        }

        public List<Invoice> Gets()
        {
            return InvoiceRepo.db.Invoices.ToList();
        }

        public bool Update(Invoice obj)
        {

            var invoice = InvoiceRepo.db.Invoices.Where(a => a.Id == obj.Id).FirstOrDefault();

            if (invoice == null)
            {
                return false;
            }
            InvoiceRepo.db.Entry(invoice.Customer).CurrentValues.SetValues(obj.Customer);
            InvoiceRepo.db.Entry(invoice).CurrentValues.SetValues(obj);

            return InvoiceRepo.db.SaveChanges() > 0;
        }
    }
}
