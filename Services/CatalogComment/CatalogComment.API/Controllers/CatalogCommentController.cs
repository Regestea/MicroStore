using CatalogComment.API.Models;
using CatalogComment.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace CatalogComment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogCommentController : ControllerBase
    {
        private ICommentRepository _commentRepository;

        public CatalogCommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet("ProductComments/{productId}")]
        public async Task<IActionResult> ProductComments([FromRoute] string productId, [FromQuery][Range(1, int.MaxValue)] int currentPage, [FromQuery][Range(1, 30)] int itemInPage)
        {
            var productComments = await _commentRepository.GetProductCommentsAsync(productId, currentPage, itemInPage);
            if (productComments == null)
            {
                return NotFound();
            }

            return Ok(productComments);
        }

        [HttpGet("{commentId}")]
        public async Task<IActionResult> CatalogComment([FromRoute] string commentId)
        {
            var comment = await _commentRepository.GetCommentAsync(commentId);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCatalogComment([FromBody] CreateCommentModel createCommentModel)
        {
            var comment = await _commentRepository.CreateCommentAsync(createCommentModel);

            if (ObjectId.TryParse(comment, out _))
            {
                return Ok(comment);
            }

            return BadRequest(comment);
        }

        [HttpPut("{commentId}")]
        public async Task<IActionResult> UpdateCatalogComment([FromRoute] string commentId, [FromBody] UpdateCommentModel updateCommentModel)
        {
            var comment = await _commentRepository.UpdateCommentAsync(commentId, updateCommentModel);

            if (ObjectId.TryParse(comment, out _))
            {
                return Ok(comment);
            }

            return BadRequest(comment);
        }

        [HttpDelete("{commentId}")]
        public async Task<IActionResult> DeleteCatalogComment([FromRoute] string commentId)
        {
            await _commentRepository.DeleteCommentAsync(commentId);

            return NoContent();
        }
    }
}
