using CatalogCategory.Domain.Entities;

namespace CatalogCategory.Infrastructure.Persistence.SeedDatas
{
    public class CategorySeed
    {
        public static List<Category> Get()
        {
            return new List<Category>()
            {
                new Category()
                {
                    Id = "62eff9bf5e2384861aba7b06",
                    CategoryName = "laptop"
                },
                new Category()
                {
                    Id = "62eff9cab6d5f156482472d5",
                    CategoryName = "dresses"
                },
                new Category()
                {
                    Id = "62eff9d685a372bbc92253b2",
                    CategoryName = "phone"
                },
                new Category()
                {
                    Id = "62eff9e1b53914ea3cfd39d3",
                    CategoryName = "tv"
                },
                new Category()
                {
                    Id = "62eff9ee1c3a5e870a843ae5",
                    CategoryName = "headset"
                },
                new Category()
                {
                    Id = "62eff9fc958ac1316d9d73a5",
                    CategoryName = "monitor"
                }
            };
        }
    }
}