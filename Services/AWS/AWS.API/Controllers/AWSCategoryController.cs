using Amazon.S3;
using AWS.API.GrpcServices.CatalogCategory;
using AWS.Application.Common.Globals;
using AWS.Application.Common.Interfaces;
using AWS.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AWSCategoryController : ControllerBase
    {
        private IAWSFileRepository _fileRepository;
        private CatalogCategoryGrpcService _catalogCategoryGrpcService;

        public AWSCategoryController(IAWSFileRepository fileRepository, CatalogCategoryGrpcService catalogCategoryGrpcService)
        {
            _fileRepository = fileRepository;
            _catalogCategoryGrpcService = catalogCategoryGrpcService;
        }

        [HttpPost("{catalogCategoryId}")]
        public async Task<IActionResult> UploadCategoryImage([FromForm] FileUploadModel filesUploadModel, [FromRoute] string catalogCategoryId)
        {

            bool isObjectOwnerExist = await _catalogCategoryGrpcService.ExistCatalogCategoryAsync(catalogCategoryId);

            if (!isObjectOwnerExist)
            {
                return BadRequest("Owner doesn't exist ");
            }

            var filePath = await _fileRepository.UploadFile(Buckets.Names.microstorecategory, filesUploadModel.image, S3CannedACL.PublicRead);


            await _catalogCategoryGrpcService.AddImagePathToCatalogCategoryAsync(catalogCategoryId, filePath);

            return NoContent();
        }

    }
}
