using Catalog.API.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ICatalogContext _catalogContext;

        public ValuesController(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        [HttpGet]
        public async Task<IActionResult> h()
        {
            var ss = await _catalogContext.Products.FindAsync(p => true).Result.ToListAsync();
            return Ok(ss);
        }
    }
}
