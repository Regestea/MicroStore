using Microsoft.AspNetCore.Mvc;
using UserAccount.API.Models.Address;
using UserAccount.API.Repositories.Interfaces;

namespace UserAccount.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAddress([FromRoute] Guid userId)
        {
            var address = await _addressRepository.GetUserAddressAsync(userId);

            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> CreateAddress(Guid userId, CreateAddressModel createAddressModel)
        {
            var result = await _addressRepository.AddAddressAsync(userId, createAddressModel);

            if (Guid.TryParse(result, out _))
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("{addressId}")]
        public async Task<IActionResult> EditAddress(Guid addressId, UpdateAddressModel updateAddressModel)
        {
            var result = await _addressRepository.UpdateAddressAsync(addressId, updateAddressModel);

            if (Guid.TryParse(result, out _))
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("{addressId}")]
        public async Task<IActionResult> DeleteAddress(Guid addressId)
        {
            await _addressRepository.DeleteAddressAsync(addressId);

            return NoContent();
        }
    }
}
