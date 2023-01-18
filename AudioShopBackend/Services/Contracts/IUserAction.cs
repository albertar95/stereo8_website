using AudioShopBackend.Models;

namespace AudioShopBackend.Services.Contracts
{
    public interface IUserAction : IGeneralAction
    {
        IEnumerable<User> GetAllUsers(bool IncludeIsDisabled = true);
        IEnumerable<User> GetUsers(bool IncludeIsDisabled = true,bool AdminUsers = true);
        User GetUser(Guid niduser);
        User LoginWithUsername(string username,string password);
        bool UpdateUser(User item);

    }
}
