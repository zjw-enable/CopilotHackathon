namespace ShopCartApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }
        public string[] ModelCompatibility { get; set; }
        public string PartNumber { get; set; }
        public int Stock { get; set; }
        public Specifications Specifications { get; set; }
    }

    public class Specifications
    {
        public string Weight { get; set; }
        public string Dimensions { get; set; }
        public string Material { get; set; }
    }
}