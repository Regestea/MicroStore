using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Catalog.Application.Common.Interfaces;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ICatalogContext _catalogContext;

        public ProductController(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        [HttpGet]
        public async Task<IActionResult> Catalogs([FromQuery][Range(1, int.MaxValue)] int currentPage, [FromQuery] string stortBy, [FromQuery][Range(5, 30)] int itemInPage = 10)
        {


            return NotFound();
        }
    }
}
