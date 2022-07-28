using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Interfaces
{
    public interface IItemRepo
    {
        public Task<bool> New(Item item);
        public Task<bool> Update(Item item);
        public Task<Item> GetById(int id);
        public Task<bool> Delete(int id);
        public Task<List<Item>> GetAll();
        public Task<List<Item>> GetStoreItems(int storeId);
    }
}
