using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCartApp.Models;
using ShopCartApp.Services;

namespace ShopCartApp.Pages
{
    public class ProductDetailsModel : PageModel
    {
        private readonly ProductService _productService;

        public ProductDetailsModel(ProductService productService)
        {
            _productService = productService;
        }

        public Product Product { get; set; }

        public IActionResult OnGet(int id)
        {
            Product = _productService.GetProductById(id);
            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}