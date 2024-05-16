using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;
using System;

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
            var userName = User.Identity.Name;
            if (userName is not null && userName != string.Empty)
            {
                var favourites = favouritesRepository.TryGetByUserName(userName);
                if (favourites is null)
                    favourites = favouritesRepository.AddFavourites(userName);
                var comparison = comparisonRepository.TryGetByUserId(userName);
                if (comparison is null)
                    comparison = comparisonRepository.AddComparison(userName);
                ViewBag.favouriteProducts = Helpers.MappingHelper
                    .ToProductViewModels(favourites.Items)
                    .ToHashSet();
                ViewBag.comparisonProducts = Helpers.MappingHelper
                    .ToProductViewModels(comparison.Items)
                    .ToHashSet();
            }
            else
            {
                ViewBag.favouriteProducts = new HashSet<ProductViewModel>();
                ViewBag.comparisonProducts = new HashSet<ProductViewModel>();
            }
            var searchStringLower = searchString.ToLower();
            var foundedProducts = productRepository
                .GetAll()
                .Where(p => p.Name.ToLower().Contains(searchStringLower) || p.Description.ToLower().Contains(searchStringLower));
            ViewBag.Pager = new Pager(foundedProducts.Count(), pageNumber);
            var skippedProductsCount = (pageNumber - 1) * Constants.PageSize;
            var showingProducts = foundedProducts
                .Skip(skippedProductsCount)
                .Take(Constants.PageSize)
                .ToList();
            ViewBag.pageNumber = pageNumber;
            return View(Helpers.MappingHelper.ToProductViewModels(showingProducts));
        }
    }
}
