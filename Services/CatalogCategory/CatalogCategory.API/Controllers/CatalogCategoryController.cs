using CatalogCategory.Application.Common.Interfaces;
using CatalogCategory.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogCategory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogCategoryController : ControllerBase
    {
        private ICatalogCategoryRepository _catalogCategoryRepository;

        public CatalogCategoryController(ICatalogCategoryRepository catalogCategoryRepository)
        {
            _catalogCategoryRepository = catalogCategoryRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CatalogCategoryModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCatalogCategory()
        {
            var catalogCategoryList = await _catalogCategoryRepository.GetCatalogCategoryList();
            return Ok(catalogCategoryList);
        }
    }
}
