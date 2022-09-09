using Microsoft.EntityFrameworkCore;
using UserAccount.Application.Common.Interfaces;
using UserAccount.Application.Common.Models.Address;
using UserAccount.Domain.Entities;
using UserAccount.Infrastructure.Persistence;

namespace UserAccount.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private UserAccountContext _context;

        public AddressRepository(UserAccountContext context)
        {
            _context = context;
        }


        public async Task<Address?> GetUserAddressAsync(Guid userId)
        {
            return await _context.Addresses.SingleOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<string> AddAddressAsync(Guid userId, CreateAddressModel addressModel)
        {
            var exist = await _context.Users.AnyAsync(x => x.Id == userId);
            if (!exist)
            {
                return new Exception("user doesn't found").ToString();
            }

            var address = new Address()
            {
                Country = addressModel.Country,
                LoctionAddress = addressModel.LoctionAddress,
                UserId = userId
            };

            await _context.AddAsync(address);

            await _context.SaveChangesAsync();

            return address.Id.ToString();
        }

        public async Task<string> UpdateAddressAsync(Guid addressId, UpdateAddressModel addressModel)
        {
            var address = await _context.Addresses.SingleOrDefaultAsync(x => x.Id == addressId);

            if (address == null)
            {
                return new Exception("address not found").ToString();
            }
            address.Country = addressModel.Country;
            address.LoctionAddress = addressModel.LoctionAddress;

            await _context.SaveChangesAsync();

            return address.Id.ToString();
        }

        public async Task DeleteAddressAsync(Guid addressId)
        {
            var address = await _context.Addresses.SingleOrDefaultAsync(x => x.Id == addressId);

            if (address != null)
            {
                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();
            }



        }
    }
}