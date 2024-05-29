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

        public IActionResult Index()
        {
            return View(userManager.Users.Select(Helpers.Mapping.ToUserViewModel));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(RegistrationData registrationData)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Email = registrationData.UserName,
                    UserName = registrationData.UserName,
                    PhoneNumber = registrationData.PhoneNumber
                };
                var result = userManager.CreateAsync(user, registrationData.Password).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, Constants.UserRoleName).Wait();
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

        public IActionResult Edit(string login)
        {
            var user = userManager.FindByNameAsync(login).Result;
            return View(user.ToUserViewModel());
        }

        [HttpGet]
        public IActionResult EditData(string login)
        {
            var user = userManager.FindByNameAsync(login).Result;
            var userData = new EditUserDataViewModel()
            {
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber
            };
            ViewData["login"] = login;
            return View(userData);
        }

        [HttpPost]
        public IActionResult EditData(string login, EditUserDataViewModel newUserData)
        {
            if (!ModelState.IsValid)
                return View(newUserData);
            var user = userManager.FindByNameAsync(login).Result;
            user.PhoneNumber = newUserData.PhoneNumber;
            user.UserName = newUserData.UserName;
            if (newUserData.UploadedFile is not null
                && newUserData.UploadedFile.Length > 0)
            {
                user.ProfileImagePath = imagesProvider
                    .SaveFile(newUserData.UploadedFile, ImageFolders.Profiles);
            }
            userManager.UpdateAsync(user).Wait();
            return RedirectToAction(nameof(Edit), new { login });
        }

        [HttpGet]
        public IActionResult ChangePassword(string login)
        {
            ViewData["login"] = login;
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangeUserPasswordViewModel password, string login)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(ChangePassword));
            var user = userManager.FindByNameAsync(login).Result;
            var newHashPassword = userManager.PasswordHasher.HashPassword(user, password.NewPassword);
            user.PasswordHash = newHashPassword;
            userManager.UpdateAsync(user).Wait();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ChangeRole(string login)
        {
            var user = userManager.FindByNameAsync(login).Result;
            var userRoles = userManager.GetRolesAsync(user).Result;
            var roles = roleManager.Roles;
            ViewData["login"] = user.UserName;
            ViewBag.userRoles = userRoles.ToHashSet();
            return View(mapper.Map<List<RoleViewModel>>(roles));
        }

        [HttpPost]
        public IActionResult ChangeRole(Dictionary<string, bool> userRolesViewModels, string login)
        {
            if (!ModelState.IsValid)
                return View();
            var selectedRoles = userRolesViewModels.Select(x => x.Key);
            var user = userManager.FindByNameAsync(login).Result;
            var userRoles = userManager.GetRolesAsync(user).Result;
            userManager.RemoveFromRolesAsync(user, userRoles).Wait();
            userManager.AddToRolesAsync(user, selectedRoles).Wait();
            if (login == User.Identity.Name && !userRolesViewModels.ContainsKey("Administrator"))
                return RedirectToAction("Index", "Home", new { area = "" });
            return RedirectToAction(nameof(Edit), new { login });
        }

        public IActionResult DeleteProfileImage(string login)
        {
            var user = userManager.FindByNameAsync(login).Result;
            user.ProfileImagePath = "/images/Profiles/defaultAvatar.jpg";
            userManager.UpdateAsync(user).Wait();
            return RedirectToAction(nameof(Edit), new { login });
        }

        public IActionResult Delete(string login)
        {
            var user = userManager.FindByNameAsync(login).Result;
            userManager.DeleteAsync(user).Wait();
            cartRepository.Remove(login);
            favouritesRepository.RemoveFavourites(login);
            comparisonRepository.RemoveComparison(login);
            return RedirectToAction(nameof(Index));
        }
    }
}
