using Catalog.GRPC.Data.Interfaces;
using Catalog.GRPC.Repositories.Interfaces;
using MongoDB.Driver;

namespace Catalog.GRPC.Repositories
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
    }
}
