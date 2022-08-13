using CatalogComment.API.Data.Interfaces;
using CatalogComment.API.Data.SeedDatas;
using CatalogComment.API.Entities;
using MongoDB.Driver;

namespace CatalogComment.API.Data
{
    public class CatalogCommentContext : ICatalogCommentContext
    {
        public CatalogCommentContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Comments = database.GetCollection<Comment>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogCommentContextSeed.SeedData(Comments, CommentSeed.Get());
        }
        public IMongoCollection<Comment> Comments { get; }
    }
}
