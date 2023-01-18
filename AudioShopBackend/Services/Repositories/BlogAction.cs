using AudioShopBackend.Models;
using AudioShopBackend.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace AudioShopBackend.Services.Repositories
{
    public class BlogAction : IBlogAction
    {
        private readonly AudioShopDbContext _context;
        public BlogAction(AudioShopDbContext context)
        {
            _context = context;
        }
        public bool Add<T>(T item)
        {
            try
            {
                _context.Add(item);
                if (_context.SaveChanges() >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update<T>(T item)
        {
            try
            {
                _context.Update(item);
                if (_context.SaveChanges() >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Remove<T>(T item)
        {
            try
            {
                _context.Remove(item);
                if (_context.SaveChanges() >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<BlogCategory> GetAllBlogCategories(bool IncludeBlogs = true)
        {
            if (IncludeBlogs)
                return _context.BlogCategories.Include(p => p.Blogs);
            else
                return _context.BlogCategories.ToList();
        }
        public IEnumerable<BlogCategory> GetBlogCategories(bool IncludeBlogs = true, byte State = 0)
        {
            if (IncludeBlogs)
                return _context.BlogCategories.Include(p => p.Blogs.Where(b => b.State == 0)).Where(t => t.State == State);
            else
                return _context.BlogCategories.Where(t => t.State == State);
        }
        public BlogCategory GetBlogCategory(Guid NidCategory, bool IncludeBlogs = true)
        {
            if (IncludeBlogs)
                return _context.BlogCategories.Include(p => p.Blogs.Where(b => b.State == 0)).FirstOrDefault(t => t.NidCategory == NidCategory) ?? new BlogCategory();
            else
                return _context.BlogCategories.FirstOrDefault(t => t.NidCategory == NidCategory) ?? new BlogCategory();
        }
        public Blog GetBlog(Guid NidBlog, bool IncludeAll = false)
        {
            try
            {
                if (!IncludeAll)
                    return _context.Blogs.FirstOrDefault(p => p.NidBlog == NidBlog) ?? new Blog();
                else
                    return _context.Blogs.Include(q => q.Category).Include(q => q.User).FirstOrDefault(p => p.NidBlog == NidBlog) ?? new Blog();
            }
            catch (Exception)
            {
                return new Blog();
            }
        }
        public BlogComment GetBlogComment(Guid NidComment)
        {
            try
            {
                return _context.BlogComments.FirstOrDefault(p => p.NidComment == NidComment) ?? new BlogComment();
            }
            catch (Exception)
            {
                return new BlogComment();
            }
        }
        public IEnumerable<BlogComment> GetBlogComments(int State = 0, int Pagesize = 100, int Skip = 0)
        {
            try
            {
                return _context.BlogComments.Include(q => q.User).Where(p => p.State == State).OrderByDescending(p => p.CreateDate).Skip(Skip).Take(Pagesize).ToList();
            }
            catch (Exception)
            {
                return new List<BlogComment>();
            }
        }
        public IEnumerable<Blog> GetBlogs(bool IncludeAll = true, int State = 0, int Pagesize = 100, int Skip = 0)
        {
            try
            {
                if (IncludeAll)
                    return _context.Blogs.Include(p => p.Category).Include(q => q.User).Where(p => p.State == State).OrderByDescending(q => q.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                else
                    return _context.Blogs.Where(p => p.State == State).OrderByDescending(q => q.CreateDate).Skip(Skip).Take(Pagesize).ToList();
            }
            catch (Exception)
            {
                return new List<Blog>();
            }
        }
        public bool UpdateBlog(Blog item)
        {
            try
            {
                _context.Entry(item).State = EntityState.Modified;
                _context.Entry(item).Property(p => p.PersianLastModified).IsModified = false;
                _context.Entry(item).Property(p => p.PersianCreateDate).IsModified = false;
                if (_context.SaveChanges() >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateBlogCategory(BlogCategory item)
        {
            try
            {
                _context.Entry(item).State = EntityState.Modified;
                _context.Entry(item).Property(p => p.PersianLastModified).IsModified = false;
                _context.Entry(item).Property(p => p.PersianCreateDate).IsModified = false;
                if (_context.SaveChanges() >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateBlogComment(BlogComment item)
        {
            try
            {
                _context.Entry(item).State = EntityState.Modified;
                _context.Entry(item).Property(p => p.PersianCreateDate).IsModified = false;
                if (_context.SaveChanges() >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
