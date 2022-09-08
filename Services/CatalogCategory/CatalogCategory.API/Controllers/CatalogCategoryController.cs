using CatalogCategory.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace CatalogCategory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogCategoryController : ControllerBase
    {
        private ICatalogCategoryContext _catalogCategoryContext;

        public CatalogCategoryController(ICatalogCategoryContext catalogCategoryContext)
        {
            _catalogCategoryContext = catalogCategoryContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ss = await _catalogCategoryContext.Categories.Find(p => true).ToListAsync();
            return Ok(ss);
        }
    }
}
