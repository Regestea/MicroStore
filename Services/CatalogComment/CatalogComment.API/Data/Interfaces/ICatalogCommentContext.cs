using CatalogComment.API.Entities;
using MongoDB.Driver;

namespace CatalogComment.API.Data.Interfaces
{
    public interface ICatalogCommentContext
    {
        IMongoCollection<Comment> Comments { get; }
    }
}
