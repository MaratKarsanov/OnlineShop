using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository productRepository;
        private IFavouritesRepository favouritesRepository;
        private IComparisonRepository comparisonRepository;

        public ProductController(IProductRepository productRepository,
            IFavouritesRepository favouritesRepository,
            IComparisonRepository comparisonRepository)
        {
            this.productRepository = productRepository;
            this.favouritesRepository = favouritesRepository;
            this.comparisonRepository = comparisonRepository;
        }

        public IActionResult Index(Guid id)
        {
            var product = productRepository.TryGetById(id);
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
            if (product is null)
                throw new NullReferenceException("Товара с такиим id нет в репозитории!");
            return View(Helpers.MappingHelper.ToProductViewModel(product));
        }
    }
}