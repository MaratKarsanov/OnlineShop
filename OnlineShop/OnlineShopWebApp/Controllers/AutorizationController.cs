using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class AutorizationController : Controller
    {
        private IUserRepository userRepository;
        private IComparisonRepository comparisonRepository;
        private IFavouritesRepository favouritesRepository;
        private IProductRepository productRepository;
        private ICartRepository cartRepository;

        public AutorizationController(IUserRepository userRepository,
            IComparisonRepository comparisonRepository,
            IFavouritesRepository favouritesRepository,
            IProductRepository productRepository,
            ICartRepository cartRepository)
        {
            this.userRepository = userRepository;
            this.favouritesRepository = favouritesRepository;
            this.comparisonRepository = comparisonRepository;
            this.productRepository = productRepository;
            this.cartRepository = cartRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn(AutorizationData autorizationData)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Index));
            var user = userRepository
                .GetAll()
                .FirstOrDefault(u => u.Login == autorizationData.Login);
            if (user is null)
            {
                ModelState.AddModelError("", "Пользователя с таким логином не существует!");
                return View(nameof(Index));
            }
            if (autorizationData.Password != user.Password)
            {
                ModelState.AddModelError("", "Введен неверный пароль!");
                return View(nameof(Index));
            }
            var cookieOptions = new CookieOptions();
            if (autorizationData.RememberMe)
                cookieOptions.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Append("userLogin", autorizationData.Login, cookieOptions);
            var favourites = favouritesRepository.TryGetByUserId(autorizationData.Login);
            if (favourites is null)
                favourites = favouritesRepository.AddFavourites(autorizationData.Login);
            var comparison = comparisonRepository.TryGetByUserId(autorizationData.Login);
            if (comparison is null)
                comparison = comparisonRepository.AddComparison(autorizationData.Login);
            var cart = cartRepository.TryGetByLogin(autorizationData.Login);
            if (cart is null)
                cart = cartRepository.AddCart(autorizationData.Login);
            var favouriteProducts = favourites.Items.ToHashSet();
            var comparisonProducts = comparison.Items.ToHashSet();
            productRepository.UpdateInFavouritesCondition(favouriteProducts);
            productRepository.UpdateInComparisonCondition(comparisonProducts);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SignOut()
        {
            productRepository.UpdateInFavouritesCondition(new HashSet<Product>());
            productRepository.UpdateInComparisonCondition(new HashSet<Product>());
            var cookieOptions = new CookieOptions()
            {
                Expires = DateTime.Now.AddMonths(-1)
            };
            Response.Cookies.Append("userLogin", string.Empty, cookieOptions);
            return RedirectToAction("Index", "Home");
        }
    }
}