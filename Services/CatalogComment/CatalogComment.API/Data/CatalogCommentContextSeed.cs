using MongoDB.Driver;

namespace CatalogComment.API.Data;

public class CatalogCommentContextSeed
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