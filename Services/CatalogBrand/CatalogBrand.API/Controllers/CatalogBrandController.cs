using CatalogBrand.API.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace CatalogBrand.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogBrandController : ControllerBase
    {
        private ICatalogBrandContext _brandContext;

        public CatalogBrandController(ICatalogBrandContext brandContext)
        {
            _brandContext = brandContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ss = await _brandContext.Brands.Find(p => true).ToListAsync();
            return Ok(ss);
        }
    }
}
