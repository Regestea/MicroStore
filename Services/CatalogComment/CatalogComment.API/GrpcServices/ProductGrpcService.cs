using Catalog.GRPC.Protos;

namespace CatalogComment.API.GrpcServices
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
    }
}
