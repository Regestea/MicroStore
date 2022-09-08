using CatalogBrand.Domain.Entities;
using MongoDB.Driver;

namespace CatalogBrand.Application.Common.Interfaces
{
    public interface ICatalogBrandContext
    {
        IMongoCollection<Brand> Brands { get; }
    }
}
