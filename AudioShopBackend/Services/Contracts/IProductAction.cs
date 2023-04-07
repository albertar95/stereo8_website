using AudioShopBackend.Models;

namespace AudioShopBackend.Services.Contracts
{
    public interface IProductAction : IGeneralAction
    {
        IEnumerable<Comment> GetComments(int State = 0,int Pagesize = 100,int Skip = 0);
        IEnumerable<Ship> GetShips(int State = 0,int Pagesize = 100, int Skip = 0);
        IEnumerable<Order> GetOrders(int State = 0, bool IncludeSuccessfulls = true,bool IncludeFailedPayments = false, bool IncludeAll = true, int Pagesize = 100, int Skip = 0);
        IEnumerable<Product> GetProducts(bool IncludeAll = true, int State = 0, int Pagesize = 100, int Skip = 0);
        IEnumerable<Product> GetProductsByCategory(Guid NidCategory,Guid NidType,Guid NidBrand, int State = 0, bool IncludeAll = true, int Pagesize = 100, int Skip = 0);
        IEnumerable<Product> GetProductsByCreateDate(DateTime From,DateTime To, int State = 0, bool IncludeAll = true, int Pagesize = 100, int Skip = 0);
        IEnumerable<Product> GetProductsByPriceRange(decimal From, decimal To, int State = 0, bool IncludeAll = true, int Pagesize = 100, int Skip = 0);
        IEnumerable<Product> GetProductsByAvailablity(int AvailableCount, int State = 0, bool IncludeAll = true, int Pagesize = 100, int Skip = 0);
        Comment GetComment(Guid NidComment);
        Order GetOrder(Guid NidOrder);
        Ship GetShip(Guid NidShip);
        Product GetProduct(Guid NidProduct,bool IncludeAll = false);
        bool UpdateComment(Comment item);
        bool UpdateOrder(Order item);
        bool UpdateOrderDetail(OrderDetail item);
        bool UpdateProduct(Product item);
        bool UpdateShip(Ship item);
    }
}
