using Microsoft.EntityFrameworkCore;
using UserAccount.GRPC.Data;

namespace UserAccount.GRPC.Repositories.Interfaces
{
    public class UserRepository : IUserRepository
    {
        private UserAccountContext _context;

        public UserRepository(UserAccountContext context)
        {
            _context = context;
        }

        public async Task<bool> IsUserExist(string userId)
        {
            Guid userGuid = Guid.Parse(userId);
            return await _context.Users.AnyAsync(x => x.Id == userGuid);
        }
    }
}
