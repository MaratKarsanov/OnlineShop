using Serilog;
using OnlineShop.Db;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShop.Db.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) => configuration
.ReadFrom.Configuration(context.Configuration)
.Enrich.WithProperty("ApplicationName", "Online Shop"));

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("online_shop_karsanov"));
});

builder.Services.AddDbContext<IdentityContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("online_shop_karsanov"));
});

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<IdentityContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.LoginPath = "/Autorization/Login";
    options.LogoutPath = "/Autorization/Logout";
    options.Cookie = new CookieBuilder
    {
        IsEssential = true
    };
});

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IProductRepository, ProductDbRepository>();
builder.Services.AddTransient<IComparisonRepository, ComparisonDbRepository>();
builder.Services.AddTransient<IFavouritesRepository, FavouritesDbRepository>();
builder.Services.AddTransient<ICartRepository, CartDbRepository>();
builder.Services.AddTransient<IOrderRepository, OrderDbRepository>();
builder.Services.AddTransient<IRoleRepository, RoleDbRepository>();
builder.Services.AddTransient<IUserRepository, UserDbRepository>();

var app = builder.Build();
app.UseSerilogRequestLogging();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
