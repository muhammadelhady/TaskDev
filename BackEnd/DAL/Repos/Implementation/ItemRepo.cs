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
    internal class ItemRepo : IItemRepo
    {
        private readonly DataContext _context;

        public ItemRepo(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var item = await _context.items.FirstOrDefaultAsync(x => x.Id == id);
                if (item == null)
                    return false;
                item.IsDeleted = true;
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Item>> GetAll()
        {
            try
            {
                return await _context.items.Where(x => x.IsDeleted == false).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Item> GetById(int id)
        {
            try
            {
                return await _context.items.FirstOrDefaultAsync(x=>x.Id==id&&x.IsDeleted==false);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Item>> GetStoreItems(int storeId)
        {
            try
            {
                return await _context.items.Where(x=>x.IsDeleted==false&&x.StoreId==storeId).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> New(Item item)
        {
            try
            {
                item.CreatedAt = DateTime.Now;
                await _context.items.AddAsync(item);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Update(Item item)
        {
            try
            {
                var old = await _context.items.FirstOrDefaultAsync(x => x.Id == item.Id);
                if (old == null)
                    return false;

                item.ModifiedAt = DateTime.Now;
                _context.Entry(old).CurrentValues.SetValues(item);
                return await _context.SaveChangesAsync() > 0;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
