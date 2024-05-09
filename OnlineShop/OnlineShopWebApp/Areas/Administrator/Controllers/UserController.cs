using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Areas.Administrator.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class UserController : Controller
    {
        private IUserRepository userRepository;
        private IRoleRepository roleRepository;
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
            this.roleRepository = roleRepository;
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
            return View(Helpers.MappingHelper.ToUserViewModels(userRepository.GetAll()));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(RegistrationData registrationData)
        {
            if (!ModelState.IsValid)
                return View();
            var user = new User()
            {
                Role = roleRepository
                    .GetAll()
                    .FirstOrDefault(r => r.Name == "User"),
                Login = registrationData.Login,
                Password = registrationData.Password,
                Name = registrationData.Name,
                Address = registrationData.Address,
                PhoneNumber = registrationData.PhoneNumber,
                Surname = registrationData.Surname,
            };
            userRepository.Add(user);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(string login)
        {
            var user = userRepository.TryGetByLogin(login);
            if (user is null)
                throw new NullReferenceException("В репозитории нет пользователя с таким id");
            return View(Helpers.MappingHelper.ToUserViewModel(user));
        }

        [HttpGet]
        public IActionResult EditData(string login)
        {
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
        public IActionResult EditData(string login, EditUserData newUserData)
        {
            if (!ModelState.IsValid)
                return View();
            userRepository.EditData(login, newUserData);
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
                return View();
            userRepository.ChangePassword(login, password.NewPassword);
            return RedirectToAction(nameof(Edit), new { login });
        }

        [HttpGet]
        public IActionResult ChangeRole(string login)
        {
            var user = userRepository.TryGetByLogin(login);
            if (user is null)
                throw new NullReferenceException("В репозитории нет пользователя с таким id");
            ViewData["login"] = user.Login;
            ViewData["roleName"] = user.Role.Name;
            return View(Helpers.MappingHelper.ToRoleViewModels(roleRepository
                .GetAll()
                .Where(r => r.Name != user.Role.Name)));
        }

        [HttpPost]
        public IActionResult ChangeRole(Role newRole, string login)
        {
            if (!ModelState.IsValid)
                return View();
            userRepository.ChangeRole(login, newRole.Name);
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
