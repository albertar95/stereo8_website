using AudioShopFrontend.Models;

namespace AudioShopFrontend.ViewModels
{
    public class CheckoutViewModel
    {
        public IEnumerable<Cart> Carts { get; set; } = new List<Cart>();
        public IEnumerable<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public IEnumerable<ShipPrice> ShipPrices { get; set; } = new List<ShipPrice>();
        public Order Order { get; set; } = new Order();
        public User User { get; set; } = new User();
    }
}
