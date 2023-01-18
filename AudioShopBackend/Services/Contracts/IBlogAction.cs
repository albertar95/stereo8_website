using AudioShopBackend.Models;

namespace AudioShopBackend.Services.Contracts
{
    public interface IBlogAction : IGeneralAction
    {
        IEnumerable<BlogComment> GetBlogComments(int State = 0, int Pagesize = 100, int Skip = 0);
        IEnumerable<Blog> GetBlogs(bool IncludeAll = true, int State = 0, int Pagesize = 100, int Skip = 0);
        BlogComment GetBlogComment(Guid NidComment);
        Blog GetBlog(Guid NidBlog, bool IncludeAll = false);
        bool UpdateBlogComment(BlogComment item);
        bool UpdateBlog(Blog item);
        IEnumerable<BlogCategory> GetBlogCategories(bool IncludeBlogs = true, byte State = 0);
        IEnumerable<BlogCategory> GetAllBlogCategories(bool IncludeBlogs = true);
        BlogCategory GetBlogCategory(Guid NidCategory, bool IncludeBlogs = true);
        bool UpdateBlogCategory(BlogCategory item);
    }
}
