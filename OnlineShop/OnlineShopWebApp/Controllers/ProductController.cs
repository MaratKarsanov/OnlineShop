using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.ApiClients;
using OnlineShopWebApp.ApiModels;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using Serilog;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IFavouritesRepository _favouritesRepository;
        private readonly IComparisonRepository _comparisonRepository;
        private readonly IMapper _mapper;
        private readonly IReviewsApiClient _reviewsApiClient;
        private readonly UserManager<User> _userManager;

        public ProductController(
            IProductRepository productRepository,
            IFavouritesRepository favouritesRepository,
            IComparisonRepository comparisonRepository,
            IMapper mapper,
            IReviewsApiClient reviewsApiClient,
            UserManager<User> userManager)
        {
            _productRepository = productRepository;
            _favouritesRepository = favouritesRepository;
            _comparisonRepository = comparisonRepository;
            _mapper = mapper;
            _reviewsApiClient = reviewsApiClient;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Guid id)
        {
            try
            {
                var product = await _productRepository.TryGetByIdAsync(id);
                //var showingProduct = product.ToProductViewModel();
                var showingProduct = _mapper.Map<ProductViewModel>(product);
                var userName = User.Identity.Name;
                if (userName is not null && userName != string.Empty)
                {
                    var favourites = await _favouritesRepository.TryGetByUserNameAsync(userName);
                    if (favourites is null)
                    {
                        favourites = await _favouritesRepository.AddFavouritesAsync(userName);
                    }
                    var comparison = await _comparisonRepository.TryGetByUserIdAsync(userName);
                    if (comparison is null)
                    {
                        comparison = await _comparisonRepository.AddComparisonAsync(userName);
                    }
                    //var favouriteProducts = favourites.Items.ToProductViewModels();
                    var favouriteProducts = _mapper.Map<List<ProductViewModel>>(favourites.Items);
                    //var comparisonProducts = comparison.Items.ToProductViewModels();
                    var comparisonProducts = _mapper.Map<List<ProductViewModel>>(comparison.Items);
                    showingProduct.IsInFavourites = favouriteProducts.Contains(showingProduct);
                    showingProduct.IsInComparison = comparisonProducts.Contains(showingProduct);
                }
                var reviews = await _reviewsApiClient.TryGetByProductIdAsync(id);
                showingProduct.Reviews = reviews ?? new List<ReviewApiModel>();
                return View(showingProduct);
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddReview(AddReviewApiModel addReview)
        {
            try
            {
                var currentUser = await _userManager.GetUserAsync(User);
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
                    await _reviewsApiClient.AddAsync(addReview);
                    return RedirectToAction("Index", new { id = addReview.ProductId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Произошла ошибка при добавлении отзыва: " + ex.Message);
                    return RedirectToAction("Index", new { id = addReview.ProductId });
                }
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteReview(Guid productId, Guid reviewId)
        {
            try
            {
                await _reviewsApiClient.DeleteAsync(reviewId);
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