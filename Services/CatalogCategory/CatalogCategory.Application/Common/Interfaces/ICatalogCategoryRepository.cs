using CatalogCategory.Application.Common.DTOs.Responses;

namespace CatalogCategory.Application.Common.Interfaces
{
    public interface ICatalogCategoryRepository
    {
        Task<bool> ExistCatalogCategory(string catalogCategoryId);

        Task<ChangeImagePathResponse> ChangeCatalogCategoryImagePath(string catalogCategoryId, string imagePath);
    }
}
