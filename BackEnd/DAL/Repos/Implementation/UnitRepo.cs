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
    internal class UnitRepo : IUnitRepo
    {
        private readonly DataContext _context;

        public UnitRepo(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var unit = await _context.units.FirstOrDefaultAsync(x=>x.Id == id);
                if (unit == null)
                    return false;
                unit.IsDeleted = true;
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Unit>> GetAll()
        {
            try
            {
                return await _context.units.Where(x => x.IsDeleted == false).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Unit> GetById(int id)
        {
            try
            {
                return await _context.units.FirstOrDefaultAsync(x => x.Id == id&&x.IsDeleted==false);    
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> New(Unit unit)
        {
            try
            {
                unit.CreatedAt = DateTime.Now;
                await _context.units.AddAsync(unit);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Update(Unit unit)
        {
            try
            {
                var old = await _context.units.FirstOrDefaultAsync(x => x.Id == unit.Id);
                    if (old == null)
                    return false;

                unit.ModifiedAt = DateTime.Now;
                _context.Entry(old).CurrentValues.SetValues(unit);
                return await _context.SaveChangesAsync() > 0;
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
