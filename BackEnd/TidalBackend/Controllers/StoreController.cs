using DAL.Entites;
using DAL.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepo _storeRepo;

        public StoreController(IStoreRepo storeRepo)
        {
            _storeRepo = storeRepo;
        }

        [HttpGet("All")]
        public async Task<List<Store>> GetAll()
        {
            try
            {
                return await _storeRepo.GetAll();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost("New")]
        public async Task<IActionResult> New(Store store)
        {
            try
            {
                return Ok(await _storeRepo.New(store));
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
