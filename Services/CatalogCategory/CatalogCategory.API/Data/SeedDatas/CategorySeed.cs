using CatalogCategory.API.Entities;

namespace CatalogCategory.API.Data.SeedDatas
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
                    CategoryName = "Laptop"
                },
                new Category()
                {
                    Id = "62eff9cab6d5f156482472d5",
                    CategoryName = "Dresses"
                },
                new Category()
                {
                    Id = "62eff9d685a372bbc92253b2",
                    CategoryName = "Phone"
                },
                new Category()
                {
                    Id = "62eff9e1b53914ea3cfd39d3",
                    CategoryName = "TV"
                },
                new Category()
                {
                    Id = "62eff9ee1c3a5e870a843ae5",
                    CategoryName = "Headset"
                },
                new Category()
                {
                    Id = "62eff9fc958ac1316d9d73a5",
                    CategoryName = "Monitor"
                }
            };
        }
    }
}