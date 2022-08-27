namespace UserAccount.GRPC.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> IsUserExist(string userId);
    }
}
