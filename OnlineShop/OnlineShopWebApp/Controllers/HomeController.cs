using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Product> productRepository;

        public HomeController(IRepository<Product> productRepository)
        {
            for (var i = 0; i < 100; i++)
                productRepository.Add(new Product($"Name{i + 1}", (i + 1) * 1000));
            this.productRepository = productRepository;
        }

        public IActionResult Index(int pageNumber = 1)
        {
            ViewBag.Pager = new Pager(productRepository.Count(), pageNumber);
            var skippedProductsCount = (pageNumber - 1) * Constants.PageSize;
            var showingProducts = productRepository
                .Skip(skippedProductsCount)
                .Take(Constants.PageSize)
                .ToList();
            return View(showingProducts);
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
