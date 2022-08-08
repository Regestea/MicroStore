using Catalog.API.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

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
        public async Task<IActionResult> gg()
        {
            var ss = await _catalogContext.Products.Find(p => true).ToListAsync();
            return Ok(ss);
        }
    }
}
