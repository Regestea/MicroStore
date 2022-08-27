using Microsoft.AspNetCore.Mvc;
using UserAccount.API.Models.User;
using UserAccount.API.Repositories.Interfaces;

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
            var userId = await _userRepository.CreateUserAsync(createUserModel);

            return Ok(userId);
        }
    }
}
