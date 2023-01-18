using AudioShopFrontend.Models;
using AudioShopFrontend.Services.Contracts;
using AudioShopFrontend.ViewModels;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Drawing.Printing;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace AudioShopFrontend.Services.Repositories
{
    public class DatabaseAction : IDatabaseAction
    {
        private readonly MailSettings _mailSettings;
        private readonly AudioShopDbContext _context;
        public DatabaseAction(AudioShopDbContext context, IOptions<MailSettings> mailSettings)
        {
            _context = context;
            _mailSettings = mailSettings.Value;
        }
        //general
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
        public IEnumerable<Models.File> GetFiles(Guid NidRelate)
        {
            try
            {
                return _context.Files.Where(p => p.RelateId == NidRelate).ToList() ?? new List<Models.File>();
            }
            catch (Exception)
            {
                return new List<Models.File>();
            }
        }
        public bool SendEmail(MailRequest mailRequest)
        {
            var email2 = new MailMessage(_mailSettings.Mail,mailRequest.ToEmail);
            email2.Subject = mailRequest.Subject;
            email2.IsBodyHtml = true;
            email2.BodyEncoding = Encoding.UTF8;
            email2.Body = mailRequest.Body;
            using var smtp = new System.Net.Mail.SmtpClient();
            smtp.Port = _mailSettings.Port;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
            smtp.Host = _mailSettings.Host;
            smtp.Send(email2);
            return true;
        }
        //index page
        public IEnumerable<Category> GetCategories(bool IncludeTypes = true, bool IncludeBrands = true, bool IncludeProducts = true, byte State = 0)
        {
            if (IncludeTypes && IncludeBrands && IncludeProducts)
                return _context.Categories.Include(p => p.Types.Where(b => b.State == 0)).Include(q => q.Brands.Where(b => b.State == 0)).Include(x => x.Products.Where(b => b.State == 0)).Where(t => t.State == State).ToList();
            else if (IncludeTypes && IncludeBrands && !IncludeProducts)
                return _context.Categories.Include(p => p.Types.Where(b => b.State == 0)).Include(q => q.Brands.Where(b => b.State == 0)).Where(t => t.State == State).ToList();
            else if (IncludeTypes && !IncludeBrands && IncludeProducts)
                return _context.Categories.Include(p => p.Types.Where(b => b.State == 0)).Include(x => x.Products.Where(b => b.State == 0)).Where(t => t.State == State).ToList();
            else if (!IncludeTypes && IncludeBrands && IncludeProducts)
                return _context.Categories.Include(q => q.Brands.Where(b => b.State == 0)).Include(x => x.Products.Where(b => b.State == 0)).Where(t => t.State == State).ToList();
            else if (IncludeTypes && !IncludeBrands && !IncludeProducts)
                return _context.Categories.Include(p => p.Types.Where(b => b.State == 0)).Where(t => t.State == State).ToList();
            else if (!IncludeTypes && IncludeBrands && !IncludeProducts)
                return _context.Categories.Include(q => q.Brands.Where(b => b.State == 0)).Where(t => t.State == State).ToList();
            else if (!IncludeTypes && !IncludeBrands && IncludeProducts)
                return _context.Categories.Include(x => x.Products.Where(b => b.State == 0)).Where(t => t.State == State).ToList();
            else if (!IncludeTypes && !IncludeBrands && !IncludeProducts)
                return _context.Categories.Where(t => t.State == State);
            else
                return new List<Category>();
        }
        public IEnumerable<Product> GetProducts(bool IncludeAll = true, int State = 0, int Pagesize = 10, int Skip = 0)
        {
            try
            {
                if (IncludeAll)
                    return _context.Products.Include(p => p.Category).Include(q => q.Type).Include(x => x.Brand).Where(p => p.State == State).OrderByDescending(q => q.CreateDate).Skip(Skip*Pagesize).Take(Pagesize).ToList();
                else
                    return _context.Products.Where(p => p.State == State).OrderByDescending(q => q.CreateDate).Skip(Skip * Pagesize).Take(Pagesize).ToList();
            }
            catch (Exception)
            {
                return new List<Product>();
            }
        }
        public Category GetCategory(Guid NidCategory, bool IncludeTypes = true, bool IncludeBrands = true, bool IncludeProducts = true)
        {
            if (IncludeTypes && IncludeBrands && IncludeProducts)
                return _context.Categories.Include(p => p.Types.Where(b => b.State == 0)).Include(q => q.Brands.Where(b => b.State == 0)).Include(x => x.Products.Where(b => b.State == 0)).FirstOrDefault(t => t.NidCategory == NidCategory && t.State == 0) ?? new Category();
            else if (IncludeTypes && IncludeBrands && !IncludeProducts)
                return _context.Categories.Include(p => p.Types.Where(b => b.State == 0)).Include(q => q.Brands.Where(b => b.State == 0)).FirstOrDefault(t => t.NidCategory == NidCategory && t.State == 0) ?? new Category();
            else if (IncludeTypes && !IncludeBrands && IncludeProducts)
                return _context.Categories.Include(p => p.Types.Where(b => b.State == 0)).Include(x => x.Products.Where(b => b.State == 0)).FirstOrDefault(t => t.NidCategory == NidCategory && t.State == 0) ?? new Category();
            else if (!IncludeTypes && IncludeBrands && IncludeProducts)
                return _context.Categories.Include(q => q.Brands.Where(b => b.State == 0)).Include(x => x.Products.Where(b => b.State == 0)).FirstOrDefault(t => t.NidCategory == NidCategory && t.State == 0) ?? new Category();
            else if (IncludeTypes && !IncludeBrands && !IncludeProducts)
                return _context.Categories.Include(p => p.Types.Where(b => b.State == 0)).FirstOrDefault(t => t.NidCategory == NidCategory && t.State == 0) ?? new Category();
            else if (!IncludeTypes && IncludeBrands && !IncludeProducts)
                return _context.Categories.Include(q => q.Brands.Where(b => b.State == 0)).FirstOrDefault(t => t.NidCategory == NidCategory && t.State == 0) ?? new Category();
            else if (!IncludeTypes && !IncludeBrands && IncludeProducts)
                return _context.Categories.Include(x => x.Products.Where(b => b.State == 0)).FirstOrDefault(t => t.NidCategory == NidCategory && t.State == 0) ?? new Category();
            else if (!IncludeTypes && !IncludeBrands && !IncludeProducts)
                return _context.Categories.FirstOrDefault(t => t.NidCategory == NidCategory && t.State == 0) ?? new Category();
            else
                return new Category();
        }
        public IEnumerable<Product> GetSpecialProducts(int Pagesize = 10, int Skip = 0)
        {
            try
            {
                var cats = _context.Products.Where(p => p.State == 0 && p.Priority >= 4).GroupBy(p => p.CategoryId).Select(p => new { catId = p.Key }).ToList();
                List<Product> result = new List<Product>();
                foreach (var c in cats) 
                {
                    foreach (var prd in _context.Products.Include(p => p.Category).Include(p => p.Brand).Where(p => p.State == 0 && p.Priority >= 4 && p.CategoryId == c.catId).OrderByDescending(q => q.CreateDate).Skip(Skip * Pagesize).Take(Pagesize).ToList())
                    {
                        result.Add(prd);
                    }
                }
                return result;
            }
            catch (Exception)
            {
                return new List<Product>();
            }
        }
        public IEnumerable<Category> GetSpecialCategories()
        {
            if(_context.Categories.Count(t => t.State == 0) >= 6)
                return _context.Categories.Include(p => p.Types.Where(b => b.State == 0)).Where(t => t.State == 0).OrderByDescending(q => q.Products.Count).Take(6).ToList();
            else
            {
                if(_context.Categories.Count(t => t.State == 0) % 2 == 0)
                    return _context.Categories.Include(p => p.Types.Where(b => b.State == 0)).Where(t => t.State == 0).OrderByDescending(q => q.Products.Count).ToList();
                else
                    return _context.Categories.Include(p => p.Types.Where(b => b.State == 0)).Where(t => t.State == 0).OrderByDescending(q => q.Products.Count).Take(_context.Categories.Count(t => t.State == 0) - 1).ToList();

            }

        }
        public IEnumerable<Product> GetOffProducts(int Pagesize = 10, int Skip = 0)
        {
            try
            {
                return _context.Products.Include(p => p.Brand).Where(p => p.State == 0).OrderByDescending(q => q.OffPercentage).Skip(Skip * Pagesize).Take(Pagesize).ToList();
            }
            catch (Exception)
            {
                return new List<Product>();
            }
        }
        public IEnumerable<Blog> GetLatestBlogs(bool IncludeAll = true, int Pagesize = 10, int Skip = 0) 
        {
            try
            {
                if(IncludeAll)
                    return _context.Blogs.Include(p => p.Category).Include(p => p.User).OrderByDescending(p => p.CreateDate).Skip(Skip * Pagesize).Take(Pagesize).ToList();
                else
                    return _context.Blogs.OrderByDescending(p => p.CreateDate).Skip(Skip * Pagesize).Take(Pagesize).ToList();
            }
            catch (Exception)
            {
                return new List<Blog>();
            }
        }
        //category page
        public Category GetCategoryByTitle(string Title, bool IncludeTypes = true, bool IncludeBrands = true, bool IncludeProducts = true)
        {
            if (IncludeTypes && IncludeBrands && IncludeProducts)
                return _context.Categories.Include(p => p.Types.Where(b => b.State == 0)).Include(q => q.Brands.Where(b => b.State == 0)).Include(x => x.Products.Where(b => b.State == 0)).FirstOrDefault(t => t.CategoryName == Title && t.State == 0) ?? new Category();
            else if (IncludeTypes && IncludeBrands && !IncludeProducts)
                return _context.Categories.Include(p => p.Types.Where(b => b.State == 0)).Include(q => q.Brands.Where(b => b.State == 0)).FirstOrDefault(t => t.CategoryName == Title && t.State == 0) ?? new Category();
            else if (IncludeTypes && !IncludeBrands && IncludeProducts)
                return _context.Categories.Include(p => p.Types.Where(b => b.State == 0)).Include(x => x.Products.Where(b => b.State == 0)).FirstOrDefault(t => t.CategoryName == Title && t.State == 0) ?? new Category();
            else if (!IncludeTypes && IncludeBrands && IncludeProducts)
                return _context.Categories.Include(q => q.Brands.Where(b => b.State == 0)).Include(x => x.Products.Where(b => b.State == 0)).FirstOrDefault(t => t.CategoryName == Title && t.State == 0) ?? new Category();
            else if (IncludeTypes && !IncludeBrands && !IncludeProducts)
                return _context.Categories.Include(p => p.Types.Where(b => b.State == 0)).FirstOrDefault(t => t.CategoryName == Title && t.State == 0) ?? new Category();
            else if (!IncludeTypes && IncludeBrands && !IncludeProducts)
                return _context.Categories.Include(q => q.Brands.Where(b => b.State == 0)).FirstOrDefault(t => t.CategoryName == Title && t.State == 0) ?? new Category();
            else if (!IncludeTypes && !IncludeBrands && IncludeProducts)
                return _context.Categories.Include(x => x.Products.Where(b => b.State == 0)).FirstOrDefault(t => t.CategoryName == Title && t.State == 0) ?? new Category();
            else if (!IncludeTypes && !IncludeBrands && !IncludeProducts)
                return _context.Categories.FirstOrDefault(t => t.CategoryName == Title && t.State == 0) ?? new Category();
            else
                return new Category();
        }
        public Tuple<IEnumerable<Product>, int> GetProductsByCategoryId(Guid NidCategory, int Pagesize = 10, int Skip = 0)
        {
            try
            {
                return new Tuple<IEnumerable<Product>, int>(_context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory).OrderByDescending(q => q.CreateDate).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory).Count());
            }
            catch (Exception)
            {
                return new Tuple<IEnumerable<Product>, int>(new List<Product>(),0);
            }
        }
        public Tuple<IEnumerable<Product>, int> GetFilteredProducts(Guid NidCategory, List<Guid> TypeIds, List<Guid> BrandIds, int SortType, decimal MinPrice = 0, decimal MaxPrice = 10000000, int Pagesize = 10, int Skip = 0)
        {
            try
            {
                switch (SortType)
                {
                    case 1:
                        if (!TypeIds.Any() && !BrandIds.Any())
                            return new Tuple<IEnumerable<Product>, int>(_context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice).OrderByDescending(q => q.Rating).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice).Count());
                        else if (TypeIds.Any() && !BrandIds.Any())
                            return new Tuple<IEnumerable<Product>, int>(_context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && TypeIds.Contains(p.TypeId)).OrderByDescending(q => q.Rating).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && TypeIds.Contains(p.TypeId)).Count());
                        else if (!TypeIds.Any() && BrandIds.Any())
                            return new Tuple<IEnumerable<Product>, int>(_context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && BrandIds.Contains(p.BrandId)).OrderByDescending(q => q.Rating).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && BrandIds.Contains(p.BrandId)).Count());
                        else if (TypeIds.Any() && BrandIds.Any())
                            return new Tuple<IEnumerable<Product>, int>(_context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && TypeIds.Contains(p.TypeId) && BrandIds.Contains(p.BrandId)).OrderByDescending(q => q.Rating).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && TypeIds.Contains(p.TypeId) && BrandIds.Contains(p.BrandId)).Count());
                        else
                            return new Tuple<IEnumerable<Product>, int>(new List<Product>(), 0);
                    case 2:
                        if (!TypeIds.Any() && !BrandIds.Any())
                            return new Tuple<IEnumerable<Product>, int>(_context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice).OrderByDescending(q => q.CreateDate).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice).Count());
                        else if (TypeIds.Any() && !BrandIds.Any())
                            return new Tuple<IEnumerable<Product>, int>(_context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && TypeIds.Contains(p.TypeId)).OrderByDescending(q => q.CreateDate).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && TypeIds.Contains(p.TypeId)).Count());
                        else if (!TypeIds.Any() && BrandIds.Any())
                            return new Tuple<IEnumerable<Product>, int>(_context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && BrandIds.Contains(p.BrandId)).OrderByDescending(q => q.CreateDate).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && BrandIds.Contains(p.BrandId)).Count());
                        else if (TypeIds.Any() && BrandIds.Any())
                            return new Tuple<IEnumerable<Product>, int>(_context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && TypeIds.Contains(p.TypeId) && BrandIds.Contains(p.BrandId)).OrderByDescending(q => q.CreateDate).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && TypeIds.Contains(p.TypeId) && BrandIds.Contains(p.BrandId)).Count());
                        else
                            return new Tuple<IEnumerable<Product>, int>(new List<Product>(), 0);
                    case 3:
                        if (!TypeIds.Any() && !BrandIds.Any())
                            return new Tuple<IEnumerable<Product>, int>(_context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice).OrderBy(q => q.Price).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice).Count());
                        else if (TypeIds.Any() && !BrandIds.Any())
                            return new Tuple<IEnumerable<Product>, int>(_context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && TypeIds.Contains(p.TypeId)).OrderBy(q => q.Price).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && TypeIds.Contains(p.TypeId)).Count());
                        else if (!TypeIds.Any() && BrandIds.Any())
                            return new Tuple<IEnumerable<Product>, int>(_context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && BrandIds.Contains(p.BrandId)).OrderBy(q => q.Price).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && BrandIds.Contains(p.BrandId)).Count());
                        else if (TypeIds.Any() && BrandIds.Any())
                            return new Tuple<IEnumerable<Product>, int>(_context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && TypeIds.Contains(p.TypeId) && BrandIds.Contains(p.BrandId)).OrderBy(q => q.Price).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && TypeIds.Contains(p.TypeId) && BrandIds.Contains(p.BrandId)).Count());
                        else
                            return new Tuple<IEnumerable<Product>, int>(new List<Product>(), 0);
                    case 4:
                        if (!TypeIds.Any() && !BrandIds.Any())
                            return new Tuple<IEnumerable<Product>, int>(_context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice).OrderByDescending(q => q.Price).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice).Count());
                        else if (TypeIds.Any() && !BrandIds.Any())
                            return new Tuple<IEnumerable<Product>, int>(_context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && TypeIds.Contains(p.TypeId)).OrderByDescending(q => q.Price).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && TypeIds.Contains(p.TypeId)).Count());
                        else if (!TypeIds.Any() && BrandIds.Any())
                            return new Tuple<IEnumerable<Product>, int>(_context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && BrandIds.Contains(p.BrandId)).OrderByDescending(q => q.Price).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && BrandIds.Contains(p.BrandId)).Count());
                        else if (TypeIds.Any() && BrandIds.Any())
                            return new Tuple<IEnumerable<Product>, int>(_context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && TypeIds.Contains(p.TypeId) && BrandIds.Contains(p.BrandId)).OrderByDescending(q => q.Price).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && TypeIds.Contains(p.TypeId) && BrandIds.Contains(p.BrandId)).Count());
                        else
                            return new Tuple<IEnumerable<Product>, int>(new List<Product>(), 0);
                    case 5:
                        if (!TypeIds.Any() && !BrandIds.Any())
                            return new Tuple<IEnumerable<Product>, int>(_context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice).OrderBy(q => q.ProductName).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice).Count());
                        else if (TypeIds.Any() && !BrandIds.Any())
                            return new Tuple<IEnumerable<Product>, int>(_context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && TypeIds.Contains(p.TypeId)).OrderBy(q => q.ProductName).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && TypeIds.Contains(p.TypeId)).Count());
                        else if (!TypeIds.Any() && BrandIds.Any())
                            return new Tuple<IEnumerable<Product>, int>(_context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && BrandIds.Contains(p.BrandId)).OrderBy(q => q.ProductName).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && BrandIds.Contains(p.BrandId)).Count());
                        else if (TypeIds.Any() && BrandIds.Any())
                            return new Tuple<IEnumerable<Product>, int>(_context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && TypeIds.Contains(p.TypeId) && BrandIds.Contains(p.BrandId)).OrderBy(q => q.ProductName).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && TypeIds.Contains(p.TypeId) && BrandIds.Contains(p.BrandId)).Count());
                        else
                            return new Tuple<IEnumerable<Product>, int>(new List<Product>(), 0);
                    default:
                        if (!TypeIds.Any() && !BrandIds.Any())
                            return new Tuple<IEnumerable<Product>, int>(_context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice).OrderByDescending(q => q.CreateDate).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice).Count());
                        else if (TypeIds.Any() && !BrandIds.Any())
                            return new Tuple<IEnumerable<Product>, int>(_context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && TypeIds.Contains(p.TypeId)).OrderByDescending(q => q.CreateDate).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && TypeIds.Contains(p.TypeId)).Count());
                        else if (!TypeIds.Any() && BrandIds.Any())
                            return new Tuple<IEnumerable<Product>, int>(_context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && BrandIds.Contains(p.BrandId)).OrderByDescending(q => q.CreateDate).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && BrandIds.Contains(p.BrandId)).Count());
                        else if (TypeIds.Any() && BrandIds.Any())
                            return new Tuple<IEnumerable<Product>, int>(_context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && TypeIds.Contains(p.TypeId) && BrandIds.Contains(p.BrandId)).OrderByDescending(q => q.CreateDate).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.CategoryId == NidCategory && p.Price >= MinPrice && p.Price <= MaxPrice && TypeIds.Contains(p.TypeId) && BrandIds.Contains(p.BrandId)).Count());
                        else
                            return new Tuple<IEnumerable<Product>, int>(new List<Product>(), 0);
                }
            }
            catch (Exception)
            {
                return new Tuple<IEnumerable<Product>, int>(new List<Product>(), 0);
            }
        }
        //product page
        public Product GetProductByTitle(string Title, bool IncludeAll = true)
        {
            try
            {
                if (IncludeAll)
                    return _context.Products.Include(p => p.Category).Include(p => p.Brand).Include(p => p.Type).Include(p => p.Comments.Where(q => q.State == 1)).ThenInclude(p => p.User).FirstOrDefault(q => q.ProductName == Title && q.State == 0) ?? new Product();
                else
                    return _context.Products.FirstOrDefault(q => q.ProductName == Title && q.State == 0) ?? new Product();
            }
            catch (Exception)
            {
                return new Product();
            }
        }
        public Product GetProductById(Guid NidProduct, bool IncludeAll = true)
        {
            try
            {
                if (IncludeAll)
                    return _context.Products.Include(p => p.Category).Include(p => p.Brand).Include(p => p.Type).Include(p => p.Comments.Where(q => q.State == 1)).ThenInclude(p => p.User).FirstOrDefault(q => q.NidProduct == NidProduct && q.State == 0) ?? new Product();
                else
                    return _context.Products.FirstOrDefault(q => q.NidProduct == NidProduct && q.State == 0) ?? new Product();
            }
            catch (Exception)
            {
                return new Product();
            }
        }
        public IEnumerable<Product> GetSimilarProducts(Guid NidProduct)
        {
            try
            {
                var tmpProduct = _context.Products.FirstOrDefault(p => p.NidProduct == NidProduct) ?? new Product();
                if(tmpProduct.NidProduct != Guid.Empty)
                return _context.Products.Where(p => p.NidProduct != tmpProduct.NidProduct && p.BrandId == tmpProduct.BrandId && p.TypeId == tmpProduct.TypeId && p.Price >= (tmpProduct.Price - (tmpProduct.Price * (decimal)0.2)) && p.Price <= (tmpProduct.Price + (tmpProduct.Price * (decimal)0.2))).Take(5).ToList();
                else
                    return new List<Product>();
            }
            catch (Exception)
            {
                return new List<Product>();
            }
        }
        //login page
        public User LoginWithUsername(string username, string password)
        {
            try
            {
                if(username.Trim() != "anonymous")
                {
                    if (_context.Users.Any(p => p.Username.Trim() == username.Trim() && p.IsAdmin == false))
                    {
                        var user = _context.Users.FirstOrDefault(p => p.Username.Trim() == username.Trim());
                        if (user != null)
                        {
                            if (user.Password == Helpers.Commons.EncryptString(password.Trim()))
                            {
                                return user;
                            }
                            else
                                return new User();
                        }
                        else
                            return new User();
                    }
                    else
                        return new User();
                }else
                    return new User();
            }
            catch (Exception)
            {
                return new User();
            }
        }
        public bool CheckUsernameExist(string username) 
        {
            try
            {
                return _context.Users.Any(p => p.Username == username.Trim());
            }
            catch (Exception)
            {
                return false;
            }
        }
        public User GetUserById(Guid NidUser, bool IncludeAll = true) 
        {
            try
            {
                if(IncludeAll)
                    return _context.Users.Include(p => p.Carts).ThenInclude(p => p.Product).Include(p => p.Favorites).ThenInclude(p => p.Product).Include(p => p.Orders).ThenInclude(p => p.Ships).Include(p => p.Orders).ThenInclude(p => p.OrderDetails).ThenInclude(p => p.Product).FirstOrDefault(p => p.NidUser == NidUser) ?? new User();
                else
                    return _context.Users.FirstOrDefault(p => p.NidUser == NidUser) ?? new User();
            }
            catch (Exception)
            {
                return new User();
            }
        }
        public bool UpdateUser(User item)
        {
            try
            {
                _context.Entry(item).State = EntityState.Modified;
                _context.Entry(item).Property(p => p.PersianLastLoginDate).IsModified = false;
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
        //cart page
        public IEnumerable<Cart> GetCartsByUserId(Guid NidUser, bool IncludeAll = true)
        {
            try
            {
                if (IncludeAll)
                    return _context.Carts.Include(p => p.Product).Where(p => p.UserId == NidUser).ToList() ?? new List<Cart>();
                else
                    return _context.Carts.Where(p => p.UserId == NidUser).ToList() ?? new List<Cart>();
            }
            catch (Exception)
            {
                return new List<Cart>();
            }
        }
        public IEnumerable<Guid> GetCartProductsByUserId(Guid NidUser) 
        {
            return _context.Carts.Where(p => p.UserId == NidUser).Select(q => q.ProductId).ToList();
        }
        public int GetCartCountByUserId(Guid NidUser) 
        {
            try
            {
                return _context.Carts.Where(p => p.UserId == NidUser).Count();
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public decimal GetCartAggregateByUserId(Guid NidUser) 
        {
            try
            {
                return _context.Carts.Where(p => p.UserId == NidUser).Sum(p => p.Product.Price * p.Quantity);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public Cart GetCartById(Guid NidCart)
        {
            try
            {
                return _context.Carts.FirstOrDefault(p => p.NidCart == NidCart) ?? new Cart();
            }
            catch (Exception)
            {
                return new Cart();
            }
        }
        public Cart GetCartByProductId(Guid NidUser, Guid NidProduct) 
        {
            return _context.Carts.FirstOrDefault(p => p.ProductId == NidProduct && p.UserId == NidUser) ?? new Cart();
        }
        public bool UpdateCart(Cart item) 
        {
            try
            {
                _context.Entry(item).State = EntityState.Modified;
                _context.Entry(item).Property(p => p.PersianCreateDate).IsModified = false;
                _context.Entry(item).Property(p => p.PersianLastModified).IsModified = false;
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
        //favorite page
        public IEnumerable<Favorite> GetFavoritesByUserId(Guid NidUser, bool IncludeAll = true)
        {
            try
            {
                if (IncludeAll)
                    return _context.Favorites.Include(p => p.Product).Where(p => p.UserId == NidUser).ToList() ?? new List<Favorite>();
                else
                    return _context.Favorites.Where(p => p.UserId == NidUser).ToList() ?? new List<Favorite>();
            }
            catch (Exception)
            {
                return new List<Favorite>();
            }
        }
        public int GetFavoriteCountByUserId(Guid NidUser) 
        {
            try
            {
                return _context.Favorites.Where(p => p.UserId == NidUser).Count();
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public Favorite GetFavoriteById(Guid NidFav)
        {
            try
            {
                return _context.Favorites.FirstOrDefault(p => p.NidFav == NidFav) ?? new Favorite();
            }
            catch (Exception)
            {
                return new Favorite();
            }
        }
        public IEnumerable<Guid> GetFavoriteProductsByUserId(Guid NidUser)
        {
            return _context.Favorites.Where(p => p.UserId == NidUser).Select(q => q.ProductId).ToList();
        }
        public Favorite GetFavoriteByProductId(Guid NidUser, Guid NidProduct) 
        {
            return _context.Favorites.FirstOrDefault(p => p.ProductId == NidProduct && p.UserId == NidUser) ?? new Favorite();
        }
        public bool UpdateFavorite(Favorite item) 
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
        //checkout page
        public Order GetOrderByUserId(Guid NidUser, bool IncludeAll = true)
        {
            try
            {
                if(IncludeAll)
                    return _context.Orders.Include(p => p.Ships).Include(p => p.User).FirstOrDefault(p => p.UserId == NidUser && p.State == 0) ?? new Order();
                else
                    return _context.Orders.FirstOrDefault(p => p.UserId == NidUser && p.State == 0) ?? new Order();
            }
            catch (Exception)
            {
                return new Order();
            }
        }
        public Ship GetShipByOrderId(Guid NidOrder, bool IncludeAll = true)
        {
            try
            {
                if (IncludeAll)
                    return _context.Ships.Include(p => p.Order).FirstOrDefault(p => p.OrderId == NidOrder) ?? new Ship();
                else
                    return _context.Ships.FirstOrDefault(p => p.OrderId == NidOrder) ?? new Ship();
            }
            catch (Exception)
            {
                return new Ship();
            }
        }
        public IEnumerable<OrderDetail> GetOrderDetailsByOrderId(Guid NidOrder, bool IncludeAll = true) 
        {
            try
            {
                return _context.OrderDetails.Where(p => p.OrderId == NidOrder).ToList() ?? new List<OrderDetail>();
            }
            catch (Exception)
            {
                return new List<OrderDetail>();
            }
        }
        public bool UpdateOrder(Order item)
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
        public bool UpdateOrderDetail(OrderDetail item)
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
        public bool UpdateShip(Ship item)
        {
            try
            {
                _context.Entry(item).State = EntityState.Modified;
                _context.Entry(item).Property(p => p.PersianCreateDate).IsModified = false;
                _context.Entry(item).Property(p => p.PersianDueDate).IsModified = false;
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
        public Order GetOrderById(Guid NidOrder, bool IncludeAll = true) 
        {
            try
            {
                if(IncludeAll)
                    return _context.Orders.Include(p => p.Ships).Include(p => p.User).FirstOrDefault(p => p.NidOrder == NidOrder) ?? new Order();
                else
                    return _context.Orders.FirstOrDefault(p => p.NidOrder == NidOrder) ?? new Order();
            }
            catch (Exception)
            {
                return new Order();
            }
        }
        public IEnumerable<ShipPrice> GetShipPrices() 
        {
            try
            {
                return _context.ShipPrices.ToList() ?? new List<ShipPrice>();
            }
            catch (Exception)
            {
                return new List<ShipPrice>();
            }
        }
        public bool UpdateAvailableCount(Guid NidProduct,int Quantity) 
        {
            try
            {
                int currentCount = 0;
                var tmpProduct = _context.Products.FirstOrDefault(p => p.NidProduct == NidProduct);
                if(tmpProduct != null)
                    currentCount = tmpProduct.AvailableCount;
                if (currentCount > 0)
                {
                    if (tmpProduct.AvailableCount >= Quantity)
                        tmpProduct.AvailableCount = tmpProduct.AvailableCount - Quantity;
                    else
                        tmpProduct.AvailableCount = 0;
                    return UpdateProduct(tmpProduct);
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateProduct(Product item) 
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
        //generals
        public IEnumerable<Product> SearchProduct(string input)
        {
            List<Product> result = new List<Product>();
            foreach (var sr in _context.Products.Where(p => p.ProductName.Contains(input)).Take(3).ToList())
            {
                result.Add(sr);
            }
            return result;
        }
        public Tuple<IEnumerable<Product>, int> GetBargainedProducts(int Pagesize = 10, int Skip = 0)
        {
            try
            {
                return new Tuple<IEnumerable<Product>, int>(_context.Products.Include(p => p.Category).Include(p => p.Brand).Include(p => p.Type).Where(p => p.State == 0 && p.OffPercentage > 0).OrderByDescending(q => q.CreateDate).Skip(Skip * Pagesize).Take(Pagesize).ToList(), _context.Products.Where(p => p.State == 0 && p.OffPercentage > 0).Count());
            }
            catch (Exception)
            {
                return new Tuple<IEnumerable<Product>, int>(new List<Product>(), 0);
            }
        }
        //blogs

        public List<string> GetBlogKeywords()
        {
            List<string> keywords = new List<string>();
            foreach (var kw in _context.Blogs.OrderByDescending(p => p.CreateDate).Select(q => q.Keywords).Take(10))
            {
                if(kw != null)
                {
                    foreach (var k in kw.Split(','))
                    {
                        keywords.Add(k);
                    }
                }
            }
            return keywords;
        }

        public IEnumerable<Blog> GetBlogs(int State = 0, bool IncludeAll = true, int Pagesize = 10, int Skip = 0)
        {
            if (IncludeAll)
                return _context.Blogs.Include(x => x.Category).Include(x => x.User).Include(x => x.BlogComments.Where(q => q.State == 1)).ThenInclude(p => p.User).Where(t => t.State == State).Skip(Skip*Pagesize).Take(Pagesize).ToList();
            else
                return _context.Blogs.Where(t => t.State == State).Skip(Skip * Pagesize).Take(Pagesize).ToList();
        }

        public Blog GetBlog(string BlogTitle, bool IncludeAll = true)
        {
            try
            {
                if (IncludeAll)
                    return _context.Blogs.Include(x => x.Category).Include(x => x.User).Include(x => x.BlogComments.Where(q => q.State == 1)).ThenInclude(p => p.User).FirstOrDefault(p => p.Title == BlogTitle.Replace('_', ' ')) ?? new Blog();
                else
                    return _context.Blogs.FirstOrDefault(p => p.Title == BlogTitle.Replace('_',' ')) ?? new Blog();
            }
            catch (Exception)
            {
                return new Blog();
            }
        }

        public Blog GetBlogById(Guid NidBlog, bool IncludeAll = true)
        {
            try
            {
                if (IncludeAll)
                    return _context.Blogs.Include(x => x.Category).Include(x => x.User).Include(x => x.BlogComments.Where(q => q.State == 1)).ThenInclude(p => p.User).FirstOrDefault(p => p.NidBlog == NidBlog) ?? new Blog();
                else
                    return _context.Blogs.FirstOrDefault(p => p.NidBlog == NidBlog) ?? new Blog();
            }
            catch (Exception)
            {
                return new Blog();
            }
        }

        public IEnumerable<Blog> GetRelatedBlogs(int State = 0, bool IncludeAll = true, int Pagesize = 10, int Skip = 0)
        {
            if (IncludeAll)
                return _context.Blogs.Include(x => x.Category).Include(x => x.User).Include(x => x.BlogComments.Where(q => q.State == 1)).ThenInclude(p => p.User).Where(t => t.State == State).Skip(Skip * Pagesize).Take(Pagesize).ToList();
            else
                return _context.Blogs.Where(t => t.State == State).Skip(Skip * Pagesize).Take(Pagesize).ToList();
        }

        public IEnumerable<Blog> GetFilterBlog(byte SearchType, string Title, int State = 0, bool IncludeAll = true, int Pagesize = 10, int Skip = 0)
        {
            switch (SearchType)
            {
                case 1:
                    if (IncludeAll)
                        return _context.Blogs.Include(x => x.Category).Include(x => x.User).Include(x => x.BlogComments.Where(q => q.State == 1)).ThenInclude(p => p.User).Where(t => t.State == State && t.Category.CategoryName == Title.Replace('_', ' ')).Skip(Skip * Pagesize).Take(Pagesize).ToList();
                    else
                        return _context.Blogs.Where(t => t.State == State && t.Category.CategoryName == Title.Replace('_', ' ')).Skip(Skip * Pagesize).Take(Pagesize).ToList();
                case 2:
                    List<Blog> blogs = new List<Blog>();
                    var tmpKeys = _context.Blogs.Select(p => new { p.NidBlog, p.Keywords }).ToList();
                    foreach (var tmp in tmpKeys)
                    {
                        if (tmp.Keywords != null)
                        {
                            foreach (var k in tmp.Keywords.Split(','))
                            {
                                if (k == Title)
                                {
                                    if (IncludeAll)
                                    {
                                        if(_context.Blogs.Any(t => t.State == State && t.NidBlog == tmp.NidBlog))
                                            blogs.Add(_context.Blogs.Include(x => x.Category).Include(x => x.User).Include(x => x.BlogComments.Where(q => q.State == 1)).ThenInclude(p => p.User).FirstOrDefault(t => t.State == State && t.NidBlog == tmp.NidBlog));
                                    }
                                    else
                                    {
                                        if (_context.Blogs.Any(t => t.State == State && t.NidBlog == tmp.NidBlog))
                                            blogs.Add(_context.Blogs.FirstOrDefault(t => t.State == State && t.NidBlog == tmp.NidBlog));
                                    }
                                }
                            }
                        }
                    }
                    return blogs.Skip(Skip * Pagesize).Take(Pagesize).ToList();
                case 3:
                    if (IncludeAll)
                        return _context.Blogs.Include(x => x.Category).Include(x => x.User).Include(x => x.BlogComments.Where(q => q.State == 1)).ThenInclude(p => p.User).Where(t => t.State == State && (t.Category.CategoryName.Contains(Title.Replace('_', ' ')) || t.Title.Contains(Title.Replace('_', ' ')))).Skip(Skip * Pagesize).Take(Pagesize).ToList();
                    else
                        return _context.Blogs.Where(t => t.State == State && (t.Category.CategoryName.Contains(Title.Replace('_', ' ')) || t.Title.Contains(Title.Replace('_', ' ')))).Skip(Skip * Pagesize).Take(Pagesize).ToList();
                default:
                    return new List<Blog>();
            }
        }

        public IEnumerable<BlogCategory> GetBlogCategories(bool IncludeBlogs = true, byte State = 0)
        {
            if (IncludeBlogs)
                return _context.BlogCategories.Include(x => x.Blogs.Where(b => b.State == 0)).Where(t => t.State == State).ToList();
            else
                return _context.BlogCategories.Where(t => t.State == State).ToList();
        }

        public int GetBlogCount(int State = 0)
        {
            return _context.Blogs.Count(p => p.State == State);
        }

        public int GetBlogPostCount(byte SearchType, string Title, int State = 0)
        {
            switch (SearchType)
            {
                case 1:
                    return _context.Blogs.Count(t => t.State == State && t.Category.CategoryName == Title.Replace('_', ' '));
                case 2:
                    var tmpKeys = _context.Blogs.Select(p => new { p.NidBlog, p.Keywords }).ToList();
                    int counter = 0;
                    foreach (var tmp in tmpKeys)
                    {
                        if (tmp.Keywords != null)
                        {
                            foreach (var k in tmp.Keywords.Split(','))
                            {
                                if (k == Title)
                                    counter++;
                            }
                        }
                    }
                    return counter;
                case 3:
                    return _context.Blogs.Count(t => t.State == State && (t.Category.CategoryName.Contains(Title.Replace('_', ' ')) || t.Title.Contains(Title.Replace('_', ' '))));
                default:
                    return 0;
            }
        }
        public IEnumerable<Category> GetCategoriesProductIncluded() 
        {
            try
            {
                return _context.Categories.Include(p => p.Products.OrderByDescending(p => p.Rating).Take(5)).ThenInclude(q => q.Brand).Where(p => p.State == 0).ToList();
            }
            catch (Exception)
            {
                return new List<Category>();
            }
        }

        public User GetUserByUsername(string Username, bool IncludeAll = false)
        {
            try
            {
                if (_context.Users.Any(p => p.Username.Trim() == Username.Trim() && p.IsAdmin == false))
                {
                    var User = _context.Users.FirstOrDefault(p => p.Username.Trim() == Username.Trim());
                    if (User != null)
                        return User;
                    else
                        return new User();
                }
                else
                    return new User();
            }
            catch (Exception)
            {
                return new User();
            }
        }

        public IEnumerable<Models.File> GetCommonFiles(int RelateTypeStart, int RelateTypeEnd)
        {
            try
            {
                return _context.Files.Where(p => p.RelateType >= RelateTypeStart && p.RelateType <= RelateTypeEnd).ToList() ?? new List<Models.File>();
            }
            catch (Exception)
            {
                return new List<Models.File>();
            }
        }
    }
}
