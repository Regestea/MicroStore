namespace Catalog.Application.Common.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> IsProductExist(string productId);
        Task<bool> AddImageToProduct(string productId, string imagePath);
        Task<bool> RemoveImageFromProduct(string productId, string imagePath);
    }
}
