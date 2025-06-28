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
        private readonly UserManager<User> _userManager;
        private readonly ICartRepository _cartRepository;
        private readonly IComparisonRepository _comparisonRepository;
        private readonly IFavouritesRepository _favouritesRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ImagesProvider _imagesProvider;

        public UserController(
            UserManager<User> userManager,
            ICartRepository cartRepository,
            IComparisonRepository comparisonRepository,
            IFavouritesRepository favouritesRepository,
            IProductRepository productRepository,
            IMapper mapper,
            ImagesProvider imagesProvider,
            IOrderRepository orderRepository)
        {
            _userManager = userManager;
            _comparisonRepository = comparisonRepository;
            _cartRepository = cartRepository;
            _favouritesRepository = favouritesRepository;
            _productRepository = productRepository;
            _mapper = mapper;
            _imagesProvider = imagesProvider;
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var userName = User.Identity.Name;
                var user = _userManager.FindByNameAsync(userName).Result;
                var userOrders = (await _orderRepository.GetAllAsync())
                    .Where(o => o.UserName == userName)
                    .ToList();
                ViewBag.Orders = userOrders;
                return View(user.ToUserViewModel());
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditData()
        {
            try
            {
                var name = User.Identity.Name;
                var user = await _userManager.FindByNameAsync(name);
                var userData = new EditUserDataViewModel()
                {
                    UserName = user.UserName,
                    PhoneNumber = user.PhoneNumber
                };
                return View(userData);
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditData(EditUserDataViewModel newUserData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(newUserData);
                }
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.PhoneNumber = newUserData.PhoneNumber;
                user.UserName = newUserData.UserName;
                if (newUserData.UploadedFile is not null
                    && newUserData.UploadedFile.Length > 0)
                {
                    user.ProfileImagePath = _imagesProvider
                        .SaveFile(newUserData.UploadedFile, ImageFolders.Profiles);
                }
                await _userManager.UpdateAsync(user);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangeUserPasswordViewModel password)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(ChangePassword));
                }
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var newHashPassword = _userManager.PasswordHasher.HashPassword(user, password.NewPassword);
                user.PasswordHash = newHashPassword;
                await _userManager.UpdateAsync(user);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProfileImage()
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.ProfileImagePath = "/images/Profiles/defaultAvatar.jpg";
                await _userManager.UpdateAsync(user);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            try
            {
                var name = User.Identity.Name;
                var user = await _userManager.FindByNameAsync(name);
                await _userManager.DeleteAsync(user);
                await _cartRepository.RemoveAsync(name);
                await _favouritesRepository.RemoveFavouritesAsync(name);
                await _comparisonRepository.RemoveComparisonAsync(name);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }
    }
}