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

        public HomeController(IProductRepository productRepository,
            IFavouritesRepository favouritesRepository,
            IComparisonRepository comparisonRepository)
        {
            this.productRepository = productRepository;
            this.favouritesRepository = favouritesRepository;
            this.comparisonRepository = comparisonRepository;
        }

        public IActionResult Index(string searchString = "", int pageNumber = 1)
        {
            ViewData["searchString"] = searchString;
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
            var foundedProducts = productRepository.GetAll();
            if (searchString != "")
            {
                foundedProducts = foundedProducts
                    .Where(p => LevenshteinDistance(searchString.ToLower(),
                                    p.Name.Trim().ToLower().Substring(0, searchString.Length)) < 2)
                    .ToList();
            }
            ViewBag.Pager = new Pager(foundedProducts.Count(), pageNumber);
            var skippedProductsCount = (pageNumber - 1) * Constants.PageSize;
            var showingProducts = foundedProducts
                .Skip(skippedProductsCount)
                .Take(Constants.PageSize)
                .ToList();
            ViewBag.pageNumber = pageNumber;
            return View(Helpers.MappingHelper.ToProductViewModels(showingProducts));
        }

        private static int LevenshteinDistance(string firstString, string secondString)
        {
            var opt = new int[firstString.Length + 1, secondString.Length + 1];
            for (var i = 0; i <= firstString.Length; ++i)
                opt[i, 0] = i;
            for (var i = 0; i <= secondString.Length; ++i)
                opt[0, i] = i;
            for (var i = 1; i <= firstString.Length; ++i)
            {
                for (var j = 1; j <= secondString.Length; ++j)
                {
                    if (firstString[i - 1] == secondString[j - 1])
                        opt[i, j] = opt[i - 1, j - 1];
                    else
                        opt[i, j] = Math.Min(
                            Math.Min(1 + opt[i - 1, j], 1 + opt[i, j - 1]),
                            1 + opt[i - 1, j - 1]);
                }
            }
            return opt[firstString.Length, secondString.Length];
        }
    }
}
