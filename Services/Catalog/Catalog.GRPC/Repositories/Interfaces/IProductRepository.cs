namespace Catalog.GRPC.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> IsProductExist(string productId);
    }
}
