using Amazon.S3;
using AWS.API.Globals;
using AWS.API.Models;
using AWS.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AWS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AWSCategoryController : ControllerBase
    {
        private IAWSFileRepository _fileRepository;

        public AWSCategoryController(IAWSFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        [HttpPost("{categoryId}")]
        public async Task<IActionResult> UploadCategoryImage([FromForm] FileUploadRequest filesUploadRequest, [FromRoute] Guid categoryId)
        {
            var response = await _fileRepository.UploadFile(Buckets.Names.category, categoryId, filesUploadRequest.image, S3CannedACL.PublicRead);

            //TODO:grpc request to catalog grpc service to add image files to Category image  

            return NoContent();
        }


        [HttpDelete("{categoryId}/{imageName}")]
        public async Task<IActionResult> DeleteCategoryImage([FromRoute] Guid categoryId, [FromRoute] Guid imageName)
        {
            var response = await _fileRepository.DeleteFile(Buckets.Names.category, categoryId, imageName);

            //TODO:grpc request to catalog grpc service to delete image files to Category image  

            return NoContent();
        }
    }
}
