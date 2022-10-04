using UserAccount.Application.Common.Models.User;
using UserAccount.Domain.Entities;

namespace UserAccount.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(Guid userId);

        Task<bool> IsEmailExistAsync(string email);

        Task<bool> ChangeProfileImageAsync(string userId, string imagePath);

        Task<bool> IsUserExistAsync(string userId);

        Task<Guid> CreateUserAsync(CreateUserModel userModel);

    }
}
