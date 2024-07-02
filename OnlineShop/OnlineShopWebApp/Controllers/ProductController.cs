using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.ApiClients;
using OnlineShopWebApp.ApiModels;
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
        private UserManager<User> userManager;

        public ProductController(IProductRepository productRepository,
            IFavouritesRepository favouritesRepository,
            IComparisonRepository comparisonRepository,
            IMapper mapper,
            ReviewsApiClient reviewsApiClient,
            UserManager<User> userManager)
        {
            this.productRepository = productRepository;
            this.favouritesRepository = favouritesRepository;
            this.comparisonRepository = comparisonRepository;
            this.mapper = mapper;
            this.reviewsApiClient = reviewsApiClient;
            this.userManager = userManager;
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
                //var favouriteProducts = favourites.Items.ToProductViewModels();
                var favouriteProducts = mapper.Map<List<ProductViewModel>>(favourites.Items);
                //var comparisonProducts = comparison.Items.ToProductViewModels();
                var comparisonProducts = mapper.Map<List<ProductViewModel>>(comparison.Items);
                showingProduct.IsInFavourites = favouriteProducts.Contains(showingProduct);
                showingProduct.IsInComparison = comparisonProducts.Contains(showingProduct);
            }
            var reviews = await reviewsApiClient.GetByProductIdAsync(id);
            showingProduct.Reviews = reviews;
            return View(showingProduct);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddReview(AddReviewApiModel addReview)
        {
            var currentUser = await userManager.GetUserAsync(User);
            if (currentUser == null)
                return Unauthorized();
            if (!Guid.TryParse(currentUser.Id, out Guid userId))
            {
                ModelState.AddModelError("", "Произошла ошибка при идентификации пользователя.");
                return RedirectToAction("Index", new { id = addReview.ProductId });
            }
            addReview.UserId = userId;
            try
            {
                await reviewsApiClient.AddAsync(addReview);
                return RedirectToAction("Index", new { id = addReview.ProductId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Произошла ошибка при добавлении отзыва: " + ex.Message);
                return RedirectToAction("Index", new { id = addReview.ProductId });
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteReview(Guid productId, Guid reviewId)
        {
            try
            {
                await reviewsApiClient.DeleteAsync(reviewId);
                return RedirectToAction("Index", new { id = productId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Произошла ошибка при добавлении отзыва: " + ex.Message);
                return RedirectToAction("Index", new { id = productId });
            }
        }
    }
}