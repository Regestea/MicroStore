using Catalog.API.GrpcServices.AWS;
using Catalog.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private IProductRepository _productRepository;
        private AwsGrpcService _awsGrpcService;

        public ProductImageController(IProductRepository productRepository, AwsGrpcService awsGrpcService)
        {
            _productRepository = productRepository;
            _awsGrpcService = awsGrpcService;
        }

        /// <summary>
        /// Remove product image with image index 
        /// </summary>
        /// <response code="200">Success </response>
        /// <response code="400">Error </response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{productId}/{imageIndex}")]
        public async Task<IActionResult> RemoveProductImage([FromRoute][Range(0, 10)] int imageIndex, string productId)
        {
            var removeResponse = await _productRepository.RemoveImageFromProduct(productId, imageIndex);

            if (removeResponse.IsSuccess && !string.IsNullOrEmpty(removeResponse.RemovedImagePath))
            {
                await _awsGrpcService.DeleteImage(removeResponse.RemovedImagePath);

                return NoContent();
            }

            return BadRequest("you cann't delete this image");
        }

        /// <summary>
        /// Increaseproduct image with image index 
        /// </summary>
        /// <response code="200">Success </response>
        /// <response code="400">Error </response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPatch("{productId}/{imageIndex}/Increase")]
        public async Task<IActionResult> IncreaseImageIndex([FromRoute][Range(0, 10)] int imageIndex, string productId)
        {
            var response = await _productRepository.IncreaseProductImageIndex(productId, imageIndex);

            if (response) return NoContent();

            return BadRequest("you cann't increase image index");
        }

        /// <summary>
        /// Decrease product image with image index 
        /// </summary>
        /// <response code="200">Success </response>
        /// <response code="400">Error </response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPatch("{productId}/{imageIndex}/Decrease")]
        public async Task<IActionResult> DecreaseImageIndex([FromRoute][Range(0, 10)] int imageIndex, string productId)
        {
            var response = await _productRepository.DecreaseProductImageIndex(productId, imageIndex);

            if (response) return NoContent();

            return BadRequest("you cann't decrease image index");
        }
    }
}
