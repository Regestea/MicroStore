using CatalogBrand.API.Entities;
using MongoDB.Driver;

namespace CatalogBrand.API.Data.Interfaces
{
    public interface ICatalogBrandContext
    {
        IMongoCollection<Brand> Brands { get; }
    }
}
