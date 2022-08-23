using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class CategoryInvoiceRepo : IRepo<CategoryInvoice, int,bool>
    {
        private static TimologioContext db;

        public CategoryInvoiceRepo(TimologioContext db)
        {
            CategoryInvoiceRepo.db = db;
        }
        public bool Create(CategoryInvoice obj)
        {
            CategoryInvoiceRepo.db.CategoryInvoices.Add(obj);

            return CategoryInvoiceRepo.db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var catinvoice = CategoryInvoiceRepo.db.CategoryInvoices.Where(a => a.InvoiceId == id).FirstOrDefault();

            if (catinvoice == null)
            {
                return false;
            }

            CategoryInvoiceRepo.db.CategoryInvoices.Remove(catinvoice);

            return CategoryInvoiceRepo.db.SaveChanges() > 0;
        }

        public CategoryInvoice Get(int id)
        {
            return CategoryInvoiceRepo.db.CategoryInvoices.Where(a => a.InvoiceId == id).FirstOrDefault();
        }

        public List<CategoryInvoice> Gets()
        {
            return CategoryInvoiceRepo.db.CategoryInvoices.ToList();
        }

        public bool Update(CategoryInvoice obj)
        {
            var catinvoice = CategoryInvoiceRepo.db.CategoryInvoices.Where(a => a.InvoiceId == obj.InvoiceId).FirstOrDefault();

            if (catinvoice == null)
            {
                return false;
            }
            CategoryInvoiceRepo.db.Entry(catinvoice.Invoice.Customer).CurrentValues.SetValues(obj.Invoice.Customer);
            CategoryInvoiceRepo.db.Entry(catinvoice.Invoice).CurrentValues.SetValues(obj.Invoice);
            CategoryInvoiceRepo.db.Entry(catinvoice).CurrentValues.SetValues(obj);

            return CategoryInvoiceRepo.db.SaveChanges() > 0;
        }

    }
}
