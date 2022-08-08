using CatalogBrand.API.Data.Interfaces;
using CatalogBrand.API.Data.SeedDatas;
using CatalogBrand.API.Entities;
using MongoDB.Driver;

namespace CatalogBrand.API.Data
{
    public class CatalogBrandContext : ICatalogBrandContext
    {
        public CatalogBrandContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Brands = database.GetCollection<Brand>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogBrandContextSeed.SeedData(Brands, BrandSeed.Get());
        }
        public IMongoCollection<Brand> Brands { get; }
    }
}
