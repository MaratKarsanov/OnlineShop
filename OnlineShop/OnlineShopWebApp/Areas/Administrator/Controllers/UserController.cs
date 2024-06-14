using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Areas.Administrator.Models;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area(Constants.AdministratorRoleName)]
    [Authorize(Roles = Constants.AdministratorRoleName)]
    public class UserController : Controller
    {
        private ICartRepository cartRepository;
        private IComparisonRepository comparisonRepository;
        private IFavouritesRepository favouritesRepository;
        private IProductRepository productRepository;
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;
        private IMapper mapper;
        private ImagesProvider imagesProvider;

        public UserController(ICartRepository cartRepository,
            IComparisonRepository comparisonRepository,
            IFavouritesRepository favouritesRepository,
            IProductRepository productRepository,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper,
            ImagesProvider imagesProvider)
        {
            this.comparisonRepository = comparisonRepository;
            this.cartRepository = cartRepository;
            this.favouritesRepository = favouritesRepository;
            this.productRepository = productRepository;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
            this.imagesProvider = imagesProvider;
        }

        public async Task<IActionResult> Index()
        {
            return View(userManager.Users.Select(Mapping.ToUserViewModel));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RegistrationData registrationData)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    Email = registrationData.UserName,
                    UserName = registrationData.UserName,
                    PhoneNumber = registrationData.PhoneNumber
                };
                var result = await userManager.CreateAsync(user, registrationData.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Constants.UserRoleName);
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

        public async Task<IActionResult> Edit(string login)
        {
            var user = await userManager.FindByNameAsync(login);
            return View(user.ToUserViewModel());
        }

        [HttpGet]
        public async Task<IActionResult> EditData(string login)
        {
            var user = await userManager.FindByNameAsync(login);
            var userData = new EditUserDataViewModel()
            {
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber
            };
            ViewData["login"] = login;
            return View(userData);
        }

        [HttpPost]
        public async Task<IActionResult> EditData(string login, EditUserDataViewModel newUserData)
        {
            if (!ModelState.IsValid)
                return View(newUserData);
            var user = await userManager.FindByNameAsync(login);
            user.PhoneNumber = newUserData.PhoneNumber;
            user.UserName = newUserData.UserName;
            if (newUserData.UploadedFile is not null
                && newUserData.UploadedFile.Length > 0)
            {
                user.ProfileImagePath = imagesProvider
                    .SaveFile(newUserData.UploadedFile, ImageFolders.Profiles);
            }
            await userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Edit), new { login });
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
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(ChangePassword));
            var user = await userManager.FindByNameAsync(login);
            var newHashPassword = userManager.PasswordHasher.HashPassword(user, password.NewPassword);
            user.PasswordHash = newHashPassword;
            await userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ChangeRole(string login)
        {
            var user = await userManager.FindByNameAsync(login);
            var userRoles = await userManager.GetRolesAsync(user);
            var roles = roleManager.Roles;
            ViewData["login"] = user.UserName;
            ViewBag.userRoles = userRoles.ToHashSet();
            return View(mapper.Map<List<RoleViewModel>>(roles));
        }

        [HttpPost]
        public async Task<IActionResult> ChangeRole(Dictionary<string, bool> userRolesViewModels, string login)
        {
            if (!ModelState.IsValid)
                return View();
            var selectedRoles = userRolesViewModels.Select(x => x.Key);
            var user = await userManager.FindByNameAsync(login);
            var userRoles = await userManager.GetRolesAsync(user);
            await userManager.RemoveFromRolesAsync(user, userRoles);
            await userManager.AddToRolesAsync(user, selectedRoles);
            if (login == User.Identity.Name && !userRolesViewModels.ContainsKey("Administrator"))
                return RedirectToAction("Index", "Home", new { area = "" });
            return RedirectToAction(nameof(Edit), new { login });
        }

        public async Task<IActionResult> DeleteProfileImage(string login)
        {
            var user = await userManager.FindByNameAsync(login);
            user.ProfileImagePath = "/images/Profiles/defaultAvatar.jpg";
            await userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Edit), new { login });
        }

        public async Task<IActionResult> Delete(string login)
        {
            var user = await userManager.FindByNameAsync(login);
            await userManager.DeleteAsync(user);
            await cartRepository.RemoveAsync(login);
            await favouritesRepository.RemoveFavouritesAsync(login);
            await comparisonRepository.RemoveComparisonAsync(login);
            return RedirectToAction(nameof(Index));
        }
    }
}
