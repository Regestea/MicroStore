using AutoMapper;
using Catalog.Application.Common.DTOs;
using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.Persistence.Maps
{
    internal class ProductMap : Profile
    {
        public ProductMap()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductPicture, ProductPictureDTO>();
            CreateMap<ProductTechnicalDetail, ProductTechnicalDetailDTO>();
        }
    }
}
