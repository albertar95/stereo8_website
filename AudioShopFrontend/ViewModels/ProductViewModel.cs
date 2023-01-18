using AudioShopFrontend.Models;

namespace AudioShopFrontend.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; } = new Product();
        public IEnumerable<Models.File> Files { get; set; } = new List<Models.File>();
        public IEnumerable<Product> SimilarProducts { get; set; } = new List<Product>();

    }
}
