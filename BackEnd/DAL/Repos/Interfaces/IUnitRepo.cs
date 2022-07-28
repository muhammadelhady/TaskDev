using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Interfaces
{
    public interface IUnitRepo
    {
        public Task<bool> New(Unit unit);
        public Task<bool> Update(Unit unit);
        public Task<Unit> GetById(int id);
        public Task<bool> Delete(int id);
        public Task<List<Unit>> GetAll();
    }
}
