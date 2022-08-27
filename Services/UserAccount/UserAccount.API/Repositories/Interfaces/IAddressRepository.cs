using UserAccount.API.Entities;
using UserAccount.API.Models.Address;

namespace UserAccount.API.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        Task<Address?> GetUserAddressAsync(Guid userId);

        Task<string> AddAddressAsync(Guid userId, CreateAddressModel addressModel);

        Task<string> UpdateAddressAsync(Guid addressId, UpdateAddressModel addressModel);

        Task DeleteAddressAsync(Guid addressId);
    }
}
