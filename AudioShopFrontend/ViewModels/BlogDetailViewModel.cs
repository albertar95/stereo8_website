using AudioShopFrontend.Models;
using Microsoft.CodeAnalysis.Options;

namespace AudioShopFrontend.ViewModels
{
    public class BlogDetailViewModel
    {
        public Blog Blog { get; set; } = new Blog()!;
        public IEnumerable<Models.File> Files { get; set; } = new List<Models.File>()!;
        public List<string> Keywords { get; set; } = new List<string>()!;
        public IEnumerable<Blog> LatestBlog { get; set; } = new List<Blog>()!;
        public IEnumerable<BlogCategory> BlogCategories { get; set; } = new List<BlogCategory>()!;
        public IEnumerable<Blog> RelatedBlogs { get; set; } = new List<Blog>()!;
    }
}
