using AudioShopBackend.Models;
using AudioShopBackend.Models.RepDbModel;
using AudioShopBackend.Services.Contracts;
using AudioShopBackend.Services.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUserAction, UserAction>();
builder.Services.AddScoped<IProductAction, ProductAction>();
builder.Services.AddScoped<ICategoryAction, CategoryAction>();
builder.Services.AddScoped<ICommonAction, CommonAction>();
builder.Services.AddScoped<IReplicationAction, ReplicationAction>();
builder.Services.AddScoped<IBlogAction, BlogAction>();
builder.Services.AddDbContext<AudioShopDbContext>();
builder.Services.AddDbContext<HoloRepDbContext>();
builder.Services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin,
                                            UnicodeRanges.Arabic }));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromHours(8);//change if needed
    options.LoginPath = "/Home/Login";
});
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
