using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.Persistence.SeedDatas
{
    public class ProductSeed
    {
        public static List<Product> Get()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "62eff26faa2a7d20bc66fb8e",
                    CategoryName = "Laptop",
                    CreatedDate = DateTimeOffset.Now.AddYears(1),
                    Title ="gggd",
                    Price = 221,
                    TechnicalDetail = new List<ProductTechnicalDetail>(){new ProductTechnicalDetail()
                    {
                        Description = "dis good",
                        Title = "titledisgood"
                    }}
                },
                new Product()
                {
                    Id = "62eff28e6d75d45a6581e289",
                    CategoryName = "Laptop",
                    Title ="gggd2",
                    Price = 342,
                    TechnicalDetail = new List<ProductTechnicalDetail>(){new ProductTechnicalDetail()
                    {
                        Description = "dis good2",
                        Title = "titledisgood2"
                    }}
                }
            };
        }
    }
}
