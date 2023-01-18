using AudioShopFrontend.Models;

namespace AudioShopFrontend.ViewModels
{
    public class CategoryViewModel
    {
        public Models.Category Category { get; set; } = new Models.Category();
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public IEnumerable<Models.File> Files { get; set; } = new List<Models.File>();
        public int ProductCount { get; set; }
        public int PageNumber { get; set; }
        public int SortType { get; set; }
        public Guid BrandId { get; set; } = Guid.Empty!;
        public Guid TypeId { get; set; } = Guid.Empty!;
    }
}
