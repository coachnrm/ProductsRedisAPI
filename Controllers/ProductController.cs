using Microsoft.AspNetCore.Mvc;
using ProductsRedisAPI.Data;
using ProductsRedisAPI.Models;

namespace ProductsRedisAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductsData _repo;
        public ProductController(IProductsData repo)
        {
            _repo = repo;
        }

        [HttpPost("create-product")]
        public IActionResult CreateProduct(Product product)
        {
            return Ok(_repo.CreateProduct(product));
        }

        [HttpGet("get-products")]
        public IActionResult GetAllProducts()
        {
            return Ok(_repo.GetAllProducts());
        }

        [HttpGet("get-product/{id}")]
        public IActionResult GetProductById(string id)
        {
            return Ok(_repo.GetProductById(id));
        }

        [HttpPut("update-product")]
        public IActionResult UpdateProduct(Product product)
        {
            return Ok(_repo.UpdateProduct(product));
        }

        [HttpDelete("delete-product")]
        public IActionResult DeleteProduct(string productId)
        {
            return Ok(_repo.DeleteProductById(productId));
        }
    }
}