using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Areas.Administrator.Models;
using OnlineShopWebApp.Helpers;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area(Constants.AdministratorRoleName)]
    [Authorize(Roles = Constants.AdministratorRoleName)]
    public class ProductController : Controller
    {
        private IProductRepository productRepository;
        private IMapper mapper;
        private ImagesProvider imagesProvider;

        public ProductController(IProductRepository productRepository,
            IMapper mapper,
            ImagesProvider imagesProvider)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
            this.imagesProvider = imagesProvider;
        }

        public async Task<IActionResult> Index()
        {
            return View((await productRepository.GetAllAsync()).ToProductViewModels());
        }

        public async Task<IActionResult> Remove(Guid productId)
        {
            await productRepository.RemoveAsync(productId);
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
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteImage(Guid productId, string imageUrl)
        {
            await productRepository.RemoveImageAsync(productId, imageUrl);
            var imageFileName = imageUrl.Split('/').Last();
            imagesProvider.DeleteFile(imageFileName, ImageFolders.Products);
            return RedirectToAction(nameof(Edit), new { productId });
        }
    }
}
