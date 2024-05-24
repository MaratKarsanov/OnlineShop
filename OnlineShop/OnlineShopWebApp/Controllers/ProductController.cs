using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository productRepository;
        private IFavouritesRepository favouritesRepository;
        private IComparisonRepository comparisonRepository;
        private IMapper mapper;

        public ProductController(IProductRepository productRepository,
            IFavouritesRepository favouritesRepository,
            IComparisonRepository comparisonRepository,
            IMapper mapper)
        {
            this.productRepository = productRepository;
            this.favouritesRepository = favouritesRepository;
            this.comparisonRepository = comparisonRepository;
            this.mapper = mapper;
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
                ViewBag.favouriteProducts = favourites.Items
                    .Select(mapper.Map<ProductViewModel>)
                    .ToHashSet();
                ViewBag.comparisonProducts = comparison.Items
                    .Select(mapper.Map<ProductViewModel>)
                    .ToHashSet();
            }
            else
            {
                ViewBag.favouriteProducts = new HashSet<ProductViewModel>();
                ViewBag.comparisonProducts = new HashSet<ProductViewModel>();
            }
            if (product is null)
                throw new NullReferenceException("Товара с такиим id нет в репозитории!");
            return View(product.ToProductViewModel());
        }
    }
}