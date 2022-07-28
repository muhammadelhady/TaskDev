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
    internal class CustomerRepo : ICustomerRepo
    {
        private readonly DataContext _context;

        public CustomerRepo(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var customer = await _context.customers.FirstOrDefaultAsync();
                if(customer == null)
                    return false;
               customer.IsDeleted=true;
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Customer>> GetAll()
        {
            try
            {
                return await _context.customers.Where(x=>x.IsDeleted==false).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Customer> GetByPhone(string phone)
        {
            try
            {
                return await _context.customers.FirstOrDefaultAsync(x=>x.phone==phone&&x.IsDeleted==false);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> New(Customer customer)
        {
            try
            {
                customer.CreatedAt = DateTime.Now;
                await _context.customers.AddAsync(customer);
                return await _context.SaveChangesAsync()>0;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Update(Customer customer)
        {
            try
            {
                var old = await _context.customers.FirstOrDefaultAsync(x => x.Id == customer.Id);
                if (old == null)
                    return false;
                old.ModifiedAt = DateTime.Now;
                _context.Entry(old).CurrentValues.SetValues(customer);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
