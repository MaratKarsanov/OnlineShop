using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Areas.Administrator.Models;
using Serilog;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private UserManager<User> userManager;
        private ICartRepository cartRepository;
        private IComparisonRepository comparisonRepository;
        private IFavouritesRepository favouritesRepository;
        private IProductRepository productRepository;

        public UserController(UserManager<User> userManager,
            ICartRepository cartRepository,
            IComparisonRepository comparisonRepository,
            IFavouritesRepository favouritesRepository,
            IProductRepository productRepository)
        {
            this.userManager = userManager;
            this.comparisonRepository = comparisonRepository;
            this.cartRepository = cartRepository;
            this.favouritesRepository = favouritesRepository;
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            return View(Helpers.MappingHelper.ToUserViewModel(user));
        }

        [HttpGet]
        public IActionResult EditData()
        {
            var name = User.Identity.Name;
            var user = userManager.FindByNameAsync(name).Result;
            var userData = new EditUserDataViewModel()
            {
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber
            };
            return View(userData);
        }

        [HttpPost]
        public IActionResult EditData(EditUserDataViewModel newUserData)
        {
            if (!ModelState.IsValid)
                return View(newUserData);
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            user.PhoneNumber = newUserData.PhoneNumber;
            user.UserName = newUserData.UserName;
            userManager.UpdateAsync(user).Wait();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangeUserPasswordViewModel password)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(ChangePassword));
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            var newHashPassword = userManager.PasswordHasher.HashPassword(user, password.NewPassword);
            user.PasswordHash = newHashPassword;
            userManager.UpdateAsync(user).Wait();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete()
        {
            var name = User.Identity.Name;
            var user = userManager.FindByNameAsync(name).Result;
            userManager.DeleteAsync(user).Wait();
            cartRepository.Remove(name);
            favouritesRepository.RemoveFavourites(name);
            comparisonRepository.RemoveComparison(name);
            return RedirectToAction(nameof(Index));
        }
    }
}