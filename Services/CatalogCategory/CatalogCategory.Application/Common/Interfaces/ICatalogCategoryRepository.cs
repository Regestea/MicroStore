using CatalogCategory.Application.Common.DTOs.Responses;
using CatalogCategory.Application.Common.Models;

namespace CatalogCategory.Application.Common.Interfaces
{
    public interface ICatalogCategoryRepository
    {
        Task<bool> ExistCatalogCategory(string catalogCategoryId);

        Task<ImagePathResponse> ChangeCatalogCategoryImagePath(string catalogCategoryId, string imagePath);

        Task<List<CatalogCategoryModel>> GetCatalogCategoryList();


        //management
        //Task<bool> CreateCatalogCategory(AddCatalogCategoryModel addCatalogCategoryModel);
        //Task<bool> EditCatlogCategory(EditCatlogCategoryModel editCatlogCategoryModel);
        //Task<bool> DeleteCatalogCategory(string catalogCategoryId);
        Task<ImagePathResponse> RemoveCatalogCategoryImage(string catalogCategoryId);

    }
}
