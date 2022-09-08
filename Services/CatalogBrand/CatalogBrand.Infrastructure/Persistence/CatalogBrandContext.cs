using CatalogBrand.Application.Common.Interfaces;
using CatalogBrand.Domain.Entities;
using CatalogBrand.Infrastructure.Persistence.SeedDatas;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CatalogBrand.Infrastructure.Persistence
{
    public class CatalogBrandContext : ICatalogBrandContext
    {
        public CatalogBrandContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetSection("DatabaseSettings:ConnectionString").Value);
            var database = client.GetDatabase(configuration.GetSection("DatabaseSettings:DatabaseName").Value);

            Brands = database.GetCollection<Brand>(configuration.GetSection("DatabaseSettings:CollectionName").Value);
            CatalogBrandContextSeed.SeedData(Brands, BrandSeed.Get());
        }
        public IMongoCollection<Brand> Brands { get; }
    }
}
