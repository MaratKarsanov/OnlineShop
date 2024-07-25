using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Redis;
using System.Text.Json;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository productRepository;
        private IFavouritesRepository favouritesRepository;
        private IComparisonRepository comparisonRepository;
        private IMapper mapper;
        private readonly IRedisCacheService redisCacheService;

        public HomeController(IProductRepository productRepository,
            IFavouritesRepository favouritesRepository,
            IComparisonRepository comparisonRepository,
            IMapper mapper,
            IRedisCacheService redisCacheService)
        {
            this.productRepository = productRepository;
            this.favouritesRepository = favouritesRepository;
            this.comparisonRepository = comparisonRepository;
            this.mapper = mapper;
            this.redisCacheService = redisCacheService;
        }

        public async Task<IActionResult> Index(string searchString = "", int pageNumber = 1)
        {
            ViewData["searchString"] = searchString;
            var userName = User.Identity.Name;
            var searchStringLower = searchString.ToLower();
            var products = new List<ProductViewModel>();
            var cachedProducts = await redisCacheService.TryGetAsync(Constants.ProductsRedisKey);
            if (!string.IsNullOrEmpty(cachedProducts))
            {
                products = JsonSerializer.Deserialize<List<ProductViewModel>>(cachedProducts);
            }
            else
            {
                products = mapper.Map<List<ProductViewModel>>(await productRepository.GetAllAsync());
                //products = (await productRepository.GetAllAsync()).ToProductViewModels();
                if (products is null)
                    return View(new List<ProductViewModel>());
                await redisCacheService.SetAsync(Constants.ProductsRedisKey, JsonSerializer.Serialize(products));
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
                var favourites = await favouritesRepository.TryGetByUserNameAsync(userName);
                if (favourites is null)
                    favourites = await favouritesRepository.AddFavouritesAsync(userName);
                var comparison = await comparisonRepository.TryGetByUserIdAsync(userName);
                if (comparison is null)
                    comparison = await comparisonRepository.AddComparisonAsync(userName);
                //var favouriteProducts = favourites.Items.ToProductViewModels();
                //var comparisonProducts = comparison.Items.ToProductViewModels();
                var favouriteProducts = mapper.Map<List<ProductViewModel>>(favourites.Items);
                var comparisonProducts = mapper.Map<List<ProductViewModel>>(comparison.Items);
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
