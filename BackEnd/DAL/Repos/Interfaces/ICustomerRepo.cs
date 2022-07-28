using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Interfaces
{
    public interface ICustomerRepo
    {
        public Task<bool> New(Customer customer);
        public Task<bool> Update(Customer customer);
        public Task<Customer> GetByPhone(string phone);
        public Task<bool> Delete(int id);
        public Task<List<Customer>> GetAll();
    }
}
