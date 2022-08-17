using MongoDB.Bson.Serialization.Attributes;

namespace CatalogComment.API.Models
{
    public class UpdateCommentModel
    {
        [BsonRequired]
        public string UserComment { get; set; }
    }
}
