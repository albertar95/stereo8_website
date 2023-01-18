using AudioShopBackend.Models;
using AudioShopBackend.Services.Contracts;
using AudioShopBackend.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Claims;
using System.Drawing.Drawing2D;
using AudioShopBackend.Helpers;

namespace AudioShopBackend.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserAction _userAction;
        private readonly IProductAction _productAction;
        private readonly ICategoryAction _categoryAction;
        private readonly ICommonAction _commonAction;
        private readonly IBlogAction _blogAction;
        private readonly IReplicationAction _replicationAction;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public HomeController(IUserAction userAction,IProductAction productAction,ICategoryAction categoryAction, ICommonAction commonAction, IBlogAction blogAction, IReplicationAction replicationAction, IWebHostEnvironment environment) 
        { 
            _userAction = userAction;
            _productAction = productAction;
            _categoryAction = categoryAction;
            _commonAction = commonAction;
            _blogAction = blogAction;
            _replicationAction = replicationAction;
            _hostingEnvironment = environment;
        }
        //user section
        public IActionResult Users()
        {
            UsersViewModel viewModel = new UsersViewModel();
            viewModel.AdminUsers = _userAction.GetUsers();
            viewModel.RegularUsers = _userAction.GetUsers(true,false);
            return View(viewModel);
        }
        public IActionResult AddUser() 
        {
            return View();
        }
        public IActionResult SubmitAddUser(User user) 
        {
            user.Password = Helpers.Commons.EncryptString(user.Password);
            user.IsAdmin = true;
            user.CreateDate = DateTime.Now;
            user.NidUser = Guid.NewGuid();
            if (_userAction.Add<User>(user))
                TempData["UserSuccess"] = $"کاربر با موفقیت ایجاد گردید";
            else
                TempData["UserError"] = "خطا در ایجاد کاربر.لطفا مجددا امتحان کنید";
            return RedirectToAction("Users");
        }
        public IActionResult EditUser(Guid nidUser)
        {
            var User = _userAction.GetUser(nidUser);
            return View(User);
        }
        public IActionResult SubmitEditUser(User user)
        {
            if (_userAction.UpdateUser(user))
                TempData["UserSuccess"] = "کاربر با موفقیت ویرایش گردید";
            else
                TempData["UserError"] = "خطا در ویرایش کاربر.لطفا مجددا امتحان کنید";
            return RedirectToAction("Users");
        }
        public IActionResult UserDetail(Guid nidUser)
        {
            var User = _userAction.GetUser(nidUser);
            return View(User);
        }
        public IActionResult DeleteUser(Guid nidUser) 
        {
            var User = _userAction.GetUser(nidUser);
            if(User.NidUser != Guid.Empty)
            {
                _userAction.Remove<User>(User);
                TempData["UserSuccess"] = "کاربر با موفقیت حذف گردید";
            }
            else
                TempData["UserError"] = "خطا در حذف کاربر.لطفا مجددا امتحان کنید";
            return RedirectToAction("Users");
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> SubmitLogin(string Username, string Password)
        {
            var user = _userAction.LoginWithUsername(Username, Password);
            if(user.NidUser == Guid.Empty)
            {
                TempData["LoginError"] = "نام کاربری یا کلمه عبور اشتباه است";
                return RedirectToAction("Login");
            }
            else
            {
                if(!user.IsDisabled)
                {
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim("Username",user.Username),
                        new Claim("NidUser",user.NidUser.ToString()),
                        new Claim("Role", "Admin"),
                     };
                    var claimsIdentity = new ClaimsIdentity(
        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties { IsPersistent = true };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
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
            return RedirectToAction("Login");
        }
        //category section
        public IActionResult Categories()
        {
            var Categories = _categoryAction.GetCategories();
            return View(Categories);
        }
        public IActionResult AddCategory(Category category) 
        {
            category.NidCategory = Guid.NewGuid();
            category.CreateDate = DateTime.Now;
            category.State = 0;
            if (_categoryAction.Add<Category>(category))
                TempData["CategorySuccess"] = "دسته بندی با موفقیت ایجاد گردید";
            else
                TempData["CategoryError"] = "خطا در ایجاد دسته بندی.لطفا مجددا امتحان کنید";
            return RedirectToAction("Categories");
        }
        public IActionResult Category(Guid NidCategory)
        {
            var category = _categoryAction.GetCategory(NidCategory);
            return View(category);
        }
        public IActionResult EditType(Guid NidType)
        {
            var type = _categoryAction.GetType(NidType);
            return View(type);
        }
        public IActionResult EditBrand(Guid NidBrand)
        {
            var brand = _categoryAction.GetBrand(NidBrand);
            return View(brand);
        }
        public IActionResult EditCategory(Category category)
        {
            category.LastModified = DateTime.Now;
            if (_categoryAction.UpdateCategory(category))
                TempData["CategoryPageSuccess"] = "دسته بندی با موفقیت ویرایش گردید";
            else
                TempData["CategoryPageError"] = "خطا در ویرایش دسته بندی.لطفا مجددا امتحان کنید";
            return RedirectToAction("Category",new { NidCategory = category.NidCategory});
        }
        public IActionResult DeleteCategory(Guid NidCategory)
        {
            var category = _categoryAction.GetCategory(NidCategory, false, false, false);
            category.State = 2;
            category.LastModified = DateTime.Now;
            if (_categoryAction.UpdateCategory(category))
                TempData["CategorySuccess"] = "دسته بندی با موفقیت حذف گردید";
            else
                TempData["CategoryError"] = "خطا در حذف دسته بندی.لطفا مجددا امتحان کنید";
            return RedirectToAction("Categories");
        }
        public IActionResult CloseCategory(Guid NidCategory)
        {
            var category = _categoryAction.GetCategory(NidCategory, false, false, false);
            category.State = 1;
            category.LastModified = DateTime.Now;
            if (_categoryAction.UpdateCategory(category))
                TempData["CategorySuccess"] = "دسته بندی با موفقیت غیرفعال گردید";
            else
                TempData["CategoryError"] = "خطا در غیرفعال کردن دسته بندی.لطفا مجددا امتحان کنید";
            return RedirectToAction("Categories");
        }
        public IActionResult AddType(Models.Type type)
        {
            type.NidType = Guid.NewGuid();
            type.State = 0;
            type.CreateDate = DateTime.Now;
            if(_categoryAction.Add<Models.Type>(type))
                TempData["CategoryPageSuccess"] = "نوع با موفقیت ایجاد گردید";
            else
                TempData["CategoryPageError"] = "خطا در ایجاد نوع.لطفا مجددا امتحان کنید";
            return RedirectToAction("Category", new { NidCategory = type.CategoryId });
        }
        public IActionResult AddBrand(Brand brand)
        {
            brand.NidBrand = Guid.NewGuid();
            brand.State = 0;
            brand.CreateDate = DateTime.Now;
            if (_categoryAction.Add<Brand>(brand))
                TempData["CategoryPageSuccess"] = "برند با موفقیت ایجاد گردید";
            else
                TempData["CategoryPageError"] = "خطا در ایجاد برند.لطفا مجددا امتحان کنید";
            return RedirectToAction("Category", new { NidCategory = brand.CategoryId });
        }
        public IActionResult DeleteType(Guid NidType)
        {
            var type = _categoryAction.GetType(NidType);
            type.State = 2;
            type.LastModified = DateTime.Now;
            if (_categoryAction.UpdateType(type))
                TempData["CategoryPageSuccess"] = "نوع با موفقیت حذف گردید";
            else
                TempData["CategoryPageError"] = "خطا در حذف نوع.لطفا مجددا امتحان کنید";
            return RedirectToAction("Category", new { NidCategory = type.CategoryId });
        }
        public IActionResult SubmitEditType(Models.Type type)
        {
            type.LastModified = DateTime.Now;
            if (_categoryAction.UpdateType(type))
                TempData["CategoryPageSuccess"] = "نوع با موفقیت ویرایش گردید";
            else
                TempData["CategoryPageError"] = "خطا در ویرایش نوع.لطفا مجددا امتحان کنید";
            return RedirectToAction("Category", new { NidCategory = type.CategoryId });
        }
        public IActionResult DeleteBrand(Guid NidBrand)
        {
            var brand = _categoryAction.GetBrand(NidBrand);
            brand.State = 2;
            brand.LastModified = DateTime.Now;
            if (_categoryAction.UpdateBrand(brand))
                TempData["CategoryPageSuccess"] = "برند با موفقیت حذف گردید";
            else
                TempData["CategoryPageError"] = "خطا در حذف برند.لطفا مجددا امتحان کنید";
            return RedirectToAction("Category", new { NidCategory = brand.CategoryId });
        }
        public IActionResult SubmitEditBrand(Brand brand)
        {
            brand.LastModified = DateTime.Now;
            if (_categoryAction.UpdateBrand(brand))
                TempData["CategoryPageSuccess"] = "برند با موفقیت ویرایش گردید";
            else
                TempData["CategoryPageError"] = "خطا در ویرایش برند.لطفا مجددا امتحان کنید";
            return RedirectToAction("Category", new { NidCategory = brand.CategoryId });
        }
        //product section
        public IActionResult Products()
        {
            ProductViewModel model = new ProductViewModel();
            model.Products = _productAction.GetProducts();
            model.Categories = _categoryAction.GetCategories();
            return View(model);
        }
        public IActionResult AddProduct()
        {
            ProductViewModel model = new ProductViewModel();
            model.Categories = _categoryAction.GetCategories(true,true,false);
            return View(model);
        }
        public IActionResult SubmitAddProduct(Product product)
        {
            product.CreateDate = DateTime.Now;
            product.NidProduct = Guid.NewGuid();
            product.State = 0;
            product.UserId = Guid.Parse(User.Claims.FirstOrDefault(p => p.Type == "NidUser").Value);
            if(_productAction.Add<Product>(product))
                TempData["ProductSuccess"] = "محصول با موفقیت ایجاد گردید";
            else
                TempData["ProductError"] = "خطا در ایجاد محصول.لطفا مجددا امتحان کنید";
            return RedirectToAction("Products");
        }
        public IActionResult EditProduct(Guid NidProduct)
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Product = _productAction.GetProduct(NidProduct);
            productViewModel.Categories = _categoryAction.GetCategories(true,true,false);
            productViewModel.Files = _commonAction.GetFiles(NidProduct);
            return View(productViewModel);
        }
        public IActionResult SubmitEditProduct(Product product)
        {
            product.LastModified = DateTime.Now;
            if (_productAction.UpdateProduct(product))
                TempData["ProductSuccess"] = "محصول با موفقیت ویرایش گردید";
            else
                TempData["ProductError"] = "خطا در ویرایش محصول.لطفا مجددا امتحان کنید";
            return RedirectToAction("Products");
        }
        public IActionResult ProductDetail(Guid NidProduct)
        {
            var product = _productAction.GetProduct(NidProduct,true);
            if (product.NidProduct != Guid.Empty)
                return Json(new { success = true, html = Helpers.RenderViewToString.RenderViewAsync(this, "_ProductDetail", product,true) });
            else
                return Json(new { success = false});
        }
        public IActionResult DeleteProduct(Guid NidProduct)
        {
            var product = _productAction.GetProduct(NidProduct);
            if(product.NidProduct != Guid.Empty)
            {
                product.State = 2;
                product.LastModified = DateTime.Now;
                if (_productAction.UpdateProduct(product))
                    return Json(new { success = true, message = "محصول با موفقیت حذف گردید"});
                else
                    return Json(new { success = false, message = "خطا در حذف محصول.لطفا مجددا امتحان کنید" });
            }
            else
            {
                return Json(new { success = false, message = "محصول مورد نظر یافت نشد" });
            }
        }
        public IActionResult ProductFilter(int Index,string FilterText) 
        {
            List<Product> products = new List<Product>();
            bool success = true;
            switch (Index)
            {
                case 1:
                    products = _productAction.GetProductsByCategory(Guid.Parse(FilterText.Split(',')[0]), Guid.Parse(FilterText.Split(',')[1]), Guid.Parse(FilterText.Split(',')[2])).ToList();
                    break;
                case 2:
                    products = _productAction.GetProductsByCreateDate(DateTime.Parse(FilterText.Split(',')[0]).Date, DateTime.Parse(FilterText.Split(',')[1]).Date).ToList();
                    break;
                case 3:
                    products = _productAction.GetProductsByPriceRange(decimal.Parse(FilterText.Split(',')[0]),decimal.Parse(FilterText.Split(',')[1])).ToList();
                    break;
                case 4:
                    products = _productAction.GetProductsByAvailablity(int.Parse(FilterText)).ToList();
                    break;
            }
            return Json(new {success = success, html = RenderViewToString.RenderViewAsync(this,"_FilteredProduct",products,true)});
        }
        public IActionResult Orders()
        {
            var orders = _productAction.GetOrders();
            return View(orders);
        }
        public IActionResult ClosedOrders()
        {
            var orders = _productAction.GetOrders(1);
            return View(orders);
        }
        public IActionResult OrderDetail(Guid NidOrder)
        {
            var order = _productAction.GetOrder(NidOrder);
            return View(order);
        }
        public IActionResult Ships(byte state = 1)
        {
            var ships = _productAction.GetShips(state);
            return View(new Tuple<IEnumerable<Ship>,byte>(ships,state));
        }
        public IActionResult UpdateShip(Guid NidShip,byte State) 
        {
            var ship = _productAction.GetShip(NidShip);
            ship.State = State;
            if(_productAction.UpdateShip(ship))
            return Json(new { success = true, message = "مرسوله با موفقیت بروزرسانی شد"});
            else
                return Json(new { success = false, message = "خطا در بروزرسانی مرسوله.لطفا مجددا امتحان کنید" });
        }
        public IActionResult Comments()
        {
            var comments = _productAction.GetComments();
            return View(comments);
        }
        public IActionResult DeleteComment(Guid nidComment) 
        {
            var comment = _productAction.GetComment(nidComment);
            if(comment.NidComment != Guid.Empty)
            {
                comment.State = 2;
                if(_productAction.UpdateComment(comment))
                    return Json(new { success = true, message = "نظر با موفقیت حذف شد." });
                else
                    return Json(new { success = false, message = "خطا در حذف نظر" });
            }else
                return Json(new { success = false, message = "خطا در حذف نظر" });
        }
        public IActionResult AcceptComment(Guid nidComment) 
        {
            var comment = _productAction.GetComment(nidComment);
            if (comment.NidComment != Guid.Empty)
            {
                comment.State = 1;
                if (_productAction.UpdateComment(comment))
                    return Json(new { success = true, message = "نظر با موفقیت تایید شد." });
                else
                    return Json(new { success = false, message = "خطا در تایید نظر" });
            }
            else
                return Json(new { success = false, message = "خطا در تایید نظر" });
        }
        public IActionResult AcceptedComments()
        {
            var comments = _productAction.GetComments(1);
            return View(comments);
        }
        public IActionResult UnAcceptComment(Guid nidComment)
        {
            var comment = _productAction.GetComment(nidComment);
            if (comment.NidComment != Guid.Empty)
            {
                comment.State = 0;
                if (_productAction.UpdateComment(comment))
                    return Json(new { success = true, message = "نظر با موفقیت بازگردانده شد." });
                else
                    return Json(new { success = false, message = "خطا در بازگرداندن نظر" });
            }
            else
                return Json(new { success = false, message = "خطا در بازگرداندن نظر" });
        }
        public IActionResult HolooProducts() 
        {
            HolooProductViewModel model = new HolooProductViewModel();
            model.Articles = _replicationAction.GetArticles();
            model.Latest = _replicationAction.GetLastRepLog();
            return View(model);
        }
        //general section
        public async Task<IActionResult> UploadFile(IFormCollection data, IList<IFormFile> files) 
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
            List<string[]> pics = new List<string[]>();
            foreach (var file in data.Files)
            {
                if (file.Length > 0)
                {
                    string newFileName = "Image_" + DateTime.Now.ToShortDateString().Replace('/', '_') + "_" + DateTime.Now.ToString("HH:mm:ss").Replace(':', '_') + "_" + file.FileName.Split('.')[0].Replace(' ', '_') + ".webp";
                    string filePath = Path.Combine(configuration.GetSection("ImagesPathRoot").Value, newFileName);
                    if (Commons.SaveReducedImage(int.Parse(data["ImageWidth"].ToString()), int.Parse(data["ImageHeight"].ToString()),filePath,file))
                    {
                        var newFile = new Models.File() { NidFile = Guid.NewGuid(), CreateDate = DateTime.Now, RelateType = byte.Parse(data["fileType"].ToString()), FileName = newFileName, FileExtension = "webp", FilePath = filePath, FileSize = (int)(file.Length / 1024), FileUrl = $"{configuration.GetSection("ImageUrlRoot").Value}{newFileName}", Priority = 0, RelateId = Guid.Parse(data["RelateId"].ToString()) };
                        _commonAction.Add<Models.File>(newFile);
                    }
                }
            }
            var gfiles = _commonAction.GetFiles(Guid.Parse(data["RelateId"].ToString()));
            foreach (var gfile in gfiles.Where(p => p.RelateType == byte.Parse(data["fileType"].ToString())))
            {
                pics.Add(new string[3] { gfile.NidFile.ToString(), gfile.FileUrl, gfile.FileName });
            }
            string tmpPic = await RenderViewToString.RenderViewAsync(this, "_FileDemo", pics, true);
            return Json(new { success = true, pics = tmpPic});
        }
        public IActionResult DeleteFile(Guid NidFile) 
        {
            var file = _commonAction.GetFile(NidFile);
            if(file.NidFile != Guid.Empty)
            {
                System.IO.File.Delete(file.FilePath);
                if(_commonAction.Remove<Models.File>(file))
                    return Json(new { success = true });
                else
                    return Json(new { success = false });
            }else
                return Json(new { success = false });
        }
        public IActionResult Settings()
        {
            SettingViewModel model = new SettingViewModel();
            model.Settings = _commonAction.GetSettings();
            model.Files = _commonAction.GetCommonFiles();
            return View(model);
        }
        public IActionResult AddSetting(Setting setting)
        {
            setting.NidSetting = Guid.NewGuid();
            setting.State = 0;
            if (_commonAction.Add<Setting>(setting))
                TempData["SettingSuccess"] = "تنظیمات با موفقیت ایجاد گردید";
            else
                TempData["SettingError"] = "خطا در ایجاد تنظیمات.لطفا مجددا امتحان کنید";

            return RedirectToAction("Settings");
        }
        public IActionResult EditSetting(Setting setting)
        {
            if (_commonAction.Update<Setting>(setting))
                TempData["SettingSuccess"] = "تنظیمات با موفقیت ویرایش گردید";
            else
                TempData["SettingError"] = "خطا در ویرایش تنظیمات.لطفا مجددا امتحان کنید";

            return RedirectToAction("Settings");
        }
        public IActionResult DeleteSetting(Guid NidSetting)
        {
            var setting = _commonAction.GetSetting(NidSetting);
            if (setting.NidSetting != Guid.Empty)
            {
                setting.State = 2;
                if (_commonAction.Update<Setting>(setting))
                    TempData["SettingSuccess"] = "تنظیمات با حذف ایجاد گردید";
                else
                    TempData["SettingError"] = "خطا در حذف تنظیمات.لطفا مجددا امتحان کنید";
            }
            else
                TempData["SettingError"] = "تنظیمات یافت نشد";
            return RedirectToAction("Settings");
        }
        //blog section
            //blogs
        public IActionResult Blogs()
        {
            BlogViewModel model = new BlogViewModel();
            model.Blogs = _blogAction.GetBlogs();
            model.BlogCategories = _blogAction.GetBlogCategories();
            return View(model);
        }
        public IActionResult AddBlog()
        {
            BlogViewModel model = new BlogViewModel();
            model.BlogCategories = _blogAction.GetBlogCategories(false);
            return View(model);
        }
        public IActionResult SubmitAddBlog(Blog blog)
        {
            blog.CreateDate = DateTime.Now;
            blog.NidBlog = Guid.NewGuid();
            blog.State = 0;
            blog.UserId = Guid.Parse(User.Claims.FirstOrDefault(p => p.Type == "NidUser").Value);
            if (_blogAction.Add<Blog>(blog))
                TempData["BlogSuccess"] = "مقاله با موفقیت ایجاد گردید";
            else
                TempData["BlogError"] = "خطا در ایجاد مقاله.لطفا مجددا امتحان کنید";
            return RedirectToAction("Blogs");
        }
        public IActionResult EditBlog(Guid NidBlog)
        {
            BlogViewModel model = new BlogViewModel();
            model.Blog = _blogAction.GetBlog(NidBlog);
            model.BlogCategories = _blogAction.GetBlogCategories(false);
            model.Files = _commonAction.GetFiles(NidBlog);
            return View(model);
        }
        public IActionResult SubmitEditBlog(Blog blog)
        {
            blog.LastModified = DateTime.Now;
            if (_blogAction.UpdateBlog(blog))
                TempData["BlogSuccess"] = "مقاله با موفقیت ویرایش گردید";
            else
                TempData["BlogError"] = "خطا در ویرایش مقاله.لطفا مجددا امتحان کنید";
            return RedirectToAction("Blogs");
        }
        public IActionResult BlogDetail(Guid NidBlog)
        {
            var blog = _blogAction.GetBlog(NidBlog, true);
            if (blog.NidBlog != Guid.Empty)
                return Json(new { success = true, html = Helpers.RenderViewToString.RenderViewAsync(this, "_BlogDetail", blog, true) });
            else
                return Json(new { success = false });
        }
        public IActionResult DeleteBlog(Guid NidBlog)
        {
            var blog = _blogAction.GetBlog(NidBlog);
            if (blog.NidBlog != Guid.Empty)
            {
                blog.State = 2;
                blog.LastModified = DateTime.Now;
                if (_blogAction.UpdateBlog(blog))
                    return Json(new { success = true, message = "مقاله با موفقیت حذف گردید" });
                else
                    return Json(new { success = false, message = "خطا در حذف مقاله.لطفا مجددا امتحان کنید" });
            }
            else
            {
                return Json(new { success = false, message = "مقاله مورد نظر یافت نشد" });
            }
        }
            //blog cats
        public IActionResult BlogCategories()
        {
            var Categories = _blogAction.GetBlogCategories();
            return View(Categories);
        }
        public IActionResult AddBlogCategory(BlogCategory category)
        {
            category.NidCategory = Guid.NewGuid();
            category.CreateDate = DateTime.Now;
            category.State = 0;
            if (_blogAction.Add<BlogCategory>(category))
                TempData["BlogCategorySuccess"] = "دسته بندی با موفقیت ایجاد گردید";
            else
                TempData["BlogCategoryError"] = "خطا در ایجاد دسته بندی.لطفا مجددا امتحان کنید";
            return RedirectToAction("BlogCategories");
        }
        public IActionResult BlogCategory(Guid NidCategory)
        {
            var category = _blogAction.GetBlogCategory(NidCategory);
            return View(category);
        }
        public IActionResult EditBlogCategory(BlogCategory category)
        {
            category.LastModified = DateTime.Now;
            if (_blogAction.UpdateBlogCategory(category))
                TempData["BlogCategoryPageSuccess"] = "دسته بندی با موفقیت ویرایش گردید";
            else
                TempData["BlogCategoryPageError"] = "خطا در ویرایش دسته بندی.لطفا مجددا امتحان کنید";
            return RedirectToAction("BlogCategory", new { NidCategory = category.NidCategory });
        }
        public IActionResult DeleteBlogCategory(Guid NidCategory)
        {
            var category = _blogAction.GetBlogCategory(NidCategory, false);
            category.State = 2;
            category.LastModified = DateTime.Now;
            if (_blogAction.UpdateBlogCategory(category))
                TempData["BlogCategorySuccess"] = "دسته بندی با موفقیت حذف گردید";
            else
                TempData["BlogCategoryError"] = "خطا در حذف دسته بندی.لطفا مجددا امتحان کنید";
            return RedirectToAction("BlogCategories");
        }
        public IActionResult CloseBlogCategory(Guid NidCategory)
        {
            var category = _blogAction.GetBlogCategory(NidCategory, false);
            category.State = 1;
            category.LastModified = DateTime.Now;
            if (_blogAction.UpdateBlogCategory(category))
                TempData["BlogCategorySuccess"] = "دسته بندی با موفقیت غیرفعال گردید";
            else
                TempData["BlogCategoryError"] = "خطا در غیرفعال کردن دسته بندی.لطفا مجددا امتحان کنید";
            return RedirectToAction("BlogCategories");
        }
            //blog comments
        public IActionResult BlogComments()
        {
            var comments = _blogAction.GetBlogComments();
            return View(comments);
        }
        public IActionResult DeleteBlogComment(Guid nidComment)
        {
            var comment = _blogAction.GetBlogComment(nidComment);
            if (comment.NidComment != Guid.Empty)
            {
                comment.State = 2;
                if (_blogAction.UpdateBlogComment(comment))
                    return Json(new { success = true, message = "نظر با موفقیت حذف شد." });
                else
                    return Json(new { success = false, message = "خطا در حذف نظر" });
            }
            else
                return Json(new { success = false, message = "خطا در حذف نظر" });
        }
        public IActionResult AcceptBlogComment(Guid nidComment)
        {
            var comment = _blogAction.GetBlogComment(nidComment);
            if (comment.NidComment != Guid.Empty)
            {
                comment.State = 1;
                if (_blogAction.UpdateBlogComment(comment))
                    return Json(new { success = true, message = "نظر با موفقیت تایید شد." });
                else
                    return Json(new { success = false, message = "خطا در تایید نظر" });
            }
            else
                return Json(new { success = false, message = "خطا در تایید نظر" });
        }
        public IActionResult AcceptedBlogComments()
        {
            var comments = _blogAction.GetBlogComments(1);
            return View(comments);
        }
        public IActionResult UnAcceptBlogComment(Guid nidComment)
        {
            var comment = _blogAction.GetBlogComment(nidComment);
            if (comment.NidComment != Guid.Empty)
            {
                comment.State = 0;
                if (_blogAction.UpdateBlogComment(comment))
                    return Json(new { success = true, message = "نظر با موفقیت بازگردانده شد." });
                else
                    return Json(new { success = false, message = "خطا در بازگرداندن نظر" });
            }
            else
                return Json(new { success = false, message = "خطا در بازگرداندن نظر" });
        }
        //less importants
        public IActionResult Index()
        {
            var res = _commonAction.GetIndexPageValues();
            return View(res);
        }
        public IActionResult Charts()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
    }
}