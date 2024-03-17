using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int pageNumber = 1)
        {
            ViewBag.Pager = new Pager(Repositories.ProductRepository.Count(), pageNumber);
            var skippedProductsCount = (pageNumber - 1) * Constants.PageSize;
            var showingProducts = Repositories.ProductRepository
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
