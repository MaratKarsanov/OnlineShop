using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AutorizationController : Controller
    {
        private IRepository<AutorizationData> autorizationDataRepository;

        public AutorizationController(IRepository<AutorizationData> autorizationDataRepository)
        {
            this.autorizationDataRepository = autorizationDataRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn(AutorizationData autorizationData)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Index));
            var autorizationDataFromRepository = autorizationDataRepository
                .FirstOrDefault(ad => ad.Login == autorizationData.Login);
            if (autorizationDataFromRepository is null)
            {
                ModelState.AddModelError("", "Пользователя с таким логином не существует!");
                return RedirectToAction(nameof(Index));
            }
            if (autorizationData.Password != autorizationDataFromRepository.Password)
            {
                ModelState.AddModelError("", "Введен неверный пароль!");
                return RedirectToAction(nameof(Index));
            }
            return Content(autorizationData.ToString());
        }
    }
}