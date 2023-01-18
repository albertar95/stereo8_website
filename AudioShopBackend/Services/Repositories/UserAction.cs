using AudioShopBackend.Models;
using AudioShopBackend.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AudioShopBackend.Services.Repositories
{
    public class UserAction : IUserAction
    {
        private readonly AudioShopDbContext _context;
        public UserAction(AudioShopDbContext context) 
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

        public IEnumerable<User> GetAllUsers(bool IncludeIsDisabled = true)
        {
            try
            {
                if (IncludeIsDisabled)
                    return _context.Users.ToList();
                else
                    return _context.Users.Where(x => x.IsDisabled == IncludeIsDisabled).ToList();
            }
            catch (Exception)
            {
                return new List<User>();
            }
        }

        public User GetUser(Guid niduser)
        {
            try
            {
                return _context.Users.FirstOrDefault(p => p.NidUser == niduser) ?? new User();
            }
            catch (Exception)
            {
                return new User();
            }
        }

        public IEnumerable<User> GetUsers(bool IncludeIsDisabled = true, bool AdminUsers = true)
        {
            try
            {
                if (IncludeIsDisabled)
                    return _context.Users.Where(p => p.IsAdmin == AdminUsers).ToList();
                else
                    return _context.Users.Where(x => x.IsDisabled == IncludeIsDisabled && x.IsAdmin == AdminUsers).ToList();
            }
            catch (Exception)
            {
                return new List<User>();
            }
        }

        public User LoginWithUsername(string username, string password)
        {
            try
            {
                if (_context.Users.Any(p => p.Username.Trim() == username.Trim() && p.IsAdmin == true))
                {
                    var User = _context.Users.FirstOrDefault(p => p.Username.Trim() == username.Trim());
                    if (User.Password == Helpers.Commons.EncryptString(password.Trim()))
                    {
                        if(!User.IsDisabled)
                        {
                            try
                            {
                                User.LastLoginDate = DateTime.Now;
                                _context.Update<User>(User);
                            }
                            catch (Exception)
                            {
                            }
                        }
                        return User;
                    }
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
    }
}
