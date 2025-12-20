using Library.Models.Sales;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController(ISalesRepository salesRepository) : ControllerBase
    {

        [HttpGet]
        public IActionResult GetSales()
        {
            var sales = salesRepository.GetAllSales();
            return Ok(sales);
        }
    }

}