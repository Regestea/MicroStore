using CatalogCategory.API.GrpcServices.AWS;
using CatalogCategory.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogCategory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogCategoryImageController : ControllerBase
    {
        private ICatalogCategoryRepository _catalogCategoryRepository;
        private AwsGrpcService _awsGrpcService;

        public CatalogCategoryImageController(ICatalogCategoryRepository catalogCategoryRepository, AwsGrpcService awsGrpcService)
        {
            _catalogCategoryRepository = catalogCategoryRepository;
            _awsGrpcService = awsGrpcService;
        }

        /// <summary>
        /// Remove category image
        /// </summary>
        /// <response code="200">Success </response>
        /// <response code="400">Error </response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> RemoveCatalogCategoryImage([FromRoute] string categoryId)
        {
            var removeResponse = await _catalogCategoryRepository.RemoveCatalogCategoryImage(categoryId);

            if (removeResponse.IsSuccess)
            {
                await _awsGrpcService.DeleteImage(removeResponse.OldImagePath);

                return NoContent();
            }

            return BadRequest("you can't delete this image");
        }
    }
}
