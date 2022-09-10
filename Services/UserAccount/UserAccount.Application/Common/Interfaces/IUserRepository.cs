using UserAccount.Application.Common.Models.User;
using UserAccount.Domain.Entities;

namespace UserAccount.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(Guid userId);

        Task<bool> IsEmailExist(string email);

        Task<bool> IsUserExist(string userId);

        Task<Guid> CreateUserAsync(CreateUserModel userModel);

    }
}
