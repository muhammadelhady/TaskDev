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
    internal class StoreRepo : IStoreRepo
    {
        private readonly DataContext _context;

        public StoreRepo(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var store = await _context.stores.FirstOrDefaultAsync(x=>x.Id==id);
                if(store == null)
                    return false;
                store.IsDeleted = true;
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Store>> GetAll()
        {
            try
            {
                return await _context.stores.Where(x => x.IsDeleted == false).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Store> GetById(int id)
        {
            try
            {
                return await _context.stores.FirstOrDefaultAsync(x => x.Id == id&&x.IsDeleted==false);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> New(Store store)
        {
            try
            {
                store.CreatedAt = DateTime.Now;
                await _context.stores.AddAsync(store);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Update(Store store)
        {
            try
            {
                var old = await _context.stores.FirstOrDefaultAsync(x => x.Id == store.Id);
                if (old == null)
                    return false;

                store.ModifiedAt = DateTime.Now;
                _context.Entry(old).CurrentValues.SetValues(store);
                return await _context.SaveChangesAsync() > 0;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
