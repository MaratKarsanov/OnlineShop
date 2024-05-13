using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Areas.Administrator.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area(Constants.AdministratorRoleName)]
    [Authorize(Roles = Constants.AdministratorRoleName)]
    public class UserController : Controller
    {
        private IUserRepository userRepository;
        private IRoleRepository roleRepository;
        private ICartRepository cartRepository;
        private IComparisonRepository comparisonRepository;
        private IFavouritesRepository favouritesRepository;
        private IProductRepository productRepository;
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;

        public UserController(IUserRepository userRepository,
            IRoleRepository roleRepository,
            ICartRepository cartRepository,
            IComparisonRepository comparisonRepository,
            IFavouritesRepository favouritesRepository,
            IProductRepository productRepository,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.comparisonRepository = comparisonRepository;
            this.cartRepository = cartRepository;
            this.favouritesRepository = favouritesRepository;
            this.productRepository = productRepository;
            this.userManager = userManager;
            this.roleManager = roleManager;
            if (roleRepository.GetAll().FirstOrDefault(r => r.Name == "Administrator") is null)
            {
                roleRepository.Add(new Role() { Name = "Administrator" });
                roleRepository.Add(new Role() { Name = "User" });
            }
        }

        public IActionResult Index()
        {
            return View(Helpers.MappingHelper.ToUserViewModels(userManager.Users));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(RegistrationData registrationData)
        {
            //if (!ModelState.IsValid)
            //    return View();
            //var user = new User()
            //{
            //    Role = roleRepository
            //        .GetAll()
            //        .FirstOrDefault(r => r.Name == "User"),
            //    UserName = registrationData.UserName,
            //    PasswordHash = registrationData.Password.GetHashCode().ToString(),
            //    Name = registrationData.Name,
            //    Address = registrationData.Address,
            //    PhoneNumber = registrationData.PhoneNumber,
            //    Surname = registrationData.Surname,
            //};
            //userRepository.Add(user);
            //return RedirectToAction(nameof(Index));
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
            return View(Helpers.MappingHelper.ToUserViewModel(user));
        }

        [HttpGet]
        public IActionResult EditData(string login)
        {
            var user = userManager.FindByNameAsync(login).Result;
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
        public IActionResult EditData(string login, EditUserData newUserData)
        {
            //if (!ModelState.IsValid)
            //    return View();
            //userRepository.EditData(login, newUserData);
            //return RedirectToAction(nameof(Edit), new { login });
            if (ModelState.IsValid)
            {
                var user = userManager.FindByNameAsync(login).Result;
                user.PhoneNumber = newUserData.PhoneNumber;
                user.Name = newUserData.Name;
                userManager.UpdateAsync(user).Wait();
                return RedirectToAction(nameof(Index));
            }
            return View(newUserData);
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
            //if (!ModelState.IsValid)
            //    return View();
            //userRepository.ChangePassword(login, password.NewPassword);
            //return RedirectToAction(nameof(Edit), new { login });
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
            var roles = roleManager.Roles.Select(r => r.Name).ToHashSet();
            ViewData["login"] = user.UserName;
            ViewData["roleName"] = user.Role.Name;
            return View(Helpers.MappingHelper.ToRoleViewModels(roles
                .Where(r => !userRoles.Contains(r))));
        }

        [HttpPost]
        public IActionResult ChangeRole(RoleViewModel newRole, string login)
        {
            if (!ModelState.IsValid)
                return View();
            var user = userManager.FindByNameAsync(login).Result;
            var role = roleManager.Roles.FirstOrDefault(r => r.Name == newRole.Name);
            var userRoles = userManager.GetRolesAsync(user).Result;
            return RedirectToAction(nameof(Edit), new { login });
        }

        public IActionResult Delete(string login)
        {
            userRepository.Remove(login);
            cartRepository.Remove(login);
            comparisonRepository.RemoveComparison(login);
            favouritesRepository.RemoveFavourites(login);
            if (login == Request.Cookies["userLogin"])
            {
                productRepository.UpdateInFavouritesCondition(new HashSet<Product>());
                productRepository.UpdateInComparisonCondition(new HashSet<Product>());
                var cookieOptions = new CookieOptions()
                {
                    Expires = DateTime.Now.AddMonths(-1)
                };
                Response.Cookies.Append("userLogin", string.Empty, cookieOptions);
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
