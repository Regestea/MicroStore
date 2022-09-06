using Catalog.Domain.Entities;
using MongoDB.Driver;

namespace Catalog.Application.Common.Interfaces
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
