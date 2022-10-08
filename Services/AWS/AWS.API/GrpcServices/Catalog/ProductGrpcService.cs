using Catalog.GRPC.Protos;

namespace AWS.API.GrpcServices.Catalog
{
    public class ProductGrpcService
    {
        private readonly ProductProtoService.ProductProtoServiceClient _productProtoService;

        public ProductGrpcService(ProductProtoService.ProductProtoServiceClient productProtoService)
        {
            _productProtoService = productProtoService;
        }

        public async Task<bool> ExistProductAsync(string productId)
        {
            var productRequest = new ExistProductRequest() { ProductId = productId };
            var productResponse = await _productProtoService.ExistProductAsync(productRequest);
            return productResponse.Exist;
        }

        public async Task<bool> AddProductImageAsync(string productId, string filePath)
        {
            var addImageRequest = new AddImageRequest() { ProductId = productId, FilePath = filePath };
            var addImageResponse = await _productProtoService.AddImageAsync(addImageRequest);

            return addImageResponse.IsSuccess;
        }

        public async Task<bool> EditProductImageAsync(string productId, string oldFilePath, string newFilePath)
        {
            var editImageRequest = new EditImageRequest() { ProductId = productId, OldFilePath = oldFilePath, NewFilePath = newFilePath };
            var editImageResponse = await _productProtoService.EditImageAsync(editImageRequest);

            return editImageResponse.IsSuccess;
        }
    }
}
