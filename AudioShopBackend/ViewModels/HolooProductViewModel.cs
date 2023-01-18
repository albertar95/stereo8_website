using AudioShopBackend.Models.RepDbModel;

namespace AudioShopBackend.ViewModels
{
    public class HolooProductViewModel
    {
        public IEnumerable<Article> Articles { get; set; }
        public RepLog Latest { get; set; }
    }
}
