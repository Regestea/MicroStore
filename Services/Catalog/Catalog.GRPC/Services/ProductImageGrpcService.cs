using Catalog.Application.Common.Interfaces;
using Catalog.GRPC.Protos;
using Grpc.Core;

namespace Catalog.GRPC.Services
{
    public class ProductImageGrpcService : ProductImageProtoService.ProductImageProtoServiceBase
    {
        private IProductRepository _productRepository;

        public ProductImageGrpcService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //public override Task<AddImageResponse> AddImage(AddImageRequest request, ServerCallContext context)
        //{
        //    _productRepository.
        //}

        public override Task<DeleteImageResponse> DeleteImage(DeleteImageRequest request, ServerCallContext context)
        {
            return base.DeleteImage(request, context);
        }
    }
}
