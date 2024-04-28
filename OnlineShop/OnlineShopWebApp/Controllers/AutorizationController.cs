using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AutorizationController : Controller
    {
        private IRepository<User> userRepository;

        public AutorizationController(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn(AutorizationData autorizationData)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Index));
            var user = userRepository
                .GetAll()
                .FirstOrDefault(u => u.AutorizationData.Login == autorizationData.Login);
            if (user is null)
            {
                ModelState.AddModelError("", "Пользователя с таким логином не существует!");
                return View(nameof(Index));
            }
            if (autorizationData.Password != user.AutorizationData.Password)
            {
                ModelState.AddModelError("", "Введен неверный пароль!");
                return View(nameof(Index));
            }
            return Content(autorizationData.ToString());
        }
    }
}