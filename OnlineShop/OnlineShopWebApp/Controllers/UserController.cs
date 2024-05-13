using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Areas.Administrator.Models;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IUserRepository userRepository;
        private ICartRepository cartRepository;
        private IComparisonRepository comparisonRepository;
        private IFavouritesRepository favouritesRepository;
        private IProductRepository productRepository;

        public UserController(IUserRepository userRepository,
            IRoleRepository roleRepository,
            ICartRepository cartRepository,
            IComparisonRepository comparisonRepository,
            IFavouritesRepository favouritesRepository,
            IProductRepository productRepository)
        {
            this.userRepository = userRepository;
            this.comparisonRepository = comparisonRepository;
            this.cartRepository = cartRepository;
            this.favouritesRepository = favouritesRepository;
            this.productRepository = productRepository;
            if (roleRepository.GetAll().FirstOrDefault(r => r.Name == "Administrator") is null)
            {
                roleRepository.Add(new Role() { Name = "Administrator" });
                roleRepository.Add(new Role() { Name = "User" });
            }
        }

        public IActionResult Index()
        {
            var userLogin = Request.Cookies["userLogin"];
            var user = userRepository.TryGetByLogin(userLogin);
            if (user is null)
                return View(null);
            return View(Helpers.MappingHelper.ToUserViewModel(user));
        }

        [HttpGet]
        public IActionResult EditData()
        {
            var login = Request.Cookies["userLogin"];
            var user = userRepository.TryGetByLogin(login);
            if (user is null)
                throw new NullReferenceException("В репозитории нет пользователя с таким id");
            var userData = new EditUserDataViewModel()
            {
                Name = user.Name,
                Surname = user.Surname,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber
            };
            ViewData["login"] = login;
            return View(userData);
        }

        [HttpPost]
        public IActionResult EditData(EditUserData newUserData)
        {
            var login = Request.Cookies["userLogin"];
            if (!ModelState.IsValid)
                return View();
            userRepository.EditData(login, newUserData);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            ViewData["login"] = Request.Cookies["userLogin"]; 
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangeUserPasswordViewModel password)
        {
            var login = Request.Cookies["userLogin"];
            if (!ModelState.IsValid)
                return View();
            userRepository.ChangePassword(login, password.NewPassword);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete()
        {
            var login = Request.Cookies["userLogin"];
            userRepository.Remove(login);
            cartRepository.Remove(login);
            comparisonRepository.RemoveComparison(login);
            favouritesRepository.RemoveFavourites(login);
            productRepository.UpdateInFavouritesCondition(new HashSet<Product>());
            productRepository.UpdateInComparisonCondition(new HashSet<Product>());
            var cookieOptions = new CookieOptions()
            {
                Expires = DateTime.Now.AddMonths(-1)
            };
            Response.Cookies.Append("userLogin", string.Empty, cookieOptions);
            return RedirectToAction(nameof(Index));
        }
    }
}