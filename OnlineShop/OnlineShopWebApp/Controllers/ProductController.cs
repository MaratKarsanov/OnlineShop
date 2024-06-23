using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.ApiClients;
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
        private ReviewsApiClient reviewsApiClient;

        public ProductController(IProductRepository productRepository,
            IFavouritesRepository favouritesRepository,
            IComparisonRepository comparisonRepository,
            IMapper mapper,
            ReviewsApiClient reviewsApiClient)
        {
            this.productRepository = productRepository;
            this.favouritesRepository = favouritesRepository;
            this.comparisonRepository = comparisonRepository;
            this.mapper = mapper;
            this.reviewsApiClient = reviewsApiClient;
        }

        public async Task<IActionResult> Index(Guid id)
        {
            var product = await productRepository.TryGetByIdAsync(id);
            var showingProduct = product.ToProductViewModel();
            var userName = User.Identity.Name;
            if (userName is not null && userName != string.Empty)
            {
                var favourites = await favouritesRepository.TryGetByUserNameAsync(userName);
                if (favourites is null)
                    favourites = await favouritesRepository.AddFavouritesAsync(userName);
                var comparison = await comparisonRepository.TryGetByUserIdAsync(userName);
                if (comparison is null)
                    comparison = await comparisonRepository.AddComparisonAsync(userName);
                var favouriteProducts = favourites.Items.ToProductViewModels();
                var comparisonProducts = comparison.Items.ToProductViewModels();
                showingProduct.IsInFavourites = favouriteProducts.Contains(showingProduct);
                showingProduct.IsInComparison = comparisonProducts.Contains(showingProduct);
            }
            var reviews = await reviewsApiClient.GetByProductIdAsync(id);
            showingProduct.Reviews = reviews;
            return View(showingProduct);
        }
    }
}