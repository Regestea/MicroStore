using MongoDB.Driver;

namespace Catalog.API.Data;

public class CatalogContextSeed
{
    public static void SeedData<T>(IMongoCollection<T> productCollection, List<T> seedData) where T : class
    {
        bool existProduct = productCollection.Find(p => true).Any();
        if (!existProduct)
        {
            productCollection.InsertManyAsync(seedData);
        }
    }
}