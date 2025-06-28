using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.ApiClients;
using OnlineShopWebApp.ApiModels;
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
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ImagesProvider _imagesProvider;
        private readonly IRedisCacheService _redisCacheService;
        private readonly IReviewsApiClient _reviewsApiClient;

        public ProductController(IProductRepository productRepository,
            IMapper mapper,
            ImagesProvider imagesProvider,
            IRedisCacheService redisCacheService,
            IReviewsApiClient reviewsApiClient)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _imagesProvider = imagesProvider;
            _redisCacheService = redisCacheService;
            _reviewsApiClient = reviewsApiClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View((await _productRepository.GetAllAsync()).ToProductViewModels());
        }

        [HttpPost]
        public async Task<IActionResult> Remove(Guid productId)
        {
            try
            {
                await _productRepository.RemoveAsync(productId);
                await RemoveCacheAsync();
                await UpdateCacheAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel productViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                var imagesPaths = _imagesProvider
                    .SaveFiles(productViewModel.UploadedFiles, ImageFolders.Products);
                await _productRepository.AddAsync(productViewModel.ToProduct(imagesPaths));
                await RemoveCacheAsync();
                await UpdateCacheAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid productId)
        {
            try
            {
                var product = await _productRepository.TryGetByIdAsync(productId);
                return View(product.ToEditProductViewModel());
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProductViewModel productViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                if (productViewModel.UploadedFiles is not null
                    && productViewModel.UploadedFiles.Length > 0)
                {
                    var addedImagesPaths = _imagesProvider
                        .SaveFiles(productViewModel.UploadedFiles, ImageFolders.Products);
                    productViewModel.ImagesPaths = addedImagesPaths;
                }
                else
                {
                    productViewModel.ImagesPaths = new List<string>();
                }
                await _productRepository.EditProductAsync(productViewModel.ToProduct());
                await RemoveCacheAsync();
                await UpdateCacheAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteImage(Guid productId, string imageUrl)
        {
            try
            {
                await _productRepository.RemoveImageAsync(productId, imageUrl);
                var imageFileName = imageUrl.Split('/').Last();
                _imagesProvider.DeleteFile(imageFileName, ImageFolders.Products);
                await RemoveCacheAsync();
                await UpdateCacheAsync();
                return RedirectToAction(nameof(Edit), new { productId });
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        private async Task UpdateCacheAsync()
        {
            try
            {
                var products = await _productRepository.GetAllAsync();
                var productViewModels = new List<ProductViewModel>();

                foreach (var product in products)
                {
                    var reviews = await _reviewsApiClient.TryGetByProductIdAsync(product.Id);
                    var productViewModel = product.ToProductViewModel();
                    productViewModel.Reviews = reviews ?? new List<ReviewApiModel>();
                    productViewModels.Add(productViewModel);
                }
                var productsJson = JsonSerializer.Serialize(productViewModels);
                await _redisCacheService.SetAsync(Constants.ProductsRedisKey, productsJson);
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
                await _redisCacheService.RemoveAsync(Constants.ProductsRedisKey);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Ошибка удаления кеша Redis");
            }
        }
    }
}
