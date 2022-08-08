using CatalogCategory.API.Data.Interfaces;
using CatalogCategory.API.Data.SeedDatas;
using CatalogCategory.API.Entities;
using MongoDB.Driver;

namespace CatalogCategory.API.Data
{
    public class CatalogCategoryContext : ICatalogCategoryContext
    {
        public CatalogCategoryContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Categories = database.GetCollection<Category>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogCategoryiContextSeed.SeedData(Categories, CategorySeed.Get());
        }

        public IMongoCollection<Category> Categories { get; }
    }
}