using UserAccount.Application.Common.Models.Address;
using UserAccount.Domain.Entities;

namespace UserAccount.Application.Common.Interfaces
{
    public interface IAddressRepository
    {
        Task<Address?> GetUserAddressAsync(Guid userId);

        Task<string> AddAddressAsync(Guid userId, CreateAddressModel addressModel);

        Task<string> UpdateAddressAsync(Guid addressId, UpdateAddressModel addressModel);

        Task DeleteAddressAsync(Guid addressId);
    }
}
