using Amazon.S3;
using AWS.API.GrpcServices.UserAccount;
using AWS.Application.Common.Globals;
using AWS.Application.Common.Interfaces;
using AWS.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AWSProfileController : ControllerBase
    {
        private IAWSFileRepository _fileRepository;
        private UserAccountGrpcService _userAccountGrpcService;

        public AWSProfileController(IAWSFileRepository fileRepository, UserAccountGrpcService userAccountGrpcService)
        {
            _fileRepository = fileRepository;
            _userAccountGrpcService = userAccountGrpcService;
        }


        [HttpPost("{userId}")]
        public async Task<IActionResult> UploadProfileImage([FromForm] FileUploadModel filesUploadModel, [FromRoute] string userId)
        {
            bool isObjectOwnerExist = await _userAccountGrpcService.ExistUserAccountAsync(userId);

            if (!isObjectOwnerExist)
            {
                return BadRequest("Owner doesn't exist ");
            }

            var filePath = await _fileRepository.UploadFile(Buckets.Names.microstoreprofile, filesUploadModel.image, S3CannedACL.PublicRead);

            await _userAccountGrpcService.AddImageToUserAccountAsync(userId, filePath);

            return NoContent();
        }

    }
}
