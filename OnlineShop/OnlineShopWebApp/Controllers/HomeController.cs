using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Administrator.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private OnlineShop.Db.IRepository<Product> productRepository;
        private IRepository<Favourities> favouritiesRepository;
        private IRepository<Role> roleRepository;
        public static string searchString = "";

        public HomeController(OnlineShop.Db.IRepository<Product> productRepository, 
            IRepository<Favourities> favouritiesRepository, 
            IRepository<Role> roleRepository)
        {
            this.productRepository = productRepository;
            this.favouritiesRepository = favouritiesRepository;
            this.roleRepository = roleRepository;
            //if (productRepository.Count() == 0)
            //{
            //    for (var i = 0; i < 1000; i++)
            //        productRepository.Add(new Product($"Name{i + 1}", (i + 1) * 1000));
            //}
            if (roleRepository.GetAll().Count() == 0)
            {
                roleRepository.Add(new Role() { Name = "User" });
                roleRepository.Add(new Role() { Name = "Administrator" });
            }
        }

        public IActionResult Index(string searchString, int pageNumber = 1)
        {
            if (searchString is not null)
                HomeController.searchString = searchString;
            if (searchString == "emptySearchString")
                HomeController.searchString = "";
            var foundedProducts = productRepository
                .GetAll()
                .Where(p => p.Name.Contains(HomeController.searchString))
                .ToList();
            ViewBag.Pager = new Pager(foundedProducts.Count(), pageNumber);
            var skippedProductsCount = (pageNumber - 1) * Constants.PageSize;
            var showingProducts = foundedProducts
                .Skip(skippedProductsCount)
                .Take(Constants.PageSize)
                .ToList();
            var favourities = favouritiesRepository.TryGetElementById(default);
            if (favourities is null)
                favourities = favouritiesRepository.Add(new Favourities(default));
            ViewBag.pageNumber = pageNumber;
            return View(Helpers.MappingHelper.ToProductViewModels(showingProducts));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
