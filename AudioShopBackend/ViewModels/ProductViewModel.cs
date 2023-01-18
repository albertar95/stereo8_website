using AudioShopBackend.Models;

namespace AudioShopBackend.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; } = new Product()!;
        public IEnumerable<Category> Categories { get; set; } = new List<Category>()!;
        public IEnumerable<Product> Products { get; set; } = new List<Product>()!;
        public IEnumerable<Models.File> Files { get; set; } = new List<Models.File>()!;
    }
}
