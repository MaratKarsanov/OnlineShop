using Serilog;
using OnlineShop.Db;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShop.Db.Repositories;
using Microsoft.AspNetCore.Identity;
using OnlineShopWebApp;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) => configuration
.ReadFrom.Configuration(context.Configuration)
.Enrich.WithProperty("ApplicationName", "Online Shop"));

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("online_shop_karsanov"));
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<DatabaseContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
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

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<User>>();
    var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    IdentityInitializer.Initialize(userManager, rolesManager);
}

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
