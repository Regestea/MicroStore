using CatalogComment.API.Entities;

namespace CatalogComment.API.Data.SeedDatas
{
    public class CommentSeed
    {
        public static List<Comment> Get()
        {
            return new List<Comment>()
            {
                new Comment()
                {
                    Id = "62eff26faa2a7d20bc66fb8e",
                    ProductId = "62f0db13219f840d45f75dbd",
                    UserComment = "Verygood",
                    UserId = "62f0db380d5dcfc5563287b9"
                }
            };
        }
    }
}