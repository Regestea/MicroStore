using AutoMapper;
using Catalog.Application.Common.DTOs;
using Catalog.Application.Common.DTOs.Responses;
using Catalog.Application.Common.Interfaces;
using Catalog.Application.Common.Models;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Common.Extensions;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Persistence.Repository
{
    public class ProductRepository : IProductRepository
    {
        private ICatalogContext _catalogContext;
        private IMapper _mapper;

        public ProductRepository(ICatalogContext catalogContext, IMapper mapper)
        {
            _catalogContext = catalogContext;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> GetProductList(int currentPage, int itemInPage, string categoryName, ProductSortBy stortBy)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.CategoryName, categoryName);
            var sort = Builders<Product>.Sort.Combine();

            switch (stortBy)
            {
                case ProductSortBy.CheapestToMostExpensive:
                    sort = sort.Ascending(x => x.Price);
                    break;
                case ProductSortBy.MostExpensiveToCheapest:
                    sort = sort.Descending(x => x.Price);
                    break;
                case ProductSortBy.NewestToOldest:
                    sort = sort.Descending(x => x.CreatedDate);
                    break;
                case ProductSortBy.OldestToNewest:
                    sort = sort.Ascending(x => x.CreatedDate);
                    break;
            }

            var productList = await _catalogContext.Products.Find(filter).Sort(sort).Paginate(currentPage, itemInPage).Project(x => new ProductDTO
            {
                Id = x.Id,
                Title = x.Title,
                Price = x.Price,
                Pictures = new List<ProductPictureDTO>()
                    { new ProductPictureDTO() { ImagePath = x.Pictures[0].ImagePath } }
            }).ToListAsync();

            return productList;
        }

        public async Task<ProductDTO> GetProductById(string productId)
        {
            var product = await _catalogContext.Products.Find(p => p.Id == productId).SingleOrDefaultAsync();
            var productDTO = _mapper.Map<ProductDTO>(product);

            return productDTO;
        }

        public async Task<bool> IsProductExist(string productId)
        {
            return await _catalogContext.Products.Find(p => p.Id == productId).AnyAsync();
        }

        public async Task<bool> AddImageToProduct(string productId, string imagePath)
        {

            var product = await _catalogContext.Products.Find(x => x.Id == productId).SingleOrDefaultAsync();

            if (product == null) return false;
            var filter = Builders<Product>.Filter.Eq(s => s.Id, productId);
            UpdateDefinition<Product> update = null;

            if (product.Pictures == null)
            {
                update = Builders<Product>.Update.Set(s => s.Pictures, new List<ProductPicture>() { new ProductPicture() { ImagePath = imagePath } });
            }
            else
            {
                product.Pictures.Add(new ProductPicture() { ImagePath = imagePath });
                update = Builders<Product>.Update.Set(s => s.Pictures, product.Pictures);
            }

            await _catalogContext.Products.UpdateOneAsync(filter, update);

            return true;
        }

        public async Task<ChangeImagePathResponse> EditProductImage(string productId, int oldImageIndex, string imagePath)
        {

            var pictures = await _catalogContext.Products.Find(x => x.Id == productId).Project(p => p.Pictures).SingleOrDefaultAsync();

            if (pictures == null) return new ChangeImagePathResponse() { IsSuccess = false };

            var maxImageIndex = pictures.Count - 1;

            if ((oldImageIndex > maxImageIndex) || (oldImageIndex < 0))
            {
                return new ChangeImagePathResponse() { IsSuccess = false };
            }

            string oldImagePath = pictures[oldImageIndex].ImagePath;

            pictures.RemoveAt(oldImageIndex);

            pictures.Insert(oldImageIndex, new ProductPicture() { ImagePath = imagePath });

            var update = Builders<Product>.Update.Set(x => x.Pictures, pictures);

            var updateResult = await _catalogContext.Products.UpdateOneAsync(x => x.Id == productId, update);

            return new ChangeImagePathResponse() { IsSuccess = updateResult.IsModifiedCountAvailable, OldImagePath = oldImagePath };
        }



        public async Task<RemoveImagePathResponse> RemoveImageFromProduct(string productId, int imageIndex)
        {
            var pictures = await _catalogContext.Products.Find(x => x.Id == productId).Project(p => p.Pictures).SingleOrDefaultAsync();

            if (pictures == null) return new RemoveImagePathResponse() { IsSuccess = false };

            var maxImageIndex = pictures.Count - 1;

            if ((imageIndex > maxImageIndex) || (imageIndex < 0))
            {
                return new RemoveImagePathResponse() { IsSuccess = false };
            }

            var removeImagePath = pictures[imageIndex].ImagePath;

            pictures.RemoveAt(imageIndex);

            var update = Builders<Product>.Update.Set(x => x.Pictures, pictures);

            var updateResult = await _catalogContext.Products.UpdateOneAsync(x => x.Id == productId, update);

            return new RemoveImagePathResponse() { IsSuccess = updateResult.IsModifiedCountAvailable, RemovedImagePath = removeImagePath };
        }

        public async Task<bool> IncreaseProductImageIndex(string productId, int imageIndex)
        {
            var pictures = await _catalogContext.Products.Find(x => x.Id == productId).Project(p => p.Pictures).SingleOrDefaultAsync();

            if (pictures == null) return false;

            var maxImageIndex = pictures.Count - 1;

            if ((imageIndex >= maxImageIndex) || (imageIndex < 0))
            {
                return false;
            }

            var imagePath = pictures[imageIndex].ImagePath;

            pictures.RemoveAt(imageIndex);

            pictures.Insert(imageIndex + 1, new ProductPicture() { ImagePath = imagePath });

            var update = Builders<Product>.Update.Set(x => x.Pictures, pictures);

            var updateResult = await _catalogContext.Products.UpdateOneAsync(x => x.Id == productId, update);

            return updateResult.IsModifiedCountAvailable;
        }

        public async Task<bool> DecreaseProductImageIndex(string productId, int imageIndex)
        {
            var pictures = await _catalogContext.Products.Find(x => x.Id == productId).Project(p => p.Pictures).SingleOrDefaultAsync();

            if (pictures == null) return false;

            var maxImageIndex = pictures.Count - 1;

            if ((imageIndex > maxImageIndex) || (imageIndex <= 0))
            {
                return false;
            }

            var imagePath = pictures[imageIndex].ImagePath;

            pictures.RemoveAt(imageIndex);
            pictures.Insert(imageIndex - 1, new ProductPicture() { ImagePath = imagePath });

            var update = Builders<Product>.Update.Set(x => x.Pictures, pictures);

            var updateResult = await _catalogContext.Products.UpdateOneAsync(x => x.Id == productId, update);

            return updateResult.IsModifiedCountAvailable;

        }
    }
}
