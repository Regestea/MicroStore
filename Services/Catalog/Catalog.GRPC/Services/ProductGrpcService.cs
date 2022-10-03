using Catalog.Application.Common.Interfaces;
using Catalog.GRPC.Protos;
using Grpc.Core;

namespace Catalog.GRPC.Services
{
    public class ProductGrpcService : ProductProtoService.ProductProtoServiceBase
    {
        private IProductRepository _productRepository;

        public ProductGrpcService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public override async Task<ExistProductResponse> ExistProduct(ExistProductRequest request, ServerCallContext context)
        {
            return new ExistProductResponse() { Exist = await _productRepository.IsProductExist(request.ProductId) };
        }

        public override async Task<AddImageResponse> AddImage(AddImageRequest request, ServerCallContext context)
        {
            var addImageResult = await _productRepository.AddImageToProduct(request.ProductId, request.FilePath);

            return new AddImageResponse() { IsAdded = addImageResult };
        }

        public override async Task<EditImageResponse> EditImage(EditImageRequest request, ServerCallContext context)
        {
            var editImageResult = await _productRepository.EditProductImage(request.ProductId, request.OldFilePath, request.NewFilePath);

            return new EditImageResponse() { IsEdited = editImageResult };
        }
    }
}
