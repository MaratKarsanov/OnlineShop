using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Redis;
using Serilog;
using System.Text.Json;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IFavouritesRepository _favouritesRepository;
        private readonly IComparisonRepository _comparisonRepository;
        private readonly IMapper _mapper;
        private readonly IRedisCacheService _redisCacheService;

        public HomeController(
            IProductRepository productRepository,
            IFavouritesRepository favouritesRepository,
            IComparisonRepository comparisonRepository,
            IMapper mapper,
            IRedisCacheService redisCacheService)
        {
            _productRepository = productRepository;
            _favouritesRepository = favouritesRepository;
            _comparisonRepository = comparisonRepository;
            _mapper = mapper;
            _redisCacheService = redisCacheService;
        }

        public async Task<IActionResult> Index(string searchString = "", int pageNumber = 1)
        {
            try
            {
                ViewData["searchString"] = searchString;
                var userName = User.Identity.Name;
                var searchStringLower = searchString.ToLower();
                var products = new List<ProductViewModel>();
                var cachedProducts = await _redisCacheService.TryGetAsync(Constants.ProductsRedisKey);
                if (!string.IsNullOrEmpty(cachedProducts))
                {
                    products = JsonSerializer.Deserialize<List<ProductViewModel>>(cachedProducts);
                }
                else
                {
                    products = _mapper.Map<List<ProductViewModel>>(await _productRepository.GetAllAsync());
                    //products = (await productRepository.GetAllAsync()).ToProductViewModels();
                    if (products is null)
                        return View(new List<ProductViewModel>());
                    await _redisCacheService.SetAsync(Constants.ProductsRedisKey, JsonSerializer.Serialize(products));
                }
                var foundedProducts = products
                    .Where(p => p.Name.ToLower().Contains(searchStringLower) || p.Description.ToLower().Contains(searchStringLower))
                    .ToList();
                ViewBag.Pager = new Pager(foundedProducts.Count(), pageNumber);
                var skippedProductsCount = (pageNumber - 1) * Constants.PageSize;
                var showingProducts = foundedProducts
                    .Skip(skippedProductsCount)
                    .Take(Constants.PageSize)
                    .ToList();
                ViewBag.pageNumber = pageNumber;
                if (userName is not null && userName != string.Empty)
                {
                    var favourites = await _favouritesRepository.TryGetByUserNameAsync(userName);
                    if (favourites is null)
                        favourites = await _favouritesRepository.AddFavouritesAsync(userName);
                    var comparison = await _comparisonRepository.TryGetByUserIdAsync(userName);
                    if (comparison is null)
                        comparison = await _comparisonRepository.AddComparisonAsync(userName);
                    //var favouriteProducts = favourites.Items.ToProductViewModels();
                    //var comparisonProducts = comparison.Items.ToProductViewModels();
                    var favouriteProducts = _mapper.Map<List<ProductViewModel>>(favourites.Items);
                    var comparisonProducts = _mapper.Map<List<ProductViewModel>>(comparison.Items);
                    foreach (var p in showingProducts)
                    {
                        p.IsInFavourites = favouriteProducts.Contains(p);
                        p.IsInComparison = comparisonProducts.Contains(p);
                    }
                }
                return View(showingProducts);
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }
    }
}
