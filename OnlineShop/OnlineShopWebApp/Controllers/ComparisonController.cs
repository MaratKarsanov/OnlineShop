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

        public async Task<IActionResult> Index()
        {
            var comparison = await comparisonRepository.TryGetByUserIdAsync(User.Identity.Name);
            if (comparison is null)
                comparison = await comparisonRepository.AddComparisonAsync(User.Identity.Name);
            return View(mapper.Map<ComparisonViewModel>(comparison));
        }

        public async Task<IActionResult> Add(Guid productId,
            string controllerName = "Home",
            int pageNumber = 1)
        {
            var product = await productRepository.TryGetByIdAsync(productId);
            var userLogin = User.Identity.Name;
            if (userLogin is null || userLogin == string.Empty)
                return RedirectToAction(nameof(Index));
            await comparisonRepository.AddProductAsync(product, userLogin);
            return RedirectToAction(nameof(Index), controllerName, new { pageNumber, id = productId });
        }

        public async Task<IActionResult> Remove(Guid productId,
            string controllerName = "Home",
            int pageNumber = 1)
        {
            var product = await productRepository.TryGetByIdAsync(productId);
            var userLogin = User.Identity.Name;
            if (userLogin is null || userLogin == string.Empty)
                return RedirectToAction(nameof(Index));
            await comparisonRepository.RemoveProductAsync(product, userLogin);
            return RedirectToAction(nameof(Index), controllerName, new { pageNumber, id = productId });
        }
    }
}
