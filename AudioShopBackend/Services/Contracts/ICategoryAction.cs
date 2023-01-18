using AudioShopBackend.Models;

namespace AudioShopBackend.Services.Contracts
{
    public interface ICategoryAction : IGeneralAction
    {
        IEnumerable<Category> GetCategories(bool IncludeTypes = true, bool IncludeBrands = true, bool IncludeProducts = true, byte State = 0);
        IEnumerable<Category> GetAllCategories(bool IncludeTypes = true, bool IncludeBrands = true, bool IncludeProducts = true);
        Category GetCategory(Guid NidCategory, bool IncludeTypes = true, bool IncludeBrands = true, bool IncludeProducts = true);
        Brand GetBrand(Guid NidBrand);
        Models.Type GetType(Guid NidType);
        //updates
        bool UpdateBrand(Brand item);
        bool UpdateCategory(Category item);
        bool UpdateType(Models.Type item);
    }
}
