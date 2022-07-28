using DAL.Entites;
using DAL.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Invoicescontroller : ControllerBase
    {
        private readonly IInvoiceRepo _invoiceRepo;

        public Invoicescontroller(IInvoiceRepo invoiceRepo)
        {
            _invoiceRepo = invoiceRepo;
        }
        [HttpPost("New")]
        public async Task<IActionResult>New(Invoice invoice)
        {
            try
            {
                if (await _invoiceRepo.New(invoice))
                    return Ok("Saved");
                return BadRequest("Techical Error Please Contact Technical Support!!!");
            }
            catch (System.Exception)
            {

                throw;
            }                
        }
      
    }
}
