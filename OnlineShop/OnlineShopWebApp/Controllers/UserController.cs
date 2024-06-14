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
        private IOrderRepository orderRepository;
        private IMapper mapper;
        private ImagesProvider imagesProvider;

        public UserController(UserManager<User> userManager,
            ICartRepository cartRepository,
            IComparisonRepository comparisonRepository,
            IFavouritesRepository favouritesRepository,
            IProductRepository productRepository,
            IMapper mapper,
            ImagesProvider imagesProvider,
            IOrderRepository orderRepository)
        {
            this.userManager = userManager;
            this.comparisonRepository = comparisonRepository;
            this.cartRepository = cartRepository;
            this.favouritesRepository = favouritesRepository;
            this.productRepository = productRepository;
            this.mapper = mapper;
            this.imagesProvider = imagesProvider;
            this.orderRepository = orderRepository;
        }

        public async Task<IActionResult> Index()
        {
            var userName = User.Identity.Name;
            var user = userManager.FindByNameAsync(userName).Result;
            var userOrders = (await orderRepository.GetAllAsync()).Where(o => o.UserName == userName).ToList();
            ViewBag.Orders = userOrders;
            return View(user.ToUserViewModel());
        }

        [HttpGet]
        public async Task<IActionResult> EditData()
        {
            var name = User.Identity.Name;
            var user = await userManager.FindByNameAsync(name);
            var userData = new EditUserDataViewModel()
            {
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber
            };
            return View(userData);
        }

        [HttpPost]
        public async Task<IActionResult> EditData(EditUserDataViewModel newUserData)
        {
            if (!ModelState.IsValid)
                return View(newUserData);
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            user.PhoneNumber = newUserData.PhoneNumber;
            user.UserName = newUserData.UserName;
            if (newUserData.UploadedFile is not null
                && newUserData.UploadedFile.Length > 0)
            {
                user.ProfileImagePath = imagesProvider
                    .SaveFile(newUserData.UploadedFile, ImageFolders.Profiles);
            }
            await userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangeUserPasswordViewModel password)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(ChangePassword));
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var newHashPassword = userManager.PasswordHasher.HashPassword(user, password.NewPassword);
            user.PasswordHash = newHashPassword;
            await userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteProfileImage()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            user.ProfileImagePath = "/images/Profiles/defaultAvatar.jpg";
            await userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete()
        {
            var name = User.Identity.Name;
            var user = await userManager.FindByNameAsync(name);
            await userManager.DeleteAsync(user);
            await cartRepository.RemoveAsync(name);
            await favouritesRepository.RemoveFavouritesAsync(name);
            await comparisonRepository.RemoveComparisonAsync(name);
            return RedirectToAction(nameof(Index));
        }
    }
}