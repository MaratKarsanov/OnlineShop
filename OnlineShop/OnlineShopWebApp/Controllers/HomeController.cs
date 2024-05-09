using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository productRepository;
        private IFavouritesRepository favouritesRepository;
        private IComparisonRepository comparisonRepository;
        public static string searchString = "";

        public HomeController(IProductRepository productRepository,
            IFavouritesRepository favouritesRepository,
            IComparisonRepository comparisonRepository)
        {
            this.productRepository = productRepository;
            this.favouritesRepository = favouritesRepository;
            this.comparisonRepository = comparisonRepository;
        }

        public IActionResult Index(string searchString, int pageNumber = 1)
        {
            if (searchString is not null)
                HomeController.searchString = searchString;
            if (searchString == "emptySearchString")
                HomeController.searchString = "";
            var login = Request.Cookies["userLogin"];
            if (login is not null && login != string.Empty)
            {
                var favourites = favouritesRepository.TryGetByUserId(login);
                if (favourites is null)
                    favourites = favouritesRepository.AddFavourites(login);
                var comparison = comparisonRepository.TryGetByUserId(login);
                if (comparison is null)
                    comparison = comparisonRepository.AddComparison(login);
                var favouriteProducts = favourites.Items.ToHashSet();
                var comparisonProducts = comparison.Items.ToHashSet();
                productRepository.UpdateInFavouritesCondition(favouriteProducts);
                productRepository.UpdateInComparisonCondition(comparisonProducts);
            }
            else
            {
                productRepository.UpdateInFavouritesCondition(new HashSet<Product>());
                productRepository.UpdateInComparisonCondition(new HashSet<Product>());
            }
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
