using OnlineShopWebApp.Models;
using OnlineShopWebApp;
using Serilog;
using OnlineShopWebApp.Areas.Administrator.Models;
using OnlineShop.Db;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) => configuration
.ReadFrom.Configuration(context.Configuration)
.Enrich.WithProperty("ApplicationName", "Online Shop"));

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("online_shop_karsanov"));
});

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<OnlineShop.Db.IRepository<Product>, DbRepository<Product>>();
builder.Services.AddTransient<IComparisonRepository, ComparisonDbRepository>();
builder.Services.AddTransient<IFavouritesRepository, FavouritesDbRepository>();
builder.Services.AddTransient<ICartRepository, CartDbRepository>();
builder.Services.AddSingleton<OnlineShopWebApp.IRepository<Order>, InMemoryRepository<Order>>();
builder.Services.AddSingleton<OnlineShopWebApp.IRepository<Role>, InMemoryRepository<Role>>();
builder.Services.AddSingleton<OnlineShopWebApp.IRepository<User>, InMemoryRepository<User>>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
