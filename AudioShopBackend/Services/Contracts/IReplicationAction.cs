using AudioShopBackend.Models.RepDbModel;

namespace AudioShopBackend.Services.Contracts
{
    public interface IReplicationAction
    {
        IEnumerable<Article> GetArticles();
        RepLog GetLastRepLog();
    }
}
