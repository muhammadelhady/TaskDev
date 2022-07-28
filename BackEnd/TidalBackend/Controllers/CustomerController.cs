using DAL.Entites;
using DAL.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomerController(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }
        [HttpGet("All")]
        public async Task<List<Customer>> GetAll()
        {
            try
            {
                return await _customerRepo.GetAll();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpPost("New")]
        public async Task<IActionResult> New(Customer customer)
        {
            try
            {
                return Ok(await _customerRepo.New(customer));
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
