using CatalogCategory.Application.Common.DTOs.Responses;
using CatalogCategory.Application.Common.Interfaces;
using CatalogCategory.Application.Common.Models;
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

        public async Task<ImagePathResponse> ChangeCatalogCategoryImagePath(string catalogCategoryId, string imagePath)
        {
            var oldImagePath = await _catalogCategoryContext.Categories
                .Find(x => x.Id == catalogCategoryId)
                .Project(x => x.Image)
                .SingleOrDefaultAsync();

            var filter = Builders<Category>.Filter.Eq(s => s.Id, catalogCategoryId);

            var update = Builders<Category>.Update.Set(s => s.Image, imagePath);

            var result = await _catalogCategoryContext.Categories.UpdateOneAsync(filter, update);

            return new ImagePathResponse() { IsSuccess = result.IsModifiedCountAvailable, OldImagePath = oldImagePath };
        }

        public async Task<List<CatalogCategoryModel>> GetCatalogCategoryList()
        {
            return await _catalogCategoryContext.Categories
                .Find(x => true)
                .Project(x => new CatalogCategoryModel() { Id = x.Id, CategoryName = x.CategoryName, Image = x.Image })
                .ToListAsync();
        }

        public async Task<ImagePathResponse> RemoveCatalogCategoryImage(string catalogCategoryId)
        {
            var oldImagePath = await _catalogCategoryContext.Categories.Find(x => x.Id == catalogCategoryId).Project(x => x.Image).FirstOrDefaultAsync();

            if (oldImagePath == null) return new ImagePathResponse() { IsSuccess = false };

            var update = Builders<Category>.Update.Set(x => x.Image, null);
            var updateResult = await _catalogCategoryContext.Categories.UpdateOneAsync(x => x.Id == catalogCategoryId, update);

            return new ImagePathResponse() { IsSuccess = updateResult.IsModifiedCountAvailable, OldImagePath = oldImagePath };
        }
    }
}
