using CatalogCategory.Application.Common.Interfaces;
using CatalogCategory.Domain.Entities;
using MongoDB.Driver;

namespace CatalogCategory.Infrastructure.Persistence.Repositories
{
    public class CatalogCategoryRepository : ICatalogCategoryRepository
    {
        private ICatalogCategoryContext _catalogCategoryContext;

        public CatalogCategoryRepository(ICatalogCategoryContext catalogCategoryContext)
        {
            _catalogCategoryContext = catalogCategoryContext;
        }


        public async Task<bool> ExistCatalogCategory(string catalogCategoryId)
        {
            return await _catalogCategoryContext.Categories.Find(x => x.Id == catalogCategoryId).AnyAsync();
        }

        public async Task<bool> ChangeCatalogCategoryImagePath(string catalogCategoryId, string imagePath)
        {
            var filter = Builders<Category>.Filter.Eq(s => s.Id, catalogCategoryId);

            var update = Builders<Category>.Update.Set(s => s.Image, imagePath);

            var result = await _catalogCategoryContext.Categories.UpdateOneAsync(filter, update);

            return result.IsModifiedCountAvailable;
        }
    }
}
