using AudioShopFrontend.Models;

namespace AudioShopFrontend.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Category> SidebarCategories { get; set; } = new List<Category>()!;
        public IEnumerable<Category> SpecialCategories { get; set; } = new List<Category>()!;
        public IEnumerable<Product> SpecialProducts { get; set; } = new List<Product>()!;
        public IEnumerable<Product> OffProducts { get; set; } = new List<Product>()!;
        public IEnumerable<Blog> LatestBlogs { get; set; } = new List<Blog>()!;
        public IEnumerable<Models.File> Files { get; set; } = new List<Models.File>()!;
    }
}
