using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Interfaces
{
    public interface IInvoiceRepo
    {
        public Task<bool> New(Invoice invoice);
        public Task<bool> Update(Invoice invoice);
        public Task<Invoice> GetById(int id);
        public Task<List<Invoice>> GetCustomerInvoices(int customerId);
        public Task<bool> Delete(int id);
        public Task<List<Invoice>> GetAll();
    }
}
