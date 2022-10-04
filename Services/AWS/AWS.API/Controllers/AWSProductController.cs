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


        [HttpPatch("{productId}")]
        public async Task<IActionResult> EditProductImage([FromForm] FileUploadModel filesUploadModel, [FromQuery] string oldImagePath, [FromRoute] string productId)
        {

            Console.WriteLine(oldImagePath);
            bool isObjectOwnerExist = await _productGrpcService.ExistProductAsync(productId);

            if (!isObjectOwnerExist)
            {
                return BadRequest("Owner doesn't exist ");
            }

            //TODO: validate old image path with grpc

            var filePath = await _fileRepository.UploadFile(Buckets.Names.microstoreproduct, filesUploadModel.image, S3CannedACL.PublicRead);


            bool isAdded = await _productGrpcService.EditProductImageAsync(productId, oldImagePath, filePath);

            if (!isAdded)
            {
                return BadRequest("something wrong nothing changed");
            }

            return NoContent();
        }

    }
}
