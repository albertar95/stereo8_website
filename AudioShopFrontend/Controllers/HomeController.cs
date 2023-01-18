using AudioShopFrontend.Helpers;
using AudioShopFrontend.Models;
using AudioShopFrontend.Services.Contracts;
using AudioShopFrontend.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components.Web;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Security.Policy;
using System.Text;
using ZarinPal.Class;

namespace AudioShopFrontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDatabaseAction _db;

        public HomeController(ILogger<HomeController> logger, IDatabaseAction databaseAction)
        {
            _logger = logger;
            _db = databaseAction;
        }
        //first page section
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.SidebarCategories = _db.GetCategories(false, false, false);
            model.SpecialProducts = _db.GetSpecialProducts();
            List<Models.File> files = new List<Models.File>();
            foreach (var prd in model.SpecialProducts)
            {
                foreach (var f in _db.GetFiles(prd.NidProduct))
                {
                    files.Add(f);
                }
            }
            foreach (var f in _db.GetCommonFiles(16,24))
            {
                files.Add(f);
            }
            model.SpecialCategories = _db.GetSpecialCategories();
            foreach (var prd in model.SpecialCategories)
            {
                foreach (var f in _db.GetFiles(prd.NidCategory))
                {
                    files.Add(f);
                }
            }
            model.LatestBlogs = _db.GetLatestBlogs(true, 4, 0);
            foreach (var prd in model.LatestBlogs)
            {
                foreach (var f in _db.GetFiles(prd.NidBlog))
                {
                    files.Add(f);
                }
            }
            model.OffProducts = _db.GetOffProducts(5);
            foreach (var prd in model.OffProducts)
            {
                foreach (var f in _db.GetFiles(prd.NidProduct))
                {
                    files.Add(f);
                }
            }
            model.Files = files;
            return View(model);
        }
        //category page section
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public IActionResult Category(string Title,string BrandId = "",string TypeId = "")
        {
            CategoryViewModel model = new CategoryViewModel();
            model.Category = _db.GetCategoryByTitle(Title.Trim().Replace('_',' '));
            List<Models.File> Files = new List<Models.File>();
            if(model.Category.NidCategory != Guid.Empty)
            {
                Tuple<IEnumerable<Product>, int> tmpProducts = new Tuple<IEnumerable<Product>, int>(new List<Product>(),0);
                if (string.IsNullOrWhiteSpace(BrandId) && string.IsNullOrWhiteSpace(TypeId))
                {
                    tmpProducts = _db.GetProductsByCategoryId(model.Category.NidCategory);
                }
                else if (!string.IsNullOrWhiteSpace(BrandId) && string.IsNullOrWhiteSpace(TypeId))
                {
                    tmpProducts = _db.GetFilteredProducts(model.Category.NidCategory, model.Category.Types.Select(p => p.NidType).ToList(), new List<Guid>() { Guid.Parse(BrandId)}, 0);
                    model.BrandId = Guid.Parse(BrandId);
                }
                else if (string.IsNullOrWhiteSpace(BrandId) && !string.IsNullOrWhiteSpace(TypeId))
                {
                    tmpProducts = _db.GetFilteredProducts(model.Category.NidCategory, new List<Guid>() { Guid.Parse(TypeId) }, model.Category.Brands.Select(p => p.NidBrand).ToList(), 0);
                    model.TypeId = Guid.Parse(TypeId);
                }
                else if (!string.IsNullOrWhiteSpace(BrandId) && !string.IsNullOrWhiteSpace(TypeId))
                {
                    tmpProducts = _db.GetFilteredProducts(model.Category.NidCategory, new List<Guid>() { Guid.Parse(TypeId) }, new List<Guid>() { Guid.Parse(BrandId) }, 0);
                    model.BrandId = Guid.Parse(BrandId);
                    model.TypeId = Guid.Parse(TypeId);
                }
                model.Products = tmpProducts.Item1;
                model.ProductCount = tmpProducts.Item2;
                foreach (var f in _db.GetFiles(model.Category.NidCategory))
                {
                    Files.Add(f);
                }
                foreach (var prd in model.Products)
                {
                    foreach (var f in _db.GetFiles(prd.NidProduct))
                    {
                        Files.Add(f);
                    }
                }
            }
            model.Files = Files;
            return View(model);
        }
        public IActionResult CategoryFilter(string NidCategory,string MinPrice,string MaxPrice,string TypeId, string BrandId, int Sorttype)
        {
            CategoryViewModel model = new CategoryViewModel();
            model.Category = _db.GetCategory(Guid.Parse(NidCategory));
            if (model.Category.NidCategory != Guid.Empty)
            {
                List<Models.File> Files = new List<Models.File>();
                List<Guid> types = new List<Guid>();
                List<Guid> brands = new List<Guid>();
                if(!string.IsNullOrWhiteSpace(TypeId))
                {
                    foreach (var typ in TypeId.Split(','))
                    {
                        types.Add(Guid.Parse(typ));
                    }
                }
                if (!string.IsNullOrWhiteSpace(BrandId))
                {
                    foreach (var brd in BrandId.Split(','))
                    {
                        brands.Add(Guid.Parse(brd));
                    }
                }
                var tmpProduct = _db.GetFilteredProducts(model.Category.NidCategory, types, brands, Sorttype, decimal.Parse(MinPrice), decimal.Parse(MaxPrice));
                model.Products = tmpProduct.Item1;
                model.ProductCount = tmpProduct.Item2;
                model.SortType = Sorttype;
                foreach (var f in _db.GetFiles(model.Category.NidCategory))
                {
                    Files.Add(f);
                }
                foreach (var prd in model.Products)
                {
                    foreach (var f in _db.GetFiles(prd.NidProduct))
                    {
                        Files.Add(f);
                    }
                }
                model.Files = Files;
                return Json(new { success = true, html = RenderViewToString.RenderViewAsync(this, "_CategoryFilter", model, true), countMessage = $"تعداد محصولات : {model.ProductCount}" });
            }else
                return Json(new { success = false, html = "" });
        }
        public IActionResult CategoryPagination(string NidCategory, string MinPrice, string MaxPrice, string TypeId, string BrandId,int PageNumber, int Sorttype)
        {
            CategoryViewModel model = new CategoryViewModel();
            model.Category = _db.GetCategory(Guid.Parse(NidCategory));
            if (model.Category.NidCategory != Guid.Empty)
            {
                List<Models.File> Files = new List<Models.File>();
                List<Guid> types = new List<Guid>();
                List<Guid> brands = new List<Guid>();
                if (!string.IsNullOrWhiteSpace(TypeId))
                {
                    foreach (var typ in TypeId.Split(','))
                    {
                        types.Add(Guid.Parse(typ));
                    }
                }
                if (!string.IsNullOrWhiteSpace(BrandId))
                {
                    foreach (var brd in BrandId.Split(','))
                    {
                        brands.Add(Guid.Parse(brd));
                    }
                }
                var tmpProduct = _db.GetFilteredProducts(model.Category.NidCategory, types, brands, Sorttype, decimal.Parse(MinPrice), decimal.Parse(MaxPrice),10,PageNumber-1);
                model.Products = tmpProduct.Item1;
                model.ProductCount = tmpProduct.Item2;
                model.PageNumber = PageNumber;
                model.SortType = Sorttype;
                foreach (var f in _db.GetFiles(model.Category.NidCategory))
                {
                    Files.Add(f);
                }
                foreach (var prd in model.Products)
                {
                    foreach (var f in _db.GetFiles(prd.NidProduct))
                    {
                        Files.Add(f);
                    }
                }
                model.Files = Files;
                return Json(new { success = true, html = RenderViewToString.RenderViewAsync(this, "_CategoryPagination", model, true), countMessage = $"تعداد محصولات : {model.ProductCount}" });
            }
            else
                return Json(new { success = false, html = "" });
        }
        //product page section
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public IActionResult Product(string Title)
         {
            ProductViewModel model = new ProductViewModel();
            model.Product = _db.GetProductByTitle(Title.Trim().Replace('_', ' '));
            List<Models.File> files = new List<Models.File>();
            if(model.Product.NidProduct != Guid.Empty)
            {
                foreach (var file in _db.GetFiles(model.Product.NidProduct))
                {
                    files.Add(file);
                }
                model.SimilarProducts = _db.GetSimilarProducts(model.Product.NidProduct);
                foreach (var prd in model.SimilarProducts)
                {
                    foreach (var file in _db.GetFiles(prd.NidProduct))
                    {
                        files.Add(file);
                    }
                }
            }
            model.Files = files;
            return View(model);
        }
        public IActionResult AddComment(Comment comment) 
        {
            comment.NidComment = Guid.NewGuid();
            if(comment.UserId == Guid.Empty)
                comment.UserId = Guid.Parse("CE69B3F8-3A19-47B6-A5CC-BA09221857DA");
            comment.CreateDate = DateTime.Now;
            comment.State = 0;
            if (_db.Add<Comment>(comment))
                TempData["CommentSuccess"] = $"نظر شما با موفقیت ثبت گردید و پس از تایید مدیر سایت به بخش نظرات اضافه خواهد شد.";
            else
                TempData["CommentError"] = "خطا انجام عملیات.لطفا مجددا امتحان کنید";
            return RedirectToAction("Product",new { Title = _db.GetProductById(comment.ProductId,false).ProductName.Replace(' ', '_') });
        }
        //user section
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public IActionResult Profile()
        {
            if (Request.Cookies.ContainsKey("Stereo8Login"))
            {
                var user = _db.GetUserById(Guid.Parse(UsersAuth.GetSpecificClaim(Request.Cookies["Stereo8Login"], 2)));
                return View(user);
            }
            else
                return RedirectToAction("Login");
        }
        [AllowAnonymous]
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SubmitLogin(string Username, string Password, bool Remember) 
        {
            var user = _db.LoginWithUsername(Username, Password);
            if (user.NidUser == Guid.Empty)
            {
                TempData["LoginError"] = "نام کاربری یا کلمه عبور اشتباه است";
                return RedirectToAction("Login");
            }
            else
            {
                if (!user.IsDisabled)
                {
                    user.LastLoginDate = DateTime.Now;
                    _db.UpdateUser(user);
                    if (Request.Cookies.ContainsKey("Stereo8Login"))
                        Response.Cookies.Delete("Stereo8Login");
                    if (Request.Cookies.ContainsKey("CartCount"))
                        Response.Cookies.Delete("CartCount");
                    if (Request.Cookies.ContainsKey("FavCount"))
                        Response.Cookies.Delete("FavCount");
                    if (Remember)
                    {
                        HttpContext.Response.Cookies.Append("Stereo8Login", UsersAuth.GenerateLoginCookieValue(user, _db.GetCartCountByUserId(user.NidUser), _db.GetFavoriteCountByUserId(user.NidUser)), new CookieOptions() { Expires = DateTime.Now.AddDays(14), HttpOnly = true, Path = "/" });
                        HttpContext.Response.Cookies.Append("CartCount", _db.GetCartCountByUserId(user.NidUser).ToString(), new CookieOptions() { Expires = DateTime.Now.AddDays(14), HttpOnly = true, Path = "/" });
                        HttpContext.Response.Cookies.Append("FavCount", _db.GetFavoriteCountByUserId(user.NidUser).ToString(), new CookieOptions() { Expires = DateTime.Now.AddDays(14), HttpOnly = true, Path = "/" });
                    }
                    else
                    {
                        HttpContext.Response.Cookies.Append("Stereo8Login", UsersAuth.GenerateLoginCookieValue(user, _db.GetCartCountByUserId(user.NidUser), _db.GetFavoriteCountByUserId(user.NidUser)), new CookieOptions() { Expires = DateTime.Now.AddDays(7), HttpOnly = true, Path = "/" });
                        HttpContext.Response.Cookies.Append("CartCount", _db.GetCartCountByUserId(user.NidUser).ToString(), new CookieOptions() { Expires = DateTime.Now.AddDays(7), HttpOnly = true, Path = "/" });
                        HttpContext.Response.Cookies.Append("FavCount", _db.GetFavoriteCountByUserId(user.NidUser).ToString(), new CookieOptions() { Expires = DateTime.Now.AddDays(7), HttpOnly = true, Path = "/" });
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["LoginWarning"] = "کاربر غیرفعال می باشد";
                    return RedirectToAction("Login");
                }
            }
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (Request.Cookies.ContainsKey("Stereo8Login"))
                Response.Cookies.Delete("Stereo8Login");
            if (Request.Cookies.ContainsKey("CartCount"))
                Response.Cookies.Delete("CartCount");
            if (Request.Cookies.ContainsKey("FavCount"))
                Response.Cookies.Delete("FavCount");
            return RedirectToAction("Login");
        }
        public IActionResult Register(User user)
        {
            if(!_db.CheckUsernameExist(user.Username))
            {
                user.NidUser = Guid.NewGuid();
                user.Password = Commons.EncryptString(user.Password);
                user.CreateDate = DateTime.Now;
                user.IsAdmin = false;
                user.IsDisabled = true;
                if (_db.Add<User>(user))
                {
                    MailRequest verify = new MailRequest();
                    verify.Subject = $"فعال سازی حساب کاربری - {Commons.GetAppName()}";
                    verify.ToEmail = user.Username;
                    var mailHtml = RenderViewToString.RenderViewAsync(this, "_AccountVerificationEmail", string.Format("{0}://{1}/VerifyUserAccount?Hash={2}", Request.Scheme, Request.Host.Value, WebUtility.UrlEncode(Commons.EncryptString(user.NidUser.ToString()))));
                    verify.Body = mailHtml.Result;
                    _db.SendEmail(verify);
                    return RedirectToAction("RegisterResult", new { IsSuccessful = true });
                }
                else
                    return RedirectToAction("RegisterResult", new { IsSuccessful = false });
            }
            else
            {
                TempData["UserExistError"] = "نام کاربری وارد شده قبلا ثبت شده است.لطفا ایمیل دیگری وارد کنید";
                return RedirectToAction("Login");
            }
        }
        public IActionResult VerifyUserAccount(string Hash) 
        {
            var NidUser = Guid.Parse(Commons.DecryptString(Hash));
            var user = _db.GetUserById(NidUser,false);
            user.IsDisabled = false;
            if (_db.UpdateUser(user))
                TempData["UserActivateSuccess"] = $"کاربر با نام کاربری {user.Username} با موفقیت فعال گردید";
            else
                TempData["UserActivateError"] = "خطا در فعال کردن کاربر.لطفا مجددا امتحان کنید";
            return RedirectToAction("Login");
        }
        public IActionResult RegisterResult(bool IsSuccessful) 
        {
            return View(IsSuccessful);
        }
        public IActionResult UpdateUser(User user) 
        {
            var currentUser = _db.GetUserById(user.NidUser,false);
            if(currentUser.NidUser != Guid.Empty)
            {
                currentUser.FirstName = user.FirstName;
                currentUser.LastName = user.LastName;
                currentUser.Tel = user.Tel;
                if (_db.UpdateUser(currentUser))
                    TempData["ProfileSuccess"] = "اطلاعات کاربر با موفقیت بروزرسانی گردید";
                else
                    TempData["ProfileError"] = "خطا در بروزرسانی اطلاعات کاربر.لطفا مجدد امتحان نمایید.";
            }else
                TempData["ProfileError"] = "کاربر مورد نظر یافت نشد";
            return RedirectToAction("Profile");
        }
        public IActionResult UpdatePassword(Guid NidUser, string Password) 
        {
            var user = _db.GetUserById(NidUser,false);
            if(user.NidUser != Guid.Empty)
            {
                user.Password = Commons.EncryptString(Password);
                if (_db.UpdateUser(user))
                    return Json(new { success = true, message = "کلمه عبور با موفقیت تغییر یافت."});
                else
                    return Json(new { success = false, message = "خطا در بروزرسانی کلمه عبور.لطفا مجدد امتحان نمایید" });
            }else
                return Json(new { success = false, message = "کاربر مورد نظر یافت نشد." });
        }
        public IActionResult UpdateAddress(User user)
        {
            var currentUser = _db.GetUserById(user.NidUser, false);
            if (currentUser.NidUser != Guid.Empty)
            {
                string regex = @"\b(?!(\d)\1{3})[13-9]{4}[1346-9][013-9]{5}\b";
                if (string.IsNullOrWhiteSpace(user.ZipCode.ToString())) 
                {
                    currentUser.Address = user.Address;
                    if (_db.UpdateUser(currentUser))
                        TempData["AddressSuccess"] = "آدرس با موفقیت بروزرسانی گردید";
                    else
                        TempData["AddressError"] = "خطا در بروزرسانی آدرس.لطفا مجدد امتحان نمایید.";
                }
                else
                {
                    if (Regex.IsMatch(user.ZipCode.ToString(), regex, RegexOptions.IgnoreCase))
                    {
                        currentUser.Address = user.Address;
                        currentUser.ZipCode = user.ZipCode;
                        if (_db.UpdateUser(currentUser))
                            TempData["AddressSuccess"] = "آدرس با موفقیت بروزرسانی گردید";
                        else
                            TempData["AddressError"] = "خطا در بروزرسانی آدرس.لطفا مجدد امتحان نمایید.";
                    }
                    else
                    {
                        TempData["AddressError"] = "کد پستی وارد شده معتبر نمی باشد.";
                    }
                }
            }
            else
                TempData["AddressError"] = "کاربر مورد نظر یافت نشد";
            return RedirectToAction("Profile");
        }
        public IActionResult ForgetPassword(string Username)
        {
            var user = _db.GetUserByUsername(Username,false);
            if(user.NidUser != Guid.Empty)
            {
                MailRequest verify = new MailRequest();
                verify.Subject = $"بازیابی کلمه عبور - {Commons.GetAppName()}";
                verify.ToEmail = user.Username;
                var mailHtml = RenderViewToString.RenderViewAsync(this, "_ResetPasswordEmail", string.Format("{0}://{1}/ChangePassword?Hash={2}", Request.Scheme, Request.Host.Value, WebUtility.UrlEncode(Commons.EncryptString(user.NidUser.ToString()))));
                verify.Body = mailHtml.Result;
                _db.SendEmail(verify);
                return Json(new { success = true, message = "فرم بازیابی کلمه عبور به ایمیل شما ارسال شد.برای تغییر کلمه عبور به ایمیل خود مراجعه نمایید" });
            }
            else
            {
                return Json(new { success = false, message = "کاربری با این نام کاربری یافت نشد"});
            }
        }
        public IActionResult ChangePassword(string Hash)
        {
            var NidUser = Guid.Parse(Commons.DecryptString(Hash));
            var user = _db.GetUserById(NidUser, false);
            return View(user);
        }
        //purchase section
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public IActionResult Carts()
        {
            if (Request.Cookies.ContainsKey("Stereo8Login"))
            {
                CartViewModel model = new CartViewModel();
                model.Carts = _db.GetCartsByUserId(Guid.Parse(UsersAuth.GetSpecificClaim(Request.Cookies["Stereo8Login"],2)));
                List<Models.File> files = new List<Models.File>();
                foreach (var crt in model.Carts)
                {
                    foreach (var f in _db.GetFiles(crt.ProductId))
                    {
                        files.Add(f);
                    }
                }
                model.Files = files;
                return View(model);
            }
            else
                return RedirectToAction("Login");
        }
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public IActionResult Favorites()
        {
            if (Request.Cookies.ContainsKey("Stereo8Login"))
            {
                FavoriteViewModel model = new FavoriteViewModel();
                model.Favorites = _db.GetFavoritesByUserId(Guid.Parse(UsersAuth.GetSpecificClaim(Request.Cookies["Stereo8Login"], 2)));
                List<Models.File> files = new List<Models.File>();
                foreach (var crt in model.Favorites)
                {
                    foreach (var f in _db.GetFiles(crt.ProductId))
                    {
                        files.Add(f);
                    }
                }
                model.Files = files;
                return View(model);
            }
            else
                return RedirectToAction("Login");
        }
        public ActionResult AddProductToCart(Guid NidProduct, int Quantity, int price)//done
        {
            var niduser = Guid.Parse(UsersAuth.GetSpecificClaim(Request.Cookies["Stereo8Login"], 2));
            var products = _db.GetCartProductsByUserId(niduser);
            int cartCount = _db.GetCartCountByUserId(niduser);
            bool status = true;
            var tmpProduct = _db.GetProductById(NidProduct, false);
            if (tmpProduct != null)
            {
                if (!products.Contains(NidProduct))
                {
                    if (tmpProduct.AvailableCount >= Quantity)
                    {
                        var newCart = new Cart() { CreateDate = DateTime.Now, NidCart = Guid.NewGuid(), ProductId = NidProduct, UserId = niduser, Quantity = Quantity };
                        if (_db.Add<Cart>(newCart))
                        {
                            cartCount = _db.GetCartCountByUserId(niduser);
                        }
                        else
                            status = false;
                    }
                    else
                    {
                        var newCart = new Cart() { CreateDate = DateTime.Now, NidCart = Guid.NewGuid(), ProductId = NidProduct, UserId = niduser, Quantity = tmpProduct.AvailableCount };
                        if (_db.Add<Cart>(newCart))
                        {
                            cartCount = _db.GetCartCountByUserId(niduser);
                        }
                        else
                            status = false;
                    }
                }
                else
                {
                    var cart = _db.GetCartByProductId(niduser, NidProduct);
                    if (cart.NidCart != Guid.Empty)
                    {
                        if (tmpProduct.AvailableCount >= (cart.Quantity + Quantity))
                            cart.Quantity = cart.Quantity + Quantity;
                        cart.LastModified = DateTime.Now;
                        if (!_db.UpdateCart(cart))
                            status = false;
                    }
                    else
                        status = false;
                }
            }
            if (Request.Cookies.ContainsKey("CartCount"))
                Response.Cookies.Delete("CartCount");
            HttpContext.Response.Cookies.Append("CartCount", cartCount.ToString(), new CookieOptions() { Expires = DateTime.Now.AddDays(14), HttpOnly = true, Path = "/" });
            if (status)
                return Json(new { success = true, count = cartCount });
            else
                return Json(new { success = false, message = "خطایی رخ داده است.لطفا مجددا امتحان کنید" });
        }
        public ActionResult RemoveProductFromCart(Guid NidCart)//done
        {
            var niduser = Guid.Parse(UsersAuth.GetSpecificClaim(Request.Cookies["Stereo8Login"], 2));
            if (_db.Remove<Cart>(_db.GetCartById(NidCart)))
            {
                int cartCount = _db.GetCartCountByUserId(niduser);
                if (Request.Cookies.ContainsKey("CartCount"))
                    Response.Cookies.Delete("CartCount");
                HttpContext.Response.Cookies.Append("CartCount", cartCount.ToString(), new CookieOptions() { Expires = DateTime.Now.AddDays(14), HttpOnly = true, Path = "/" });
                decimal aggregate = _db.GetCartAggregateByUserId(niduser);
                return Json(new { success = true, count = cartCount, aggregate = aggregate });
            }
            else
                return Json(new { success = false });
        }
        public ActionResult CartQuantityChanged(Guid NidCart, int Quantity)//done
        {
            var niduser = Guid.Parse(UsersAuth.GetSpecificClaim(Request.Cookies["Stereo8Login"], 2));
            var tmpCart = _db.GetCartById(NidCart);
            if(tmpCart.NidCart != Guid.Empty)
            {
                tmpCart.LastModified = DateTime.Now;
                tmpCart.Quantity = Quantity;
                if (_db.UpdateCart(tmpCart))
                {
                    int cartCount = _db.GetCartCountByUserId(niduser);
                    decimal aggregate = _db.GetCartAggregateByUserId(niduser);
                    return Json(new { success = true, count = cartCount, aggregate = aggregate });
                }
                else
                    return Json(new { success = false });
            }
            else
                return Json(new { success = false });

        }
        public ActionResult AddProductToFavorites(Guid NidProduct)//done
        {
            var niduser = Guid.Parse(UsersAuth.GetSpecificClaim(Request.Cookies["Stereo8Login"], 2));
            var products = _db.GetFavoriteProductsByUserId(niduser);
            int favCount = _db.GetFavoriteCountByUserId(niduser);
            if (!products.Contains(NidProduct))
            {
                var newFav = new Favorite() { CreateDate = DateTime.Now, NidFav = Guid.NewGuid(), ProductId = NidProduct, UserId = niduser };
                if (_db.Add<Favorite>(newFav))
                {
                    favCount = _db.GetFavoriteCountByUserId(niduser);
                    if (Request.Cookies.ContainsKey("FavCount"))
                        Response.Cookies.Delete("FavCount");
                    HttpContext.Response.Cookies.Append("FavCount", favCount.ToString(), new CookieOptions() { Expires = DateTime.Now.AddDays(14), HttpOnly = true, Path = "/" });
                    return Json(new { success = true, count = favCount });
                }
                else
                    return Json(new { success = false });
            }
            else
                return Json(new { success = true, count = favCount });
        }
        public ActionResult RemoveProductFromFav(Guid NidFav)//done
        {
            var niduser = Guid.Parse(UsersAuth.GetSpecificClaim(Request.Cookies["Stereo8Login"], 2));
            if (_db.Remove<Favorite>(_db.GetFavoriteById(NidFav)))
            {
                int favCount = _db.GetFavoriteCountByUserId(niduser);
                if (Request.Cookies.ContainsKey("FavCount"))
                    Response.Cookies.Delete("FavCount");
                HttpContext.Response.Cookies.Append("FavCount", favCount.ToString(), new CookieOptions() { Expires = DateTime.Now.AddDays(14), HttpOnly = true, Path = "/" });
                return Json(new { success = true, count = favCount });
            }
            else
                return Json(new { success = false });
        }
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public IActionResult Checkout()
        {
            if (Request.Cookies.ContainsKey("Stereo8Login"))
            {
                CheckoutViewModel model = new CheckoutViewModel();
                var Niduser = Guid.Parse(UsersAuth.GetSpecificClaim(Request.Cookies["Stereo8Login"], 2));
                model.User = _db.GetUserById(Niduser);
                model.Carts = _db.GetCartsByUserId(Niduser);
                model.Order = _db.GetOrderByUserId(Niduser);
                model.ShipPrices = _db.GetShipPrices();
                return View(model);
            }
            else
                return RedirectToAction("Login");
        }
        public ActionResult GetShipFee(int StateId,decimal TotalWeight, decimal CurrentAggregate)//done
        {
            bool status = true;
            var shipPrices = _db.GetShipPrices();
            decimal shipPriceCal = 0;
            if(StateId != 0)
            {
                if (StateId == 1)
                    shipPriceCal = shipPrices.FirstOrDefault(p => p.ToWeight == Math.Ceiling(TotalWeight)).InnerState;
                else if (StateId == 9 || StateId == 10 || StateId == 11 || StateId == 13 || StateId == 31)
                    shipPriceCal = shipPrices.FirstOrDefault(p => p.ToWeight == Math.Ceiling(TotalWeight)).NeighborState;
                else
                    shipPriceCal = shipPrices.FirstOrDefault(p => p.ToWeight == Math.Ceiling(TotalWeight)).OtherState;
            }
            if (status)
                return Json(new { success = true, shipprice = string.Format("{0:n0} تومان", shipPriceCal), newaggregate = string.Format("{0:n0} تومان", CurrentAggregate + shipPriceCal) });
            else
                return Json(new { success = false, message = "خطایی رخ داده است.لطفا مجددا امتحان کنید" });
        }
        public IActionResult CheckoutSubmit(Order order) 
        {
            var Niduser = Guid.Parse(UsersAuth.GetSpecificClaim(Request.Cookies["Stereo8Login"], 2));
            bool status = true;
            var carts = _db.GetCartsByUserId(Niduser, true);
            var total = _db.GetCartAggregateByUserId(Niduser);
            var shipPrices = _db.GetShipPrices();
            decimal shipPriceCal = 0;
            decimal TotalWeight = decimal.Parse(carts.Sum(p => p.Product.Weight).ToString());
            if (order.StateId != 0)
            {
                if (order.StateId == 1)
                    shipPriceCal = shipPrices.FirstOrDefault(p => p.ToWeight == Math.Ceiling(TotalWeight)).InnerState;
                else if (order.StateId == 9 || order.StateId == 10 || order.StateId == 11 || order.StateId == 13 || order.StateId == 31)
                    shipPriceCal = shipPrices.FirstOrDefault(p => p.ToWeight == Math.Ceiling(TotalWeight)).NeighborState;
                else
                    shipPriceCal = shipPrices.FirstOrDefault(p => p.ToWeight == Math.Ceiling(TotalWeight)).OtherState;
            }
            if (order.NidOrder == Guid.Empty)
            {
                order.CreateDate = DateTime.Now;
                order.NidOrder = Guid.NewGuid();
                order.UserId = Niduser;
                order.State = 0;
                order.TotalPrice = total + shipPriceCal;
                if (_db.Add<Order>(order))
                {
                    foreach (var cart in carts)
                    {
                        if (!_db.Add<OrderDetail>(new OrderDetail() { NidDetail = Guid.NewGuid(), CreateDate = DateTime.Now, OrderId = order.NidOrder, ProductId = cart.ProductId, Quantity = cart.Quantity }))
                            status = false;
                    }
                }
                else
                    status = false;
                if (!_db.Add<Ship>(new Ship() { NidShip = Guid.NewGuid(), OrderId = order.NidOrder, CreateDate = DateTime.Now, Address = order.Address, ShipPrice = shipPriceCal, State = 0, ZipCode = order.ZipCode ?? 1111111111, ShipVia = 0 }))
                    status = false;
                if (status)
                    return Json(new { success = true, redirect = string.Format("{0}://{1}/Payment?NidOrder={2}", Request.Scheme, Request.Host.Value, order.NidOrder) });
                else
                    return Json(new { success = false, message = "خطا در سرور لطفا مجددا امتحان کنید" });
            }
            else
            {
                var currentOrder = _db.GetOrderById(order.NidOrder, false);
                currentOrder.Address = order.Address;
                currentOrder.Email = order.Email;
                currentOrder.CityId = order.CityId;
                currentOrder.StateId = order.StateId;
                currentOrder.Description = order.Description;
                currentOrder.FirstName = order.FirstName;
                currentOrder.LastModified = DateTime.Now;
                currentOrder.LastName = order.LastName;
                currentOrder.Tel = order.Tel;
                currentOrder.ZipCode = order.ZipCode;
                currentOrder.TotalPrice = _db.GetCartAggregateByUserId(Niduser) + shipPriceCal;
                if (_db.UpdateOrder(currentOrder))
                {
                    foreach (var ordd in _db.GetOrderDetailsByOrderId(order.NidOrder))
                    {
                        if (!_db.Remove<OrderDetail>(ordd))
                            status = false;
                    }
                    foreach (var cart in carts)
                    {
                        if (!_db.Add<OrderDetail>(new OrderDetail() { NidDetail = Guid.NewGuid(), CreateDate = DateTime.Now, OrderId = order.NidOrder, ProductId = cart.ProductId, Quantity = cart.Quantity }))
                            status = false;
                    }
                    var tmpShip = _db.GetShipByOrderId(order.NidOrder, false);
                    if (tmpShip.NidShip == Guid.Empty)
                    {
                        if (!_db.Add<Ship>(new Ship() { NidShip = Guid.NewGuid(), OrderId = order.NidOrder, CreateDate = DateTime.Now, Address = order.Address, ShipPrice = shipPriceCal, State = 0, ZipCode = order.ZipCode ?? 1111111111, ShipVia = 0 }))
                            status = false;
                    }
                    else
                    {
                        tmpShip.Address = order.Address;
                        tmpShip.ZipCode = order.ZipCode ?? 1111111111;
                        tmpShip.CreateDate = DateTime.Now;
                        if (!_db.UpdateShip(tmpShip))
                            status = false;
                    }
                }
                else
                    status = false;
                if (status)
                    return Json(new { success = true, redirect = string.Format("{0}://{1}/Payment?NidOrder={2}", Request.Scheme, Request.Host.Value, currentOrder.NidOrder) });
                else
                    return Json(new { success = false, message = "خطا در سرور لطفا مجددا امتحان کنید" });
            }
        }
        public async Task<ActionResult> Payment(Guid NidOrder)
        {
            var tmporder = _db.GetOrderById(NidOrder);
            try
            {
                using (var client = new HttpClient())
                {
                    string authority;
                    RequestParameters parameters = new RequestParameters("YOUR_MERCHANT_ID", (tmporder.TotalPrice*10).ToString(), "خرید از وب سایت استریو 8", "http://stereo8.ir/Verify?NidOrder=" + NidOrder, tmporder.Tel ?? "", tmporder.Email ?? "");

                    var json = JsonConvert.SerializeObject(parameters);

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("https://api.zarinpal.com/pg/v4/payment/request.json", content);

                    string responseBody = await response.Content.ReadAsStringAsync();

                    JObject jo = JObject.Parse(responseBody);
                    string errorscode = jo["errors"].ToString();

                    JObject jodata = JObject.Parse(responseBody);
                    string dataauth = jodata["data"].ToString();


                    if (dataauth != "[]")
                    {
                        authority = jodata["data"]["authority"].ToString();

                        string gatewayUrl = "https://www.zarinpal.com/pg/StartPay/" + authority;

                        return Redirect(gatewayUrl);

                    }
                    else
                    {
                        TempData["dargahRedirectError"] = "در انتقال به درگاه خطایی رخ داده است.لطفا مجدد امتحان کنید";
                        return RedirectToAction("Checkout", "Home");
                    }
                }
            }

            catch (Exception ex)
            {
                TempData["dargahRedirectError"] = "در انتقال به درگاه خطایی رخ داده است.لطفا مجدد امتحان کنید";
                return RedirectToAction("Checkout", "Home");
            }
        }
        public async Task<ActionResult> Verify(Guid NidOrder)
        {
            Order tmpOrder = _db.GetOrderById(NidOrder);
            var Niduser = Guid.Parse(UsersAuth.GetSpecificClaim(Request.Cookies["Stereo8Login"], 2));
            List<Cart> carts = _db.GetCartsByUserId(Niduser).ToList();
            try
            {
                string authority = "";
                VerifyParameters parameters = new VerifyParameters();
                if (HttpContext.Request.Query["Authority"] != "")
                {
                    authority = HttpContext.Request.Query["Authority"];
                }

                parameters.authority = authority;

                parameters.amount = (tmpOrder.TotalPrice*10).ToString();

                parameters.merchant_id = "YOUR_MERCHANT_ID";


                using (HttpClient client = new HttpClient())
                {

                    var json = JsonConvert.SerializeObject(parameters);

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("https://api.zarinpal.com/pg/v4/payment/verify.json", content);

                    string responseBody = await response.Content.ReadAsStringAsync();

                    JObject jodata = JObject.Parse(responseBody);

                    string data = jodata["data"].ToString();

                    JObject jo = JObject.Parse(responseBody);

                    string errors = jo["errors"].ToString();

                    if (data != "[]")
                    {
                        string refid = jodata["data"]["ref_id"].ToString();

                        tmpOrder.RefId = long.Parse(refid);
                        tmpOrder.State = byte.Parse(jodata["data"]["code"].ToString());
                        if (_db.UpdateOrder(tmpOrder))
                        {
                            foreach (var cart in carts)
                            {
                                _db.UpdateAvailableCount(cart.ProductId,cart.Quantity);
                                _db.Remove<Cart>(cart);
                            }
                            int cartCount = _db.GetCartCountByUserId(Niduser);
                            if (Request.Cookies.ContainsKey("CartCount"))
                                Response.Cookies.Delete("CartCount");
                            HttpContext.Response.Cookies.Append("CartCount", cartCount.ToString(), new CookieOptions() { Expires = DateTime.Now.AddDays(14), HttpOnly = true, Path = "/" });
                            var tmpship = _db.GetShipByOrderId(tmpOrder.NidOrder);
                            tmpship.State = 1;//paid
                            _db.UpdateShip(tmpship);
                        }
                    }
                    else if (errors != "[]")
                    {

                        string errorscode = jo["errors"]["code"].ToString();
                        tmpOrder.State = int.Parse(errorscode);
                        _db.UpdateOrder(tmpOrder);
                    }
                }
            }
            catch (Exception ex)
            {
                tmpOrder.State = 102;//exception occured
                _db.UpdateOrder(tmpOrder);
            }
            return View(new CheckoutViewModel() { OrderDetails = _db.GetOrderDetailsByOrderId(tmpOrder.NidOrder), Order = tmpOrder });
        }
        //general section
        public IActionResult Search(string Text)
        {
            var res = _db.SearchProduct(Text);
            if (res.ToList().Count != 0)
            {
                return Json(new { success = true, html = RenderViewToString.RenderViewAsync(this, "_SearchResult", res,true) });
            }
            else
            {
                return Json(new { success = false });
            }
        }
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public IActionResult AboutUs()
        {
            List<Models.File> files = new List<Models.File>();
            foreach (var f in _db.GetCommonFiles(25, 28))
            {
                files.Add(f);
            }
            return View(files);
        }
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public IActionResult ContactUs()
        {
            return View();
        }
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public IActionResult Categories()
        {
            CategoriesViewModel model = new CategoriesViewModel();
            model.Categories = _db.GetCategoriesProductIncluded();
            List<Models.File> files = new List<Models.File>();
            foreach (var cat in model.Categories)
            {
                foreach (var p in cat.Products)
                {
                    foreach (var f in _db.GetFiles(p.NidProduct))
                    {
                        files.Add(f);
                    }
                }
            }
            model.Files = files;
            return View(model);
        }
        public ActionResult AddToNewsletter(string Mail)
        {
            Setting setting = new Setting() { NidSetting = Guid.NewGuid(), SettingAttribute = "NewsletterMail", SettingValue = Mail };
            return Json(new { success = _db.Add<Setting>(setting) });
        }
        public ActionResult AddContactForm(ContactForm form) 
        {
            Setting setting = new Setting() { NidSetting = Guid.NewGuid(), SettingAttribute = "ContactForm", SettingValue = string.Format("{0},{1},{2},{3}",form.name,form.subject,form.email,form.message) };
            if (_db.Add<Setting>(setting))
                TempData["ContactSuccess"] = "دیدگاه شما با موفقیت ثبت گردید.از این که نظرات خود را با ما به اشتراک می گذارید متشکریم.";
            else
                TempData["ContactError"] = "خطایی رخ داده است.لطفا مجددا امتحان کنید";
            return RedirectToAction("ContactUs");
        }
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public IActionResult Bargain()
        {
            CategoryViewModel model = new CategoryViewModel();
            List<Models.File> Files = new List<Models.File>();
            var tmpProducts = _db.GetBargainedProducts();
            model.Products = tmpProducts.Item1;
            model.ProductCount = tmpProducts.Item2;
            foreach (var prd in model.Products)
            {
                foreach (var f in _db.GetFiles(prd.NidProduct))
                {
                    Files.Add(f);
                }
            }
            foreach (var f in _db.GetCommonFiles(23, 24))
            {
                Files.Add(f);
            }
            model.Files = Files;
            return View(model);
        }
        public IActionResult BargainPagination(int PageNumber)
        {
            CategoryViewModel model = new CategoryViewModel();
            List<Models.File> Files = new List<Models.File>();
            var tmpProduct = _db.GetBargainedProducts(10, PageNumber - 1);
            model.Products = tmpProduct.Item1;
            model.ProductCount = tmpProduct.Item2;
            model.PageNumber = PageNumber;
            foreach (var prd in model.Products)
            {
                foreach (var f in _db.GetFiles(prd.NidProduct))
                {
                    Files.Add(f);
                }
            }
            model.Files = Files;
            return Json(new { success = true, html = RenderViewToString.RenderViewAsync(this, "_BargainPagination", model, true), countMessage = $"تعداد محصولات : {model.ProductCount}" });
        }
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public IActionResult Delivery()
        {
            List<Models.File> files = new List<Models.File>();
            foreach (var f in _db.GetCommonFiles(28,29))
            {
                files.Add(f);
            }
            return View(files);
        }
        public IActionResult StatusCodes(int status) 
        {
            return View("HttpError",status);
        }
        //blog section
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public IActionResult Blog() 
        {
            BlogViewModel model = new BlogViewModel();
            model.BlogCategories = _db.GetBlogCategories(false);
            model.LatestBlog = _db.GetLatestBlogs(false,4,0);
            List<Models.File> files = new List<Models.File>();
            foreach (var prd in model.LatestBlog)
            {
                foreach (var f in _db.GetFiles(prd.NidBlog))
                {
                    files.Add(f);
                }
            }
            model.Keywords = _db.GetBlogKeywords();
            model.Posts = _db.GetBlogs();
            foreach (var prd in model.Posts)
            {
                foreach (var f in _db.GetFiles(prd.NidBlog))
                {
                    files.Add(f);
                }
            }
            model.PageNumber = 1;
            model.PostCount = _db.GetBlogCount();
            model.Files = files;
            return View(model);
        }
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public IActionResult BlogPost(byte BlogType,string Title)
        {
            BlogViewModel model = new BlogViewModel();
            model.BlogCategories = _db.GetBlogCategories(false);
            model.LatestBlog = _db.GetLatestBlogs(false, 4, 0);
            model.Keywords = _db.GetBlogKeywords();
            model.Posts = _db.GetFilterBlog(BlogType,Title.Replace('_',' '));
            List<Models.File> files = new List<Models.File>();
            foreach (var prd in model.LatestBlog)
            {
                foreach (var f in _db.GetFiles(prd.NidBlog))
                {
                    files.Add(f);
                }
            }
            foreach (var prd in model.Posts)
            {
                foreach (var f in _db.GetFiles(prd.NidBlog))
                {
                    files.Add(f);
                }
            }
            model.Files = files;
            model.PostCount = _db.GetBlogPostCount(BlogType, Title);
            model.FilterTitle = Title;
            model.FilterType = BlogType;
            model.PageNumber = 1;
            switch (BlogType)
            {
                case 1:
                    model.FilterName = $"مقالات مربوط به دسته بندی {Title}";
                    break;
                case 2:
                    model.FilterName = $"مقالات مربوط به کلیدواژه {Title}";
                    break;
                case 3:
                    model.FilterName = $"مقالات مربوط به عبارت جستجو شده :  {Title}";
                    break;
                default:
                    break;
            }
            model.PageUrl = String.Format("http://stereo8.ir/BlogPost?BlogType={0}&Title={1}",BlogType,Title);
            return View(model);
        }
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public IActionResult BlogDetail(string Title)
        {
            BlogDetailViewModel model = new BlogDetailViewModel();
            model.Blog = _db.GetBlog(Title.Replace('_',' '));
            model.RelatedBlogs = _db.GetRelatedBlogs(0,true,3);
            model.BlogCategories = _db.GetBlogCategories(false);
            model.LatestBlog = _db.GetLatestBlogs(false, 4, 0);
            model.Keywords = _db.GetBlogKeywords();
            List<Models.File> files = new List<Models.File>();
            foreach (var prd in model.LatestBlog.ToList())
            {
                foreach (var f in _db.GetFiles(prd.NidBlog))
                {
                    files.Add(f);
                }
            }
            foreach (var f in _db.GetFiles(model.Blog.NidBlog))
            {
                files.Add(f);
            }
            model.Files = files;
            return View(model);
        }
        public IActionResult AddBlogComment(BlogComment comment)
        {
            comment.NidComment = Guid.NewGuid();
            if (comment.UserId == Guid.Empty)
                comment.UserId = Guid.Parse("CE69B3F8-3A19-47B6-A5CC-BA09221857DA");
            comment.CreateDate = DateTime.Now;
            comment.State = 0;
            if(_db.Add<BlogComment>(comment))
                TempData["BlogCommentSuccess"] = $"نظر شما با موفقیت ثبت گردید و پس از تایید مدیر سایت به بخش نظرات اضافه خواهد شد.";
            else
                TempData["BlogCommentError"] = "خطا انجام عملیات.لطفا مجددا امتحان کنید";
            return RedirectToAction("BlogDetail", new { Title = _db.GetBlogById(comment.BlogId, false).Title.Replace(' ','_') });
        }
        public async Task<IActionResult> BlogPagination(int PageNumber)
        {
            BlogViewModel model = new BlogViewModel();
            List<Models.File> files = new List<Models.File>();
            model.Posts = _db.GetBlogs(0,true,10,PageNumber - 1);
            foreach (var prd in model.Posts)
            {
                foreach (var f in _db.GetFiles(prd.NidBlog))
                {
                    files.Add(f);
                }
            }
            model.Files = files;
            string html1 = await RenderViewToString.RenderViewAsync(this, "_BlogPagination", model, true);
            string html2 = await RenderViewToString.RenderViewAsync(this, "_BlogPagination2", new int[2] { PageNumber,_db.GetBlogCount()}, true);
            return Json(new { success = true, html = html1, html2 = html2});
        }
        public async Task<IActionResult> BlogPostPagination(byte BlogType, string Title,int PageNumber)
        {
            BlogViewModel model = new BlogViewModel();
            model.Posts = _db.GetFilterBlog(BlogType, Title.Replace('_', ' '),0,true,10,PageNumber - 1);
            List<Models.File> files = new List<Models.File>();
            foreach (var prd in model.Posts)
            {
                foreach (var f in _db.GetFiles(prd.NidBlog))
                {
                    files.Add(f);
                }
            }
            model.Files = files;
            switch (BlogType)
            {
                case 1:
                    model.FilterName = $"مقالات مربوط به دسته بندی {Title}";
                    break;
                case 2:
                    model.FilterName = $"مقالات مربوط به کلیدواژه {Title}";
                    break;
                case 3:
                    model.FilterName = $"مقالات مربوط به عبارت جستجو شده :  {Title}";
                    break;
                default:
                    break;
            }
            string html1 = await RenderViewToString.RenderViewAsync(this, "_BlogPostPagination", model, true);
            string html2 = await RenderViewToString.RenderViewAsync(this, "_BlogPostPagination2", new int[2] { PageNumber, _db.GetBlogPostCount(BlogType,Title) }, true);
            return Json(new { success = true, html = html1, html2 = html2 });
        }
    }
}