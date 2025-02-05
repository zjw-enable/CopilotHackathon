using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCartApp.Models;
using ShopCartApp.Services;
using System.Collections.Generic;

namespace ShopCartApp.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly ProductService _productService;

        public ProductsModel(ProductService productService)
        {
            _productService = productService;
        }

        public List<Product> Products { get; set; } = new List<Product>();

        public void OnGet(string searchTerm)
        {
            Products = _productService.SearchProducts(searchTerm, null, null, null);
        }

        public void OnPostAddToCart(int productId)
        {
            // Add product to cart logic
        }
    }
}