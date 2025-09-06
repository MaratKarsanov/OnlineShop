using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    public class LogsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
