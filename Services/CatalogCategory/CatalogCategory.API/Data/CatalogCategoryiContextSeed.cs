using MongoDB.Driver;

namespace CatalogCategory.API.Data;

public class CatalogCategoryiContextSeed
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