using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Interfaces
{
    public interface IStoreRepo
    {
        public Task<bool> New(Store store);
        public Task<bool> Update(Store store);
        public Task<Store> GetById(int id);
        public Task<bool> Delete(int id);
        public Task<List<Store>> GetAll();
    }
}
