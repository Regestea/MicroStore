namespace CatalogCategory.Application.Common.Interfaces
{
    public interface ICatalogCategoryRepository
    {
        Task<bool> ExistCatalogCategory(string catalogCategoryId);

        Task<bool> ChangeCatalogCategoryImagePath(string catalogCategoryId, string imagePath);
    }
}
