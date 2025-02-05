using Microsoft.AspNetCore.Mvc;
using ShopCartApp.Models;
using ShopCartApp.Services;
using System.Collections.Generic;

namespace ShopCartApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProducts(int offset = 0, int limit = 10)
        {
            return _productService.GetProducts(offset, limit);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpGet("search")]
        public ActionResult<List<Product>> SearchProducts(string searchTerm, string manufacturer, decimal? minPrice, decimal? maxPrice)
        {
            return _productService.SearchProducts(searchTerm, manufacturer, minPrice, maxPrice);
        }
    }
}