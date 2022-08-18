using Catalog.GRPC.Entities;
using MongoDB.Driver;

namespace Catalog.GRPC.Data.Interfaces
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
