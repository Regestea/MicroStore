using UserAccount.Application.Common.Models.User;
using UserAccount.Domain.Entities;

namespace UserAccount.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(Guid userId);

        Task<bool> IsEmailExist(string email);

        Task<bool> AddUserImage(string userId, string imagePath);

        Task<bool> EditUserImage(string userId, string newImagePath);

        Task<bool> IsUserExist(string userId);

        Task<Guid> CreateUserAsync(CreateUserModel userModel);

    }
}
