using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Areas.Administrator.Models;
using System.Data;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class RoleController : Controller
    {
        private IRepository<Role> roleRepository;

        public RoleController(IRepository<Role> roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public IActionResult Index()
        {
            return View(roleRepository.GetAll());
        }

        public IActionResult Remove(Guid roleId)
        {
            roleRepository.Remove(roleId);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Role newRole)
        {
            if (roleRepository.GetAll().Where(r => r.Name == newRole.Name).Count() > 0)
                ModelState.AddModelError("", "Такая роль уже существует");
            if (!ModelState.IsValid)
                return View();
            newRole.Id = Guid.NewGuid();
            roleRepository.Add(newRole);
            return RedirectToAction(nameof(Index));
        }
    }
}
