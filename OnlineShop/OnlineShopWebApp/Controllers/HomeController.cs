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
        private IImagesRepository imagesRepository;

        public HomeController(IProductRepository productRepository,
            IFavouritesRepository favouritesRepository,
            IComparisonRepository comparisonRepository,
            IMapper mapper,
            IImagesRepository imagesRepository)
        {
            this.productRepository = productRepository;
            this.favouritesRepository = favouritesRepository;
            this.comparisonRepository = comparisonRepository;
            this.mapper = mapper;
            this.imagesRepository = imagesRepository;
        }

        public async Task<IActionResult> Index(string searchString = "", int pageNumber = 1)
        {
            ViewData["searchString"] = searchString;
            var userName = User.Identity.Name;
            var searchStringLower = searchString.ToLower();
            var products = new List<ProductViewModel>();
            //products = mapper.Map<List<ProductViewModel>>(await productRepository.GetAllAsync());
            var dbProducts = await productRepository.GetAllAsync();
            if (dbProducts.First().ProductImages is null || dbProducts.First().ProductImages.Count == 0)
            {
                foreach (var p in dbProducts)
                {
                    var imageUrl = (await imagesRepository.TryGetImagesByProductIdAsync(p.Id))
                        .First()
                        .Url;
                    productRepository.AddExistingImageAsync(p.Id, imageUrl);
                }
            }
            products = dbProducts.ToProductViewModels();
            if (products is null)
                return View(new List<ProductViewModel>());
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
