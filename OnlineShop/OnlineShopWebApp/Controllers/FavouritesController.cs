using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class FavouritesController : Controller
    {
        private IProductRepository productRepository;
        private readonly IFavouritesRepository favouritesRepository;
        private IMapper mapper;

        public FavouritesController(IProductRepository productRepository,
            IFavouritesRepository favouritesRepository,
            IMapper mapper)
        {
            this.productRepository = productRepository;
            this.favouritesRepository = favouritesRepository;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var favourites = favouritesRepository.TryGetByUserName(User.Identity.Name);
            if (favourites is null)
                favourites = favouritesRepository.AddFavourites(User.Identity.Name);
            return View(mapper.Map<List<ProductViewModel>>(favourites.Items));
        }

        public IActionResult Add(Guid productId,
            string controllerName = "Home", 
            int pageNumber = 1)
        {
            var product = productRepository.TryGetById(productId);
            favouritesRepository.AddProduct(product, User.Identity.Name);
            return RedirectToAction(nameof(Index), controllerName, new { pageNumber, id = productId });
        }

        public IActionResult Remove(Guid productId,
            string controllerName = "Home",
            int pageNumber = 1)
        {
            var product = productRepository.TryGetById(productId);
            favouritesRepository.RemoveProduct(product, User.Identity.Name);
            return RedirectToAction(nameof(Index), controllerName, new {pageNumber, id = productId});
        }
    }
}