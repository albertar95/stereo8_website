using AudioShopBackend.Models.RepDbModel;
using AudioShopBackend.Services.Contracts;

namespace AudioShopBackend.Services.Repositories
{
    public class ReplicationAction : IReplicationAction
    {
        private readonly HoloRepDbContext _holoRepDbContext;

        public ReplicationAction(HoloRepDbContext holoRepDbContext)
        {
            _holoRepDbContext = holoRepDbContext;
        }

        public IEnumerable<Article> GetArticles()
        {
            return _holoRepDbContext.Articles.Where(p => !string.IsNullOrWhiteSpace(p.AName)).ToList();
        }

        public RepLog GetLastRepLog()
        {
            return _holoRepDbContext.RepLogs.OrderByDescending(p => p.ReplicationDate).FirstOrDefault() ?? new RepLog();
        }
    }
}
