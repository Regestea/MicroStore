using Microsoft.EntityFrameworkCore;
using UserAccount.API.Data;
using UserAccount.API.Entities;
using UserAccount.API.Models.User;
using UserAccount.API.Repositories.Interfaces;

namespace UserAccount.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private UserAccountContext _context;

        public UserRepository(UserAccountContext context)
        {
            _context = context;
        }


        public async Task<User?> GetUserAsync(Guid userId)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<Guid> CreateUserAsync(CreateUserModel userModel)
        {
            var user = new User()
            {
                Name = userModel.Name,
                Email = userModel.Email
            };

            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            return user.Id;
        }
    }
}
