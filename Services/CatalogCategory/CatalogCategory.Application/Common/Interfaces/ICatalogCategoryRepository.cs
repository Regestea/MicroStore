namespace CatalogCategory.Application.Common.Interfaces
{
    public interface ICatalogCategoryRepository
    {
        Task<bool> ExistCatalogCategory(string catalogCategoryId);

        Task<bool> AddImagePath(string catalogCategoryId, string imagePath);
    }
}
