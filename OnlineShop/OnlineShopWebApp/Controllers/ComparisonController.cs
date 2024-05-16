using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class ComparisonController : Controller
    {
        private IProductRepository productRepository;
        private IComparisonRepository comparisonRepository;
        private IMapper mapper;

        public ComparisonController(IComparisonRepository comparisonRepository,
            IProductRepository productRepository,
            IMapper mapper)
        {
            this.productRepository = productRepository;
            this.comparisonRepository = comparisonRepository;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var comparison = comparisonRepository.TryGetByUserId(User.Identity.Name);
            if (comparison is null)
                comparison = comparisonRepository.AddComparison(User.Identity.Name);
            return View(mapper.Map<ComparisonViewModel>(comparison));
        }

        public IActionResult Add(Guid productId,
            string controllerName = "Home",
            int pageNumber = 1)
        {
            var product = productRepository.TryGetById(productId);
            var userLogin = User.Identity.Name;
            if (userLogin is null || userLogin == string.Empty)
                return RedirectToAction(nameof(Index));
            comparisonRepository.AddProduct(product, userLogin);
            return RedirectToAction(nameof(Index), controllerName, new { pageNumber, id = productId });
        }

        public IActionResult Remove(Guid productId,
            string controllerName = "Home",
            int pageNumber = 1)
        {
            var product = productRepository.TryGetById(productId);
            var userLogin = User.Identity.Name;
            if (userLogin is null || userLogin == string.Empty)
                return RedirectToAction(nameof(Index));
            comparisonRepository.RemoveProduct(product, userLogin);
            return RedirectToAction(nameof(Index), controllerName, new { pageNumber, id = productId });
        }
    }
}
