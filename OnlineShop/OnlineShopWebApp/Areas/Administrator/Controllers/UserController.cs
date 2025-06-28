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

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area(Constants.AdministratorRoleName)]
    [Authorize(Roles = Constants.AdministratorRoleName)]
    public class UserController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly IComparisonRepository _comparisonRepository;
        private readonly IFavouritesRepository _favouritesRepository;
        private readonly IProductRepository _productRepository;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly ImagesProvider _imagesProvider;

        public UserController(
            ICartRepository cartRepository,
            IComparisonRepository comparisonRepository,
            IFavouritesRepository favouritesRepository,
            IProductRepository productRepository,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper,
            ImagesProvider imagesProvider)
        {
            _comparisonRepository = comparisonRepository;
            _cartRepository = cartRepository;
            _favouritesRepository = favouritesRepository;
            _productRepository = productRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _imagesProvider = imagesProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(_userManager.Users.Select(Mapping.ToUserViewModel));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RegistrationData registrationData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new User()
                    {
                        Email = registrationData.UserName,
                        UserName = registrationData.UserName,
                        PhoneNumber = registrationData.PhoneNumber
                    };
                    var result = await _userManager.CreateAsync(user, registrationData.Password);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, Constants.UserRoleName);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                            ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                return View(registrationData);
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string login)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(login);
                return View(user.ToUserViewModel());
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditData(string login)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(login);
                var userData = new EditUserDataViewModel()
                {
                    UserName = user.UserName,
                    PhoneNumber = user.PhoneNumber
                };
                ViewData["login"] = login;
                return View(userData);
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditData(string login, EditUserDataViewModel newUserData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(newUserData);
                }
                var user = await _userManager.FindByNameAsync(login);
                user.PhoneNumber = newUserData.PhoneNumber;
                user.UserName = newUserData.UserName;
                if (newUserData.UploadedFile is not null
                    && newUserData.UploadedFile.Length > 0)
                {
                    user.ProfileImagePath = _imagesProvider
                        .SaveFile(newUserData.UploadedFile, ImageFolders.Profiles);
                }
                await _userManager.UpdateAsync(user);
                return RedirectToAction(nameof(Edit), new { login });
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword(string login)
        {
            ViewData["login"] = login;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangeUserPasswordViewModel password, string login)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(ChangePassword));
                }
                var user = await _userManager.FindByNameAsync(login);
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

        [HttpGet]
        public async Task<IActionResult> ChangeRole(string login)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(login);
                var userRoles = await _userManager.GetRolesAsync(user);
                var roles = _roleManager.Roles;
                ViewData["login"] = user.UserName;
                ViewBag.userRoles = userRoles.ToHashSet();
                return View(_mapper.Map<List<RoleViewModel>>(roles));
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangeRole(Dictionary<string, bool> userRolesViewModels, string login)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                var selectedRoles = userRolesViewModels.Select(x => x.Key);
                var user = await _userManager.FindByNameAsync(login);
                var userRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, userRoles);
                await _userManager.AddToRolesAsync(user, selectedRoles);
                if (login == User.Identity.Name && !userRolesViewModels.ContainsKey("Administrator"))
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                return RedirectToAction(nameof(Edit), new { login });
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProfileImage(string login)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(login);
                user.ProfileImagePath = "/images/Profiles/defaultAvatar.jpg";
                await _userManager.UpdateAsync(user);
                return RedirectToAction(nameof(Edit), new { login });
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string login)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(login);
                await _userManager.DeleteAsync(user);
                await _cartRepository.RemoveAsync(login);
                await _favouritesRepository.RemoveFavouritesAsync(login);
                await _comparisonRepository.RemoveComparisonAsync(login);
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
