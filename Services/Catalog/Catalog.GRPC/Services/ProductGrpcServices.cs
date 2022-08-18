using Catalog.GRPC.Protos;
using Catalog.GRPC.Repositories.Interfaces;
using Grpc.Core;

namespace Catalog.GRPC.Services
{
    public class ProductGrpcServices : ProductProtoService.ProductProtoServiceBase
    {
        private IProductRepository _productRepository;

        public ProductGrpcServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public override async Task<ExistProductResponse> ExistProduct(ExistProductRequest request, ServerCallContext context)
        {
            return new ExistProductResponse() { Exist = await _productRepository.IsProductExist(request.ProductId) };
        }
    }
}
