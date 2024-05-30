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
            var showingProduct = product.ToProductViewModel();
            var userName = User.Identity.Name;
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
                showingProduct.IsInFavourites = favouriteProducts.Contains(showingProduct);
                showingProduct.IsInComparison = comparisonProducts.Contains(showingProduct);
            }
            return View(showingProduct);
        }
    }
}