using AudioShopBackend.Models;
using AudioShopBackend.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AudioShopBackend.Services.Repositories
{
    public class CommonAction : ICommonAction
    {
        private readonly AudioShopDbContext _context;
        public CommonAction(AudioShopDbContext context)
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

        public Models.File GetFile(Guid NidFile)
        {
            try
            {
                return _context.Files.FirstOrDefault(p => p.NidFile == NidFile) ?? new Models.File();
            }
            catch (Exception)
            {
                return new Models.File();
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

        public Setting GetSetting(Guid NidSetting, byte State = 0)
        {
            try
            {
                return _context.Settings.FirstOrDefault(p => p.NidSetting == NidSetting && p.State == State) ?? new Setting(); ;
            }
            catch (Exception)
            {
                return new Setting();
            }
        }

        public IEnumerable<Setting> GetSettings(int Pagesize = 100, int Skip = 0, byte State = 0)
        {
            try
            {
                return _context.Settings.Where(p => p.State == State).Skip(Skip).Take(Pagesize).ToList();
            }
            catch (Exception)
            {
                return new List<Setting>();
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

        public bool UpdateFile(Models.File item)
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
        public string[] GetIndexPageValues() 
        {
            string[] result = new string[4];
            result[0] = _context.Products.Count(p => p.State == 0).ToString();
            if(_context.Orders.Any())
                result[1] = String.Format("{0:n0} تومان", _context.Orders.Where(p => p.State == 101 || p.State == 100).Sum(p => p.TotalPrice));
            else
                result[1] = String.Format("{0:n0} تومان", 0);
            if (_context.Ships.Any())
                result[2] = String.Format("{0}", ((_context.Ships.Count(p => p.State == 3)) / (_context.Ships.Count())) * 100);
            else
                result[2] = String.Format("{0}", 0);
            result[3] = _context.Comments.Count(p => p.State == 0).ToString();
            return result;
        }

        public IEnumerable<Models.File> GetCommonFiles()
        {
            try
            {
                return _context.Files.Where(p => p.RelateType >= 16 && p.RelateType <= 29).ToList() ?? new List<Models.File>();
            }
            catch (Exception)
            {
                return new List<Models.File>();
            }
        }
    }
}
