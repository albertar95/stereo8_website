using AudioShopFrontend.Models;

namespace AudioShopFrontend.ViewModels
{
    public class BlogViewModel
    {
        public List<string> Keywords { get; set; } = new List<string>()!;
        public IEnumerable<Blog> LatestBlog { get; set; } = new List<Blog>()!;
        public IEnumerable<BlogCategory> BlogCategories { get; set; } = new List<BlogCategory>()!;
        public IEnumerable<Blog> Posts { get; set; } = new List<Blog>()!;
        public IEnumerable<Models.File> Files { get; set; } = new List<Models.File>()!;
        public string FilterName { get; set; } = ""!;
        public string FilterTitle { get; set; } = ""!;
        public string PageUrl { get; set; } = ""!;
        public int FilterType { get; set; }
        public int PostCount { get; set; }
        public int PageNumber { get; set; }
    }
}
