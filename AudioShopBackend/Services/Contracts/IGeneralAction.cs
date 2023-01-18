namespace AudioShopBackend.Services.Contracts
{
    public interface IGeneralAction
    {
        bool Add<T>(T item);
        bool Remove<T>(T item);
        bool Update<T>(T item);
    }
}
