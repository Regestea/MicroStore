namespace CatalogComment.API.Entities
{
    public class Comment : BaseEntity
    {
        public string UserId { get; set; }
        public string UserComment { get; set; }
        public string ProductId { get; set; }
    }
}
