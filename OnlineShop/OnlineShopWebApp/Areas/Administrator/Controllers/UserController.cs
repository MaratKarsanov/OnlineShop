using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
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

        public UserController(IUserRepository userRepository,
            IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            if (roleRepository.GetAll().FirstOrDefault(r => r.Name == "Administrator") is null)
            {
                roleRepository.Add(new Role() { Name = "Administrator" });
                roleRepository.Add(new Role() { Name = "User" });
            }
            if (userRepository.GetAll().Count == 0)
            {
                userRepository.Add(new User()
                {
                    Role = roleRepository
                    .GetAll()
                    .FirstOrDefault(r => r.Name == "Administrator"),
                    Login = Constants.Login,
                    Password = "marmar",
                    Name = "Marat",
                    Surname = "Karsanov",
                    Address = "Vatutina 37",
                    PhoneNumber = "9187080533"
                });
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
            var user = userRepository.TryGetByLogin(login);
            if (user is null)
                throw new NullReferenceException("В репозитории нет пользователя с таким id");
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
            return RedirectToAction(nameof(Index));
        }
    }
}
