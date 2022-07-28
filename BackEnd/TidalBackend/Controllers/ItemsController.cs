using DAL.Entites;
using DAL.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepo _itemRepo;

        public ItemsController(IItemRepo itemRepo)
        {
            _itemRepo = itemRepo;
        }
        [HttpGet("All")]
        public async Task<List<Item>> GetAll()
        {
            try
            {
                return await _itemRepo.GetAll();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpPost("GetByStore")]
        public async Task<List<Item>>GeyByStore([FromBody]int storeId)
        {
            try
            {
                return await _itemRepo.GetStoreItems(storeId);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost("New")]
        public async Task<IActionResult> New(Item item)
        {
            try
            {
                return Ok(await _itemRepo.New(item));
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
