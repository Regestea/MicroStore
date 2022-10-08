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
        public async Task<IActionResult> ChangeCategoryImage([FromForm] FileUploadModel filesUploadModel, [FromRoute] string catalogCategoryId)
        {

            bool isObjectOwnerExist = await _catalogCategoryGrpcService.ExistCatalogCategoryAsync(catalogCategoryId);

            if (!isObjectOwnerExist)
            {
                return BadRequest("Owner doesn't exist ");
            }

            var filePath = await _fileRepository.UploadFile(Buckets.Names.microstorecategory, filesUploadModel.image, S3CannedACL.PublicRead);


            var response = await _catalogCategoryGrpcService.ChangeCatalogCategoryImagePathAsync(catalogCategoryId, filePath);

            if (response.IsSuccess)
            {
                if (!string.IsNullOrEmpty(response.OldImagePath))
                {
                    var oldFilePath = response.OldImagePath.Split("/");
                    await _fileRepository.DeleteFile(oldFilePath[1], oldFilePath[2]);
                }
                return NoContent();
            }

            //delete uploaded image
            var uploadedImageFilePath = filePath.Split("/");
            await _fileRepository.DeleteFile(uploadedImageFilePath[1], uploadedImageFilePath[2]);

            return BadRequest("Internal error please try again");
        }

    }
}
