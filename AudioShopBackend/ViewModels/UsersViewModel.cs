using AudioShopBackend.Models;

namespace AudioShopBackend.ViewModels
{
    public class UsersViewModel
    {
        public IEnumerable<User> AdminUsers { get; set; } = null!;
        public IEnumerable<User> RegularUsers { get; set; } = null!;
    }
}
