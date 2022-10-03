using Catalog.Application.Common.DTOs;
using Catalog.Application.Common.Interfaces;
using Catalog.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        /// <summary>
        /// Returns withdrwas with specific status or all items
        /// </summary>
        /// <response code="200">Success : Returns withdrwas with specific status or all items</response>
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetListProduct([FromQuery][Range(1, int.MaxValue)] int currentPage, [FromQuery] string categoryName, [FromQuery][Range(5, 30)] int itemInPage = 10, [FromQuery] ProductSortBy stortBy = ProductSortBy.NewestToOldest)
        {
            var productList = await _productRepository.GetProductList(currentPage, itemInPage, categoryName, stortBy);


            return Ok(productList);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetSingleProduct([FromRoute] string productId)
        {
            var product = await _productRepository.GetProductById(productId);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }





        //[HttpGet]
        //public async Task<IActionResult> Catalogs([FromQuery][Range(1, int.MaxValue)] int currentPage, [FromQuery] string stortBy, [FromQuery][Range(5, 30)] int itemInPage = 10)
        //{


        //    return NotFound();
        //}
    }
}
