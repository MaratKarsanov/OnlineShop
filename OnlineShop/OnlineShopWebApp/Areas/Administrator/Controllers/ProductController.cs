using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;
using System.Data;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area(Constants.AdministratorRoleName)]
    [Authorize(Roles = Constants.AdministratorRoleName)]
    public class ProductController : Controller
    {
        private IProductRepository productRepository;
        private IMapper mapper;

        public ProductController(IProductRepository productRepository,
            IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(mapper.Map<List<ProductViewModel>>(productRepository.GetAll()));
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
        public IActionResult Add(Product newProduct)
        {
            if (!ModelState.IsValid)
                return View();
            newProduct.Id = Guid.NewGuid();
            newProduct.ImageLink = Constants.ImageLink;
            productRepository.Add(newProduct);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(Guid productId)
        {
            var product = productRepository.TryGetById(productId);
            return View(mapper.Map<ProductViewModel>(product));
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel newProduct)
        {
            if (!ModelState.IsValid)
                return View();
            productRepository.EditProduct(mapper.Map<Product>(newProduct));
            return RedirectToAction(nameof(Index));
        }
    }
}
