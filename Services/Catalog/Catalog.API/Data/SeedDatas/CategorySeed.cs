using Catalog.API.Entities;

namespace Catalog.API.Data.SeedDatas
{
    public class CategorySeed
    {
        public static List<Category> Get()
        {
            return new List<Category>()
            {
                new Category()
                {
                    CategoryName ="he"
                }
            };
        }
    }
}
