using DAL.Data;
using DAL.Entites;
using DAL.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Implementation
{
    internal class InvoiceRepo : IInvoiceRepo
    {
        private readonly DataContext _context;

        public InvoiceRepo(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var invoice = await _context.invoices.FirstOrDefaultAsync(x => x.Id == id);
                if (invoice == null)
                    return false;
                invoice.IsDeleted=true;
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Invoice>> GetAll()
        {
            try
            {
                return await _context.invoices.Where(x => x.IsDeleted == false).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Invoice> GetById(int id)
        {
            try
            {
                return await _context.invoices.FirstOrDefaultAsync(x=>x.Id==id&&x.IsDeleted==false);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Invoice>> GetCustomerInvoices(int customerId)
        {
            try
            {
                return await _context.invoices.Where(x =>x.CustomerId==customerId&& x.IsDeleted == false).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> New(Invoice invoice)
        {
            try
            {
                invoice.CreatedAt = DateTime.Now;
                await _context.invoices.AddAsync(invoice);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Update(Invoice invoice)
        {
            try
            {
                var old = await _context.units.FirstOrDefaultAsync(x => x.Id == invoice.Id);
                if (old == null)
                    return false;

                invoice.ModifiedAt = DateTime.Now;
                _context.Entry(old).CurrentValues.SetValues(invoice);
                return await _context.SaveChangesAsync() > 0;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
