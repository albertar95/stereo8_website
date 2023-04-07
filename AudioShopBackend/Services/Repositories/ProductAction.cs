using AudioShopBackend.Models;
using AudioShopBackend.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AudioShopBackend.Services.Repositories
{
    public class ProductAction : IProductAction
    {
        private readonly AudioShopDbContext _context;
        public ProductAction(AudioShopDbContext context)
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
        public Comment GetComment(Guid NidComment)
        {
            try
            {
                return _context.Comments.FirstOrDefault(p => p.NidComment == NidComment) ?? new Comment();
            }
            catch (Exception)
            {
                return new Comment();
            }
        }

        public IEnumerable<Comment> GetComments(int State = 0,int Pagesize = 100, int Skip = 0)
        {
            try
            {
                return _context.Comments.Include(q => q.User).Where(p => p.State == State).OrderByDescending(p => p.CreateDate).Skip(Skip).Take(Pagesize).ToList();
            }
            catch (Exception)
            {
                return new List<Comment>();
            }
        }

        public IEnumerable<Ship> GetShips(int State = 1,int Pagesize = 100, int Skip = 0)
        {
            try
            {
                return _context.Ships.Include(q => q.Order).ThenInclude(x => x.User).Where(p => p.State == State).OrderByDescending(p => p.CreateDate).Skip(Skip).Take(Pagesize).ToList();
            }
            catch (Exception)
            {
                return new List<Ship>();
            }
        }

        public Ship GetShip(Guid NidShip)
        {
            try
            {
                return _context.Ships.FirstOrDefault(p => p.NidShip == NidShip) ?? new Ship();
            }
            catch (Exception)
            {
                return new Ship();
            }
        }

        public IEnumerable<Product> GetProducts(bool IncludeAll = true,int State = 0, int Pagesize = 100, int Skip = 0)
        {
            try
            {
                if(IncludeAll)
                return _context.Products.Include(p => p.Category).Include(q => q.Type).Include(x => x.Brand).Where(p => p.State == State).OrderByDescending(q => q.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                else
                    return _context.Products.Where(p => p.State == State).OrderByDescending(q => q.CreateDate).Skip(Skip).Take(Pagesize).ToList();
            }
            catch (Exception)
            {
                return new List<Product>();
            }
        }

        public IEnumerable<Product> GetProductsByCategory(Guid NidCategory, Guid NidType, Guid NidBrand, int State = 0, bool IncludeAll = true, int Pagesize = 100, int Skip = 0)
        {
            try
            {
                if(IncludeAll)
                {
                    if (NidType == Guid.Empty && NidBrand == Guid.Empty)
                        return _context.Products.Include(p => p.Category).Include(q => q.Type).Include(x => x.Brand).Where(p => p.CategoryId == NidCategory && p.State == State).OrderByDescending(q => q.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                    else if (NidType != Guid.Empty && NidBrand == Guid.Empty)
                        return _context.Products.Include(p => p.Category).Include(q => q.Type).Include(x => x.Brand).Where(p => p.CategoryId == NidCategory && p.State == State && p.TypeId == NidType).OrderByDescending(q => q.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                    else if (NidType == Guid.Empty && NidBrand != Guid.Empty)
                        return _context.Products.Include(p => p.Category).Include(q => q.Type).Include(x => x.Brand).Where(p => p.CategoryId == NidCategory && p.State == State && p.BrandId == NidBrand).OrderByDescending(q => q.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                    else if (NidType != Guid.Empty && NidBrand != Guid.Empty)
                        return _context.Products.Include(p => p.Category).Include(q => q.Type).Include(x => x.Brand).Where(p => p.CategoryId == NidCategory && p.State == State && p.TypeId == NidType && p.BrandId == NidBrand).OrderByDescending(q => q.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                    else
                        return _context.Products.Include(p => p.Category).Include(q => q.Type).Include(x => x.Brand).Where(p => p.CategoryId == NidCategory && p.State == State).OrderByDescending(q => q.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                }
                else
                {
                    if (NidType == Guid.Empty && NidBrand == Guid.Empty)
                        return _context.Products.Where(p => p.CategoryId == NidCategory && p.State == State).OrderByDescending(q => q.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                    else if (NidType != Guid.Empty && NidBrand == Guid.Empty)
                        return _context.Products.Where(p => p.CategoryId == NidCategory && p.State == State && p.TypeId == NidType).OrderByDescending(q => q.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                    else if (NidType == Guid.Empty && NidBrand != Guid.Empty)
                        return _context.Products.Where(p => p.CategoryId == NidCategory && p.State == State && p.BrandId == NidBrand).OrderByDescending(q => q.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                    else if (NidType != Guid.Empty && NidBrand != Guid.Empty)
                        return _context.Products.Where(p => p.CategoryId == NidCategory && p.State == State && p.TypeId == NidType && p.BrandId == NidBrand).OrderByDescending(q => q.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                    else
                        return _context.Products.Where(p => p.CategoryId == NidCategory && p.State == State).OrderByDescending(q => q.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                }

            }
            catch (Exception)
            {
                return new List<Product>();
            }
        }

        public IEnumerable<Product> GetProductsByCreateDate(DateTime From, DateTime To, int State = 0, bool IncludeAll = true, int Pagesize = 100, int Skip = 0)
        {
            try
            {
                if(IncludeAll)
                return _context.Products.Include(p => p.Category).Include(q => q.Type).Include(x => x.Brand).Where(p => p.CreateDate >= From && p.CreateDate <= To && p.State == State).OrderByDescending(q => q.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                else
                    return _context.Products.Where(p => p.CreateDate >= From && p.CreateDate <= To && p.State == State).OrderByDescending(q => q.CreateDate).Skip(Skip).Take(Pagesize).ToList();
            }
            catch (Exception)
            {
                return new List<Product>();
            }
        }

        public IEnumerable<Product> GetProductsByPriceRange(decimal From, decimal To, int State = 0, bool IncludeAll = true, int Pagesize = 100, int Skip = 0)
        {
            try
            {
                if(IncludeAll)
                return _context.Products.Include(p => p.Category).Include(q => q.Type).Include(x => x.Brand).Where(p => p.Price >= From && p.Price <= To && p.State == State).OrderByDescending(q => q.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                else
                    return _context.Products.Where(p => p.Price >= From && p.Price <= To && p.State == State).OrderByDescending(q => q.CreateDate).Skip(Skip).Take(Pagesize).ToList();
            }
            catch (Exception)
            {
                return new List<Product>();
            }
        }

        public IEnumerable<Product> GetProductsByAvailablity(int AvailableCount, int State = 0, bool IncludeAll = true, int Pagesize = 100, int Skip = 0)
        {
            try
            {
                if(IncludeAll)
                {
                    if (AvailableCount == 0)
                        return _context.Products.Include(p => p.Category).Include(q => q.Type).Include(x => x.Brand).Where(p => p.AvailableCount == 0 && p.State == State).OrderByDescending(q => q.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                    else
                        return _context.Products.Include(p => p.Category).Include(q => q.Type).Include(x => x.Brand).Where(p => p.AvailableCount >= AvailableCount && p.State == State).OrderByDescending(q => q.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                }
                else
                {
                    if (AvailableCount == 0)
                        return _context.Products.Where(p => p.AvailableCount == 0 && p.State == State).OrderByDescending(q => q.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                    else
                        return _context.Products.Where(p => p.AvailableCount >= AvailableCount && p.State == State).OrderByDescending(q => q.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                }

            }
            catch (Exception)
            {
                return new List<Product>();
            }
        }

        public Product GetProduct(Guid NidProduct, bool IncludeAll = false)
        {
            try
            {
                if(!IncludeAll)
                return _context.Products.FirstOrDefault(p => p.NidProduct == NidProduct) ?? new Product();
                else
                    return _context.Products.Include(q => q.Brand).Include(q => q.Type).Include(q => q.Category).Include(q => q.User).FirstOrDefault(p => p.NidProduct == NidProduct) ?? new Product();
            }
            catch (Exception)
            {
                return new Product();
            }
        }

        public IEnumerable<Order> GetOrders(int State = 0,bool IncludeSuccessfulls = true, bool IncludeFailedPayments = false, bool IncludeAll = true, int Pagesize = 100, int Skip = 0)
        {
            try
            {
                if (IncludeAll)
                {
                    if(IncludeSuccessfulls)
                    {
                        if(IncludeFailedPayments)
                            return _context.Orders.Include(q => q.Ships).Include(q => q.OrderDetails).Include(q => q.User).Where(p => p.State >= State || p.State < 0).OrderByDescending(x => x.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                        else
                            return _context.Orders.Include(q => q.Ships).Include(q => q.OrderDetails).Include(q => q.User).Where(p => p.State >= State).OrderByDescending(x => x.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                    }
                    else
                    {
                        if(IncludeFailedPayments)
                            return _context.Orders.Include(q => q.Ships).Include(q => q.OrderDetails).Include(q => q.User).Where(p => p.State == State || p.State < 0).OrderByDescending(x => x.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                        else
                            return _context.Orders.Include(q => q.Ships).Include(q => q.OrderDetails).Include(q => q.User).Where(p => p.State == State).OrderByDescending(x => x.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                    }
                }
                else
                {
                    if(IncludeSuccessfulls)
                    {
                        if(IncludeFailedPayments)
                            return _context.Orders.Where(p => p.State >= State || p.State < 0).OrderByDescending(x => x.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                        else
                            return _context.Orders.Where(p => p.State >= State).OrderByDescending(x => x.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                    }
                    else
                    {
                        if(IncludeFailedPayments)
                            return _context.Orders.Where(p => p.State == State || p.State < 0).OrderByDescending(x => x.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                        else
                            return _context.Orders.Where(p => p.State == State).OrderByDescending(x => x.CreateDate).Skip(Skip).Take(Pagesize).ToList();
                    }
                }
            }
            catch (Exception)
            {
                return new List<Order>();
            }
        }

        public Order GetOrder(Guid NidOrder)
        {
            try
            {
                return _context.Orders.Include(q => q.Ships).Include(q => q.User).Include(q => q.OrderDetails).ThenInclude(q => q.Product).FirstOrDefault(p => p.NidOrder == NidOrder) ?? new Order();
            }
            catch (Exception)
            {
                return new Order();
            }
        }

        public bool UpdateComment(Comment item)
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
    }
}
