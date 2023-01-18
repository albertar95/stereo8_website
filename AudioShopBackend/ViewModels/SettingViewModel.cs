using AudioShopBackend.Models;

namespace AudioShopBackend.ViewModels
{
    public class SettingViewModel
    {
        public IEnumerable<Setting> Settings { get; set; } = new List<Setting>()!;
        public IEnumerable<Models.File> Files { get; set; } = new List<Models.File>()!;
    }
}
