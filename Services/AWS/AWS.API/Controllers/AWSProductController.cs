using Amazon.S3;
using AWS.API.GrpcServices.Catalog;
using AWS.Application.Common.Globals;
using AWS.Application.Common.Interfaces;
using AWS.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AWSProductController : ControllerBase
    {
        private IAWSFileRepository _fileRepository;
        private ProductGrpcService _productGrpcService;

        public AWSProductController(IAWSFileRepository fileRepository, ProductGrpcService productGrpcService)
        {
            _fileRepository = fileRepository;
            _productGrpcService = productGrpcService;
        }


        [HttpPost("{productId}")]
        public async Task<IActionResult> AddProductImage([FromForm] FileUploadModel filesUploadModel, [FromRoute] string productId)
        {

            bool isObjectOwnerExist = await _productGrpcService.ExistProductAsync(productId);

            if (!isObjectOwnerExist)
            {
                return BadRequest("Owner doesn't exist ");
            }

            var filePath = await _fileRepository.UploadFile(Buckets.Names.microstoreproduct, filesUploadModel.image, S3CannedACL.PublicRead);

            bool isAdded = await _productGrpcService.AddProductImageAsync(productId, filePath);

            if (!isAdded)
            {
                return BadRequest("something wrong image doesn't added");
            }

            return NoContent();
        }


        [HttpPatch("{productId}/{oldImageIndex}")]
        public async Task<IActionResult> EditProductImage([FromForm] FileUploadModel filesUploadModel, [FromRoute] int oldImageIndex, [FromRoute] string productId)
        {

            bool isObjectOwnerExist = await _productGrpcService.ExistProductAsync(productId);

            if (!isObjectOwnerExist)
            {
                return BadRequest("Owner doesn't exist ");
            }

            var filePath = await _fileRepository.UploadFile(Buckets.Names.microstoreproduct, filesUploadModel.image, S3CannedACL.PublicRead);

            var response = await _productGrpcService.EditProductImageAsync(productId, oldImageIndex, filePath);

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
