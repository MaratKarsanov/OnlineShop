using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Administrator.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class UserController : Controller
    {
        private IRepository<UserViewModel> userRepository;
        private IRepository<Role> roleRepository;

        public UserController(IRepository<UserViewModel> userRepository,
            IRepository<Role> roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            if (userRepository.GetAll().Count == 0)
            {
                userRepository.Add(new UserViewModel()
                {
                    Role = roleRepository
                    .GetAll()
                    .FirstOrDefault(r => r.Name == "Administrator"),
                    AutorizationData = new AutorizationData()
                    {
                        Login = "MaratKarsanov",
                        Password = "marmar"
                    },
                    PersonalData = new DeliveryDataViewModel()
                    {
                        Name = "Marat",
                        Surname = "Karsanov",
                        Address = "Vatutina 37",
                        PhoneNumber = "9187080533",
                        EMail = "karsanov@mail.ru"
                    }
                });
            }
        }

        public IActionResult Index()
        {
            return View(userRepository.GetAll());
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
            var user = new UserViewModel();
            user.AutorizationData.Login = registrationData.Login;
            user.AutorizationData.Password = registrationData.Password;
            user.PersonalData.Name = registrationData.PersonalData.Name;
            user.PersonalData.Address = registrationData.PersonalData.Address;
            user.PersonalData.PhoneNumber = registrationData.PersonalData.PhoneNumber;
            user.PersonalData.Surname = registrationData.PersonalData.Surname;
            user.PersonalData.EMail = registrationData.PersonalData.EMail;
            userRepository.Add(user);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(Guid userId)
        {
            var user = userRepository.TryGetElementById(userId);
            if (user is null)
                throw new NullReferenceException("В репозитории нет пользователя с таким id");
            return View(user);
        }

        [HttpGet]
        public IActionResult EditData(Guid userId)
        {
            var user = userRepository.TryGetElementById(userId);
            if (user is null)
                throw new NullReferenceException("В репозитории нет пользователя с таким id");
            var userData = new EditUserData()
            {
                Login = user.AutorizationData.Login,
                Name = user.PersonalData.Name,
                Surname = user.PersonalData.Surname,
                Address = user.PersonalData.Address,
                EMail = user.PersonalData.EMail,
                PhoneNumber = user.PersonalData.PhoneNumber
            };
            ViewData["userId"] = user.Id;
            return View(userData);
        }

        [HttpPost]
        public IActionResult EditData(Guid userId, EditUserData newUserData)
        {
            if (!ModelState.IsValid)
                return View();
            var user = userRepository.TryGetElementById(userId);
            if (user is null)
                throw new NullReferenceException("В репозитории нет пользователя с таким id");
            user.AutorizationData.Login = newUserData.Login;
            user.PersonalData.Address = newUserData.Login;
            user.PersonalData.PhoneNumber = newUserData.PhoneNumber;
            user.PersonalData.Name = newUserData.Name;
            user.PersonalData.Surname = newUserData.Surname;
            user.PersonalData.EMail = newUserData.EMail;
            return RedirectToAction(nameof(Edit), new { userId });
        }

        [HttpGet]
        public IActionResult ChangePassword(Guid userId)
        {
            var user = userRepository.TryGetElementById(userId);
            if (user is null)
                throw new NullReferenceException("В репозитории нет пользователя с таким id");
            ViewData["userId"] = user.Id;
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangeUserPassword password, Guid userId)
        {
            if (!ModelState.IsValid)
                //return View();
                return Content(ModelState.ErrorCount.ToString());
            var user = userRepository.TryGetElementById(userId);
            if (user is null)
                throw new NullReferenceException("В репозитории нет пользователя с таким id");
            user.AutorizationData.Password = password.NewPassword;
            return RedirectToAction(nameof(Edit), new { userId });
        }

        [HttpGet]
        public IActionResult ChangeRole(Guid userId)
        {
            var user = userRepository.TryGetElementById(userId);
            if (user is null)
                throw new NullReferenceException("В репозитории нет пользователя с таким id");
            ViewData["userId"] = user.Id;
            ViewData["roleName"] = user.Role.Name;
            ViewData["login"] = user.AutorizationData.Login;
            return View(roleRepository
                .GetAll()
                .Where(r => r.Name != user.Role.Name));
        }

        [HttpPost]
        public IActionResult ChangeRole(Role newRole, Guid userId)
        {
            var user = userRepository.TryGetElementById(userId);
            if (user is null)
                throw new NullReferenceException("В репозитории нет пользователя с таким id");
            user.Role = newRole;
            return RedirectToAction(nameof(Edit), new { userId });
        }

        public IActionResult Delete(Guid userId)
        {
            userRepository.Remove(userId);
            return RedirectToAction(nameof(Index));
        }
    }
}
