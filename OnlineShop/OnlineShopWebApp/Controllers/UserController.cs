using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Areas.Administrator.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
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
        private IMapper mapper;
        private ImagesProvider imagesProvider;

        public UserController(UserManager<User> userManager,
            ICartRepository cartRepository,
            IComparisonRepository comparisonRepository,
            IFavouritesRepository favouritesRepository,
            IProductRepository productRepository,
            IMapper mapper,
            ImagesProvider imagesProvider)
        {
            this.userManager = userManager;
            this.comparisonRepository = comparisonRepository;
            this.cartRepository = cartRepository;
            this.favouritesRepository = favouritesRepository;
            this.productRepository = productRepository;
            this.mapper = mapper;
            this.imagesProvider = imagesProvider;
        }

        public IActionResult Index()
        {
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            return View(user.ToUserViewModel());
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
            if (newUserData.UploadedFile is not null
                && newUserData.UploadedFile.Length > 0)
            {
                user.ProfileImagePath = imagesProvider
                    .SaveFile(newUserData.UploadedFile, ImageFolders.Profiles);
            }
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

        public IActionResult DeleteProfileImage()
        {
            var user = userManager.FindByNameAsync(User.Identity.Name).Result;
            user.ProfileImagePath = "/images/Profiles/defaultAvatar.jpg";
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