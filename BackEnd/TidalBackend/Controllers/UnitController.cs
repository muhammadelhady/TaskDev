using DAL.Entites;
using DAL.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitRepo _unitRepo;

        public UnitController(IUnitRepo unitRepo)
        {
            _unitRepo = unitRepo;
        }

        [HttpGet("All")]
        public async Task<List<Unit>> GetAll()
        {
            try
            {
                return await _unitRepo.GetAll();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost("New")]
        public async Task<IActionResult> New(Unit unit)
        {
            try
            {
                return Ok(await _unitRepo.New(unit));
            }
            catch (System.Exception)
            {

                throw;
            }
        }

    }
}
