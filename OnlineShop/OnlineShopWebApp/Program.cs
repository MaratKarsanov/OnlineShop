using OnlineShopWebApp.Models;
using OnlineShopWebApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
for (var i = 0; i < 2; i++)
    builder.Services.AddSingleton<IRepository<Product>, InMemoryRepository<Product>>();
builder.Services.AddSingleton<IRepository<Favourities>, InMemoryRepository<Favourities>>();
builder.Services.AddSingleton<IRepository<Cart>, InMemoryRepository <Cart>>();
builder.Services.AddSingleton<IRepository<Order>, InMemoryRepository<Order>>();
builder.Services.AddSingleton<IRepository<Role>, InMemoryRepository<Role>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
