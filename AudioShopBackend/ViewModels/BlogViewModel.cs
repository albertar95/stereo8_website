using AudioShopBackend.Models;

namespace AudioShopBackend.ViewModels
{
    public class BlogViewModel
    {
        public Blog Blog { get; set; } = new Blog()!;
        public IEnumerable<BlogCategory> BlogCategories { get; set; } = new List<BlogCategory>()!;
        public IEnumerable<Blog> Blogs { get; set; } = new List<Blog>()!;
        public IEnumerable<Models.File> Files { get; set; } = new List<Models.File>()!;
    }
}
