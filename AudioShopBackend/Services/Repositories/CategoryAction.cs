using AudioShopBackend.Models;
using AudioShopBackend.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AudioShopBackend.Services.Repositories
{
    public class CategoryAction : ICategoryAction
    {
        private readonly AudioShopDbContext _context;
        public CategoryAction(AudioShopDbContext audioShopContext) 
        {
            _context = audioShopContext;
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
        public bool UpdateBrand(Brand item)
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

        public IEnumerable<Category> GetAllCategories(bool IncludeTypes = true, bool IncludeBrands = true, bool IncludeProducts = true)
        {
            if (IncludeTypes && IncludeBrands && IncludeProducts)
                return _context.Categories.Include(p => p.Types).Include(q => q.Brands).Include(x => x.Products);
            else if (IncludeTypes && IncludeBrands && !IncludeProducts)
                return _context.Categories.Include(p => p.Types).Include(q => q.Brands);
            else if (IncludeTypes && !IncludeBrands && IncludeProducts)
                return _context.Categories.Include(p => p.Types).Include(x => x.Products);
            else if (!IncludeTypes && IncludeBrands && IncludeProducts)
                return _context.Categories.Include(q => q.Brands).Include(x => x.Products);
            else if (IncludeTypes && !IncludeBrands && !IncludeProducts)
                return _context.Categories.Include(p => p.Types);
            else if (!IncludeTypes && IncludeBrands && !IncludeProducts)
                return _context.Categories.Include(q => q.Brands);
            else if (!IncludeTypes && !IncludeBrands && IncludeProducts)
                return _context.Categories.Include(x => x.Products);
            else if (!IncludeTypes && !IncludeBrands && !IncludeProducts)
                return _context.Categories;
            else
                return new List<Category>();
        }

        public IEnumerable<Category> GetCategories(bool IncludeTypes = true, bool IncludeBrands = true, bool IncludeProducts = true, byte State = 0)
        {
            if (IncludeTypes && IncludeBrands && IncludeProducts)
                return _context.Categories.Include(p => p.Types.Where(b => b.State == 0)).Include(q => q.Brands.Where(b => b.State == 0)).Include(x => x.Products.Where(b => b.State == 0)).Where(t => t.State == State);
            else if (IncludeTypes && IncludeBrands && !IncludeProducts)
                return _context.Categories.Include(p => p.Types.Where(b => b.State == 0)).Include(q => q.Brands.Where(b => b.State == 0)).Where(t => t.State == State);
            else if (IncludeTypes && !IncludeBrands && IncludeProducts)
                return _context.Categories.Include(p => p.Types.Where(b => b.State == 0)).Include(x => x.Products.Where(b => b.State == 0)).Where(t => t.State == State);
            else if (!IncludeTypes && IncludeBrands && IncludeProducts)
                return _context.Categories.Include(q => q.Brands.Where(b => b.State == 0)).Include(x => x.Products.Where(b => b.State == 0)).Where(t => t.State == State);
            else if (IncludeTypes && !IncludeBrands && !IncludeProducts)
                return _context.Categories.Include(p => p.Types.Where(b => b.State == 0)).Where(t => t.State == State);
            else if (!IncludeTypes && IncludeBrands && !IncludeProducts)
                return _context.Categories.Include(q => q.Brands.Where(b => b.State == 0)).Where(t => t.State == State);
            else if (!IncludeTypes && !IncludeBrands && IncludeProducts)
                return _context.Categories.Include(x => x.Products.Where(b => b.State == 0)).Where(t => t.State == State);
            else if (!IncludeTypes && !IncludeBrands && !IncludeProducts)
                return _context.Categories.Where(t => t.State == State);
            else
                return new List<Category>();
        }

        public Category GetCategory(Guid NidCategory, bool IncludeTypes = true, bool IncludeBrands = true, bool IncludeProducts = true)
        {
            if (IncludeTypes && IncludeBrands && IncludeProducts)
                return _context.Categories.Include(p => p.Types.Where(b => b.State == 0)).Include(q => q.Brands.Where(b => b.State == 0)).Include(x => x.Products.Where(b => b.State == 0)).FirstOrDefault(t => t.NidCategory == NidCategory) ?? new Category();
            else if (IncludeTypes && IncludeBrands && !IncludeProducts)
                return _context.Categories.Include(p => p.Types.Where(b => b.State == 0)).Include(q => q.Brands.Where(b => b.State == 0)).FirstOrDefault(t => t.NidCategory == NidCategory) ?? new Category();
            else if (IncludeTypes && !IncludeBrands && IncludeProducts)
                return _context.Categories.Include(p => p.Types.Where(b => b.State == 0)).Include(x => x.Products.Where(b => b.State == 0)).FirstOrDefault(t => t.NidCategory == NidCategory) ?? new Category();
            else if (!IncludeTypes && IncludeBrands && IncludeProducts)
                return _context.Categories.Include(q => q.Brands.Where(b => b.State == 0)).Include(x => x.Products.Where(b => b.State == 0)).FirstOrDefault(t => t.NidCategory == NidCategory) ?? new Category();
            else if (IncludeTypes && !IncludeBrands && !IncludeProducts)
                return _context.Categories.Include(p => p.Types.Where(b => b.State == 0)).FirstOrDefault(t => t.NidCategory == NidCategory) ?? new Category();
            else if (!IncludeTypes && IncludeBrands && !IncludeProducts)
                return _context.Categories.Include(q => q.Brands.Where(b => b.State == 0)).FirstOrDefault(t => t.NidCategory == NidCategory) ?? new Category();
            else if (!IncludeTypes && !IncludeBrands && IncludeProducts)
                return _context.Categories.Include(x => x.Products.Where(b => b.State == 0)).FirstOrDefault(t => t.NidCategory == NidCategory) ?? new Category();
            else if (!IncludeTypes && !IncludeBrands && !IncludeProducts)
                return _context.Categories.FirstOrDefault(t => t.NidCategory == NidCategory) ?? new Category();
            else
                return new Category();
        }

        public Brand GetBrand(Guid NidBrand)
        {
            try
            {
                return _context.Brands.FirstOrDefault(p => p.NidBrand == NidBrand) ?? new Brand();
            }
            catch (Exception)
            {
                return new Brand();
            }
        }

        public Models.Type GetType(Guid NidType)
        {
            try
            {
                return _context.Types.FirstOrDefault(p => p.NidType == NidType) ?? new Models.Type();
            }
            catch (Exception)
            {
                return new Models.Type();
            }
        }

        public bool UpdateCategory(Category item)
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

        public bool UpdateType(Models.Type item)
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
    }
}
