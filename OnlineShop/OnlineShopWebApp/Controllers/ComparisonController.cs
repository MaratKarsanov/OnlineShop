using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;
using Serilog;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class ComparisonController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IComparisonRepository _comparisonRepository;
        private readonly IMapper _mapper;

        public ComparisonController(
            IComparisonRepository comparisonRepository,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _comparisonRepository = comparisonRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var comparison = await _comparisonRepository.TryGetByUserIdAsync(User.Identity.Name);
                if (comparison is null)
                {
                    comparison = await _comparisonRepository.AddComparisonAsync(User.Identity.Name);
                }
                return View(_mapper.Map<ComparisonViewModel>(comparison));
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        public async Task<IActionResult> Add(
            Guid productId,
            string controllerName = "Home",
            int pageNumber = 1)
        {
            try
            {
                var product = await _productRepository.TryGetByIdAsync(productId);
                var userLogin = User.Identity.Name;
                if (userLogin is null || userLogin == string.Empty)
                {
                    return RedirectToAction(nameof(Index));
                }
                await _comparisonRepository.AddProductAsync(product, userLogin);
                return RedirectToAction(nameof(Index), controllerName, new { pageNumber, id = productId });
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        public async Task<IActionResult> Remove(Guid productId,
            string controllerName = "Home",
            int pageNumber = 1)
        {
            try
            {
                var product = await _productRepository.TryGetByIdAsync(productId);
                var userLogin = User.Identity.Name;
                if (userLogin is null || userLogin == string.Empty)
                {
                    return RedirectToAction(nameof(Index));
                }
                await _comparisonRepository.RemoveProductAsync(product, userLogin);
                return RedirectToAction(nameof(Index), controllerName, new { pageNumber, id = productId });
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }
    }
}
