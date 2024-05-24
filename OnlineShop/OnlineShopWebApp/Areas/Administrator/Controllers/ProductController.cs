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

        public IActionResult Index()
        {
            return View(productRepository.GetAll().ToProductViewModels());
        }

        public IActionResult Remove(Guid productId)
        {
            productRepository.Remove(productId);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
                return View();
            var imagesPaths = imagesProvider
                .SaveFiles(productViewModel.UploadedFiles, ImageFolders.Products);
            productRepository.Add(productViewModel.ToProduct(imagesPaths));
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(Guid productId)
        {
            var product = productRepository.TryGetById(productId);
            return View(product.ToEditProductViewModel());
        }

        [HttpPost]
        public IActionResult Edit(EditProductViewModel productViewModel)
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
            productRepository.EditProduct(productViewModel.ToProduct());
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteImage(Guid productId, string imageUrl)
        {
            productRepository.RemoveImage(productId, imageUrl);
            var imageFileName = imageUrl.Split('/').Last();
            imagesProvider.DeleteFile(imageFileName, ImageFolders.Products);
            return RedirectToAction(nameof(Edit), new { productId });
        }
    }
}
