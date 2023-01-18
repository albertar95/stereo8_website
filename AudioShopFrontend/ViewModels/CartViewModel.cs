using AudioShopFrontend.Models;

namespace AudioShopFrontend.ViewModels
{
    public class CartViewModel
    {
        public IEnumerable<Cart> Carts { get; set; } = new List<Cart>();
        public IEnumerable<Models.File> Files { get; set; } = new List<Models.File>();
    }
}
