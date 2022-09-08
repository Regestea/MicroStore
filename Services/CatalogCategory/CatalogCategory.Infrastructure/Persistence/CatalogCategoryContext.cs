using CatalogCategory.Application.Common.Interfaces;
using CatalogCategory.Domain.Entities;
using CatalogCategory.Infrastructure.Persistence.SeedDatas;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CatalogCategory.Infrastructure.Persistence
{
    public class CatalogCategoryContext : ICatalogCategoryContext
    {
        public CatalogCategoryContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetSection("DatabaseSettings:ConnectionString").Value);
            var database = client.GetDatabase(configuration.GetSection("DatabaseSettings:DatabaseName").Value);

            Categories = database.GetCollection<Category>(configuration.GetSection("DatabaseSettings:CollectionName").Value);
            CatalogCategoryiContextSeed.SeedData(Categories, CategorySeed.Get());
        }

        public IMongoCollection<Category> Categories { get; }
    }
}