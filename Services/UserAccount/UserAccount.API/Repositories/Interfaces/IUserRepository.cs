using UserAccount.API.Entities;
using UserAccount.API.Models.User;

namespace UserAccount.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(Guid userId);

        Task<Guid> CreateUserAsync(CreateUserModel userModel);

    }
}
