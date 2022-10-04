using Microsoft.AspNetCore.Mvc;
using UserAccount.Application.Common.Interfaces;
using UserAccount.Application.Common.Models.User;

namespace UserAccount.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid userId)
        {
            var user = await _userRepository.GetUserAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserModel createUserModel)
        {
            var isEmailExist = await _userRepository.IsEmailExistAsync(createUserModel.Email);

            if (isEmailExist)
            {
                return BadRequest("this email already exist");
            }

            var userId = await _userRepository.CreateUserAsync(createUserModel);

            return Ok(userId);
        }
    }
}
