using Catalog.Application.Common.DTOs;
using Catalog.Application.Common.DTOs.Responses;
using Catalog.Application.Common.Models;

namespace Catalog.Application.Common.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductDTO>> GetProductList(int currentPage, int itemInPage, string categoryName, ProductSortBy stortBy);
        Task<ProductDTO> GetProductById(string productId);
        Task<bool> IsProductExist(string productId);
        Task<bool> AddImageToProduct(string productId, string imagePath);
        Task<ChangeImagePathResponse> EditProductImage(string productId, int oldImageIndex, string imagePath);
        Task<RemoveImagePathResponse> RemoveImageFromProduct(string productId, int imageIndex);

        //move product image one step to end of list
        Task<bool> IncreaseProductImageIndex(string productId, int imageIndex);
        //move product image one step to first of list
        Task<bool> DecreaseProductImageIndex(string productId, int imageIndex);
    }
}
