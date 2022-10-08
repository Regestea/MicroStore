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
        public async Task<IActionResult> ChangeProfileImage([FromForm] FileUploadModel filesUploadModel, [FromRoute] string userId)
        {
            bool isObjectOwnerExist = await _userAccountGrpcService.ExistUserAccountAsync(userId);

            if (!isObjectOwnerExist)
            {
                return BadRequest("Owner doesn't exist ");
            }

            var filePath = await _fileRepository.UploadFile(Buckets.Names.microstoreprofile, filesUploadModel.image, S3CannedACL.PublicRead);

            var response = await _userAccountGrpcService.ChangeProfileImageAsync(userId, filePath);

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
