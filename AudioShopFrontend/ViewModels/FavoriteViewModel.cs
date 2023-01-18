using AudioShopFrontend.Models;

namespace AudioShopFrontend.ViewModels
{
    public class FavoriteViewModel
    {
        public IEnumerable<Favorite> Favorites { get; set; } = new List<Favorite>();
        public IEnumerable<Models.File> Files { get; set; } = new List<Models.File>();
    }
}
