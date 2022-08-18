using Catalog.GRPC.Entities;

namespace Catalog.GRPC.Data.SeedDatas
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
                    CategoryName = "hello",
                    Title ="gggd",
                    TechnicalDetail = new List<TechnicalDetail>(){new TechnicalDetail()
                    {
                        Description = "dis good",
                        Title = "titledisgood"
                    }}
                },
                new Product()
                {
                    Id = "62eff28e6d75d45a6581e289",
                    CategoryName = "hello2",
                    Title ="gggd2",
                    TechnicalDetail = new List<TechnicalDetail>(){new TechnicalDetail()
                    {
                        Description = "dis good2",
                        Title = "titledisgood2"
                    }}
                }
            };
        }
    }
}
