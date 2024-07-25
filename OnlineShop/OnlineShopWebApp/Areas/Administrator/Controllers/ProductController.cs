using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.ApiClients;
using OnlineShopWebApp.Areas.Administrator.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Redis;
using Serilog;
using System.Text.Json;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area(Constants.AdministratorRoleName)]
    [Authorize(Roles = Constants.AdministratorRoleName)]
    public class ProductController : Controller
    {
        private IProductRepository productRepository;
        private IMapper mapper;
        private ImagesProvider imagesProvider;
        private IRedisCacheService redisCacheService;
        private IReviewsApiClient reviewsApiClient;

        public ProductController(IProductRepository productRepository,
            IMapper mapper,
            ImagesProvider imagesProvider,
            IRedisCacheService redisCacheService,
            IReviewsApiClient reviewsApiClient)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
            this.imagesProvider = imagesProvider;
            this.redisCacheService = redisCacheService;
            this.reviewsApiClient = reviewsApiClient;
        }

        public async Task<IActionResult> Index()
        {
            return View((await productRepository.GetAllAsync()).ToProductViewModels());
        }

        public async Task<IActionResult> Remove(Guid productId)
        {
            await productRepository.RemoveAsync(productId);
            await RemoveCacheAsync();
            await UpdateCacheAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
                return View();
            var imagesPaths = imagesProvider
                .SaveFiles(productViewModel.UploadedFiles, ImageFolders.Products);
            await productRepository.AddAsync(productViewModel.ToProduct(imagesPaths));
            await RemoveCacheAsync();
            await UpdateCacheAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid productId)
        {
            var product = await productRepository.TryGetByIdAsync(productId);
            return View(product.ToEditProductViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
                return View();
            if (productViewModel.UploadedFiles is not null 
                && productViewModel.UploadedFiles.Length > 0)
            {
                var addedImagesPaths = imagesProvider
                    .SaveFiles(productViewModel.UploadedFiles, ImageFolders.Products);
                productViewModel.ImagesPaths = addedImagesPaths;
            }
            else
            {
                productViewModel.ImagesPaths = new List<string>();
            }
            await productRepository.EditProductAsync(productViewModel.ToProduct());
            await RemoveCacheAsync();
            await UpdateCacheAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteImage(Guid productId, string imageUrl)
        {
            await productRepository.RemoveImageAsync(productId, imageUrl);
            var imageFileName = imageUrl.Split('/').Last();
            imagesProvider.DeleteFile(imageFileName, ImageFolders.Products);
            await RemoveCacheAsync();
            await UpdateCacheAsync();
            return RedirectToAction(nameof(Edit), new { productId });
        }

        private async Task UpdateCacheAsync()
        {
            try
            {
                var products = await productRepository.GetAllAsync();
                var productViewModels = new List<ProductViewModel>();

                foreach (var product in products)
                {
                    var reviews = await reviewsApiClient.GetByProductIdAsync(product.Id);
                    var productViewModel = product.ToProductViewModel();
                    productViewModel.Reviews = reviews;
                    productViewModels.Add(productViewModel);
                }
                var productsJson = JsonSerializer.Serialize(productViewModels);
                await redisCacheService.SetAsync(Constants.ProductsRedisKey, productsJson);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка обновления кеша Redis");
            }
        }

        private async Task RemoveCacheAsync()
        {
            try
            {
                await redisCacheService.RemoveAsync(Constants.ProductsRedisKey);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка удаления кеша Redis");
            }
        }
    }
}
