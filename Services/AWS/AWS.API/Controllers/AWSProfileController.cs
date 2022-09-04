using Amazon.S3;
using AWS.API.Globals;
using AWS.API.Models;
using AWS.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AWS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AWSProfileController : ControllerBase
    {
        private IAWSFileRepository _fileRepository;

        public AWSProfileController(IAWSFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }


        [HttpPost("{profileId}")]
        public async Task<IActionResult> UploadProfileImage([FromForm] FileUploadRequest filesUploadRequest, [FromRoute] Guid profileId)
        {
            var response = await _fileRepository.UploadFile(Buckets.Names.profile, profileId, filesUploadRequest.image, S3CannedACL.PublicRead);

            //TODO:grpc request to catalog grpc service to add image files to Profile image  

            return NoContent();
        }


        [HttpDelete("{profileId}/{imageName}")]
        public async Task<IActionResult> DeleteProfileImage([FromRoute] Guid profileId, [FromRoute] Guid imageName)
        {
            var response = await _fileRepository.DeleteFile(Buckets.Names.profile, profileId, imageName);

            //TODO:grpc request to catalog grpc service to delete image files to Profile image  

            return NoContent();
        }
    }
}
