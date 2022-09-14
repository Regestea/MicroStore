using Amazon.S3;
using AWS.Application.Common.Globals;
using AWS.Application.Common.Interfaces;
using AWS.Application.DTOs.Requests;
using AWS.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AWSProductController : ControllerBase
    {
        private IAWSFileRepository _fileRepository;

        public AWSProductController(IAWSFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }


        [HttpPost("{objectOwnerId}")]
        public async Task<IActionResult> UploadProductImage([FromForm] FileUploadModel filesUploadModel, [FromRoute] string objectOwnerId)
        {
            bool isObjectOwnerExist = true;//request to grpc service

            if (!isObjectOwnerExist)
            {
                return BadRequest("Owner doesn't exist ");
            }

            var filePath = await _fileRepository.UploadFile(Buckets.Names.product, filesUploadModel.image, S3CannedACL.PublicRead);

            var addFilePathRequest = new AddFilePathRequest()
            {
                FilePath = filePath,
                ObjectOwnerId = objectOwnerId
            };

            //TODO:grpc request to catalog grpc service to add image files to product image  

            return NoContent();
        }

    }
}
