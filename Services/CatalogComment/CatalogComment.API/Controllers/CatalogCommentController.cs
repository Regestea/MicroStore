using CatalogComment.API.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace CatalogComment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogCommentController : ControllerBase
    {
        private ICatalogCommentContext _catalogCommentContext;

        public CatalogCommentController(ICatalogCommentContext catalogCommentContext)
        {
            _catalogCommentContext = catalogCommentContext;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ss = await _catalogCommentContext.Comments.Find(p => true).ToListAsync();
            return Ok(ss);
        }
    }
}
