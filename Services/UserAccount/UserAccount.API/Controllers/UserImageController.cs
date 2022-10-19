using Microsoft.AspNetCore.Mvc;
using UserAccount.API.GrpcServices.AWS;
using UserAccount.Application.Common.Interfaces;

namespace UserAccount.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserImageController : ControllerBase
    {
        private AwsGrpcService _awsGrpcService;
        private IUserRepository _userRepository;

        public UserImageController(AwsGrpcService awsGrpcService, IUserRepository userRepository)
        {
            _awsGrpcService = awsGrpcService;
            _userRepository = userRepository;
        }


        /// <summary>
        /// Remove category image
        /// </summary>
        /// <response code="200">Success </response>
        /// <response code="400">Error </response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{userId}")]
        public async Task<IActionResult> RemoveUserImage([FromRoute] string userId)
        {
            var removeResponse = await _userRepository.RemoveProfileImageAsync(userId);

            if (removeResponse.IsSuccess)
            {
                await _awsGrpcService.DeleteImage(removeResponse.OldImagePath);

                return NoContent();
            }

            return BadRequest("you can't delete this image");
        }
    }
}
