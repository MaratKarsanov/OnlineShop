using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AutorizationController : Controller
    {
        private IUserRepository userRepository;

        public AutorizationController(IUserRepository userRepository)
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
                .FirstOrDefault(u => u.Login == autorizationData.Login);
            if (user is null)
            {
                ModelState.AddModelError("", "Пользователя с таким логином не существует!");
                return View(nameof(Index));
            }
            if (autorizationData.Password != user.Password)
            {
                ModelState.AddModelError("", "Введен неверный пароль!");
                return View(nameof(Index));
            }
            return Content(autorizationData.ToString());
        }
    }
}