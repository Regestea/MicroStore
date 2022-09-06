using Catalog.Application.Common.Interfaces;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Persistence.Repository
{
    public class ProductRepository : IProductRepository
    {
        ICatalogContext _catalogContext;

        public ProductRepository(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task<bool> IsProductExist(string productId)
        {
            return await _catalogContext.Products.Find(p => p.Id == productId).AnyAsync();
        }

        public async Task<bool> AddImageToProduct(string productId, string imagePath)
        {
            var product = await _catalogContext.Products.Find(x => x.Id == productId).SingleOrDefaultAsync();
            return true;
        }

        public Task<bool> RemoveImageFromProduct(string productId, string imagePath)
        {
            throw new NotImplementedException();
        }
    }
}
