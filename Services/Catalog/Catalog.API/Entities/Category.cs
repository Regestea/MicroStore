namespace Catalog.API.Entities
{
    public class Category : BaseEntity
    {
        [BsonRequired]
        public string CategoryName { get; set; }

    }
}
