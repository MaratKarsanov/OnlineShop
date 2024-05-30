using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository productRepository;
        private IFavouritesRepository favouritesRepository;
        private IComparisonRepository comparisonRepository;
        private IMapper mapper;

        public HomeController(IProductRepository productRepository,
            IFavouritesRepository favouritesRepository,
            IComparisonRepository comparisonRepository,
            IMapper mapper)
        {
            this.productRepository = productRepository;
            this.favouritesRepository = favouritesRepository;
            this.comparisonRepository = comparisonRepository;
            this.mapper = mapper;
        }

        public IActionResult Index(string searchString = "", int pageNumber = 1)
        {
            ViewData["searchString"] = searchString;
            var userName = User.Identity.Name;
            var searchStringLower = searchString.ToLower();
            var foundedProducts = productRepository
                .GetAll()
                .Where(p => p.Name.ToLower().Contains(searchStringLower) || p.Description.ToLower().Contains(searchStringLower));
            ViewBag.Pager = new Pager(foundedProducts.Count(), pageNumber);
            var skippedProductsCount = (pageNumber - 1) * Constants.PageSize;
            var showingProducts = foundedProducts
                .Skip(skippedProductsCount)
                .Take(Constants.PageSize)
                .ToList()
                .ToProductViewModels();
            ViewBag.pageNumber = pageNumber;
            if (userName is not null && userName != string.Empty)
            {
                var favourites = favouritesRepository.TryGetByUserName(userName);
                if (favourites is null)
                    favourites = favouritesRepository.AddFavourites(userName);
                var comparison = comparisonRepository.TryGetByUserId(userName);
                if (comparison is null)
                    comparison = comparisonRepository.AddComparison(userName);
                var favouriteProducts = favourites.Items.ToProductViewModels();
                var comparisonProducts = comparison.Items.ToProductViewModels();
                foreach (var p in showingProducts)
                {
                    p.IsInFavourites = favouriteProducts.Contains(p);
                    p.IsInComparison = comparisonProducts.Contains(p);
                }
            }
            return View(showingProducts);
        }
    }
}
