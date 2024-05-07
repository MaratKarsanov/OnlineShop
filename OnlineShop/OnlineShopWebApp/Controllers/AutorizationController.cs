using Microsoft.AspNetCore.Mvc;
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
            var cookieOptions = new CookieOptions();
            if (autorizationData.RememberMe)
                cookieOptions.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Append("userLogin", autorizationData.Login, cookieOptions);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SignOut()
        {
            var cookieOptions = new CookieOptions()
            {
                Expires = DateTime.Now.AddMonths(-1)
            };
            Response.Cookies.Append("userLogin", string.Empty, cookieOptions);
            return RedirectToAction("Index", "Home");
        }
    }
}