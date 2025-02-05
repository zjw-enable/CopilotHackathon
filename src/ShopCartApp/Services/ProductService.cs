using ShopCartApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace ShopCartApp.Services
{
    public class ProductService
    {
        private readonly List<Product> _products;

        public ProductService()
        {
            // Load products from automobileParts.json
            _products = LoadProductsFromJson();
        }

        public List<Product> GetProducts(int offset, int limit)
        {
            return _products.Skip(offset).Take(limit).ToList();
        }

        public Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> SearchProducts(string searchTerm, string manufacturer, decimal? minPrice, decimal? maxPrice)
        {
            return _products.Where(p =>
                (string.IsNullOrEmpty(searchTerm) || p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm)) &&
                (string.IsNullOrEmpty(manufacturer) || p.Manufacturer == manufacturer) &&
                (!minPrice.HasValue || p.Price >= minPrice.Value) &&
                (!maxPrice.HasValue || p.Price <= maxPrice.Value)
            ).ToList();
        }

        private List<Product> LoadProductsFromJson()
        {
            var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "automobileParts.json");
            if (File.Exists(jsonFilePath))
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                return JsonConvert.DeserializeObject<List<Product>>(jsonData);
            }
            return new List<Product>();
        }
    }
}