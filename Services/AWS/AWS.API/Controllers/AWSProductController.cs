using Amazon.S3;
using AWS.API.Globals;
using AWS.API.Models;
using AWS.API.Repositories.Interfaces;
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

        [HttpPost("{productId}/ImageList")]
        public async Task<IActionResult> UploadProductImages([FromForm] FilesUploadRequest filesUploadRequest, [FromRoute] Guid productId)
        {
            var response = await _fileRepository.UploadFiles(Buckets.Names.product, productId, filesUploadRequest.images, S3CannedACL.PublicRead);

            //TODO:grpc request to catalog grpc service to add image files to product image  

            return NoContent();
        }

        [HttpPost("{productId}/Image")]
        public async Task<IActionResult> UploadProductImage([FromForm] FileUploadRequest filesUploadRequest, [FromRoute] Guid productId)
        {
            var response = await _fileRepository.UploadFile(Buckets.Names.product, productId, filesUploadRequest.image, S3CannedACL.PublicRead);

            //TODO:grpc request to catalog grpc service to add image files to product image  

            return NoContent();
        }


        [HttpDelete("{productId}/{imageName}")]
        public async Task<IActionResult> DeleteProductImage([FromRoute] Guid productId, [FromRoute] Guid imageName)
        {
            var response = await _fileRepository.DeleteFile(Buckets.Names.product, productId, imageName);

            //TODO:grpc request to catalog grpc service to delete image files to product image  

            return NoContent();
        }
    }
}
