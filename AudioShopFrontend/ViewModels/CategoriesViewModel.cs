using AudioShopFrontend.Models;

namespace AudioShopFrontend.ViewModels
{
    public class CategoriesViewModel
    {
        public IEnumerable<Models.Category> Categories { get; set; } = new List<Models.Category>();
        public IEnumerable<Models.File> Files { get; set; } = new List<Models.File>();
    }
}
