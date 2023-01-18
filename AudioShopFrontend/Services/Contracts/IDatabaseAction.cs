using AudioShopFrontend.Models;
using AudioShopFrontend.ViewModels;

namespace AudioShopFrontend.Services.Contracts
{
    public interface IDatabaseAction
    {
        //general
        bool Add<T>(T item);
        bool Remove<T>(T item);
        bool Update<T>(T item);
        IEnumerable<Models.File> GetFiles(Guid NidRelate);
        //index page
        IEnumerable<Category> GetCategories(bool IncludeTypes = true, bool IncludeBrands = true, bool IncludeProducts = true, byte State = 0);
        IEnumerable<Category> GetSpecialCategories();
        IEnumerable<Product> GetProducts(bool IncludeAll = true, int State = 0, int Pagesize = 10, int Skip = 0);
        IEnumerable<Product> GetSpecialProducts(int Pagesize = 10, int Skip = 0);
        IEnumerable<Product> GetOffProducts(int Pagesize = 10, int Skip = 0);
        Category GetCategory(Guid NidCategory, bool IncludeTypes = true, bool IncludeBrands = true, bool IncludeProducts = true);
        IEnumerable<Blog> GetLatestBlogs(bool IncludeAll = true, int Pagesize = 10,int Skip = 0);
        IEnumerable<Models.File> GetCommonFiles(int RelateTypeStart,int RelateTypeEnd);
        //category page
        Category GetCategoryByTitle(string Title, bool IncludeTypes = true, bool IncludeBrands = true, bool IncludeProducts = true);
        Tuple<IEnumerable<Product>,int> GetProductsByCategoryId(Guid NidCategory, int Pagesize = 10, int Skip = 0);
        Tuple<IEnumerable<Product>,int> GetFilteredProducts(Guid NidCategory, List<Guid> TypeIds, List<Guid> BrandIds, int SortType, decimal MinPrice = 0, decimal MaxPrice = 10000000, int Pagesize = 10, int Skip = 0);
        //product page
        Product GetProductByTitle(string Title,bool IncludeAll = true);
        Product GetProductById(Guid NidProduct, bool IncludeAll = true);
        IEnumerable<Product> GetSimilarProducts(Guid NidProduct);
        //login page
        public User LoginWithUsername(string username, string password);
        public bool CheckUsernameExist(string username);
        public User GetUserById(Guid NidUser, bool IncludeAll = true);
        public User GetUserByUsername(string Username, bool IncludeAll = false);
        bool UpdateUser(User item);
        //cart page
        public IEnumerable<Cart> GetCartsByUserId(Guid NidUser, bool IncludeAll = true);
        public IEnumerable<Guid> GetCartProductsByUserId(Guid NidUser);
        public int GetCartCountByUserId(Guid NidUser);
        public decimal GetCartAggregateByUserId(Guid NidUser);
        public Cart GetCartById(Guid NidCart);
        public Cart GetCartByProductId(Guid NidUser,Guid NidProduct);
        bool UpdateCart(Cart item);
        //favorite page
        public IEnumerable<Favorite> GetFavoritesByUserId(Guid NidUser, bool IncludeAll = true);
        public IEnumerable<Guid> GetFavoriteProductsByUserId(Guid NidUser);
        public int GetFavoriteCountByUserId(Guid NidUser);
        public Favorite GetFavoriteById(Guid NidFav);
        public Favorite GetFavoriteByProductId(Guid NidUser, Guid NidProduct);
        bool UpdateFavorite(Favorite item);
        //checkout page
        public Order GetOrderByUserId(Guid NidUser, bool IncludeAll = true);
        public Ship GetShipByOrderId(Guid NidOrder, bool IncludeAll = true);
        public IEnumerable<OrderDetail> GetOrderDetailsByOrderId(Guid NidOrder, bool IncludeAll = true);
        public IEnumerable<ShipPrice> GetShipPrices();
        bool UpdateOrder(Order item);
        bool UpdateOrderDetail(OrderDetail item);
        bool UpdateShip(Ship item);
        public Order GetOrderById(Guid NidOrder, bool IncludeAll = true);
        public bool UpdateAvailableCount(Guid NidProduct, int Quantity);
        bool UpdateProduct(Product item);
        //general
        public IEnumerable<Product> SearchProduct(string input);
        public Tuple<IEnumerable<Product>, int> GetBargainedProducts(int Pagesize = 10, int Skip = 0);
        public bool SendEmail(MailRequest mailRequest);
        //blog
        IEnumerable<BlogCategory> GetBlogCategories(bool IncludeBlogs = true, byte State = 0);
        List<string> GetBlogKeywords();
        IEnumerable<Blog> GetBlogs(int State = 0, bool IncludeAll = true, int Pagesize = 10, int Skip = 0);
        Blog GetBlog(string BlogTitle,bool IncludeAll = true);
        Blog GetBlogById(Guid NidBlog, bool IncludeAll = true);
        IEnumerable<Blog> GetRelatedBlogs(int State = 0, bool IncludeAll = true, int Pagesize = 10, int Skip = 0);
        IEnumerable<Blog> GetFilterBlog(byte SearchType, string Title, int State = 0, bool IncludeAll = true, int Pagesize = 10, int Skip = 0);
        int GetBlogCount(int State = 0);
        int GetBlogPostCount(byte SearchType, string Title, int State = 0);
        //categories page
        public IEnumerable<Category> GetCategoriesProductIncluded();
    }
}
