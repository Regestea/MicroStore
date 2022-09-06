using Catalog.Application.Common.Interfaces;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Persistence.SeedDatas;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Persistence
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetSection("DatabaseSettings:ConnectionString").Value);
            var database = client.GetDatabase(configuration.GetSection("DatabaseSettings:DatabaseName").Value);

            Products = database.GetCollection<Product>(configuration.GetSection("DatabaseSettings:CollectionName").Value);
            CatalogContextSeed.SeedData(Products, ProductSeed.Get());
        }
        public IMongoCollection<Product> Products { get; }
    }
}
