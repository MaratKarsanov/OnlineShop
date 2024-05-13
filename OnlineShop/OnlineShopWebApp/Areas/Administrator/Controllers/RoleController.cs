using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Repositories.Interfaces;
using System.Data;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area(Constants.AdministratorRoleName)]
    [Authorize(Roles = Constants.AdministratorRoleName)]
    public class RoleController : Controller
    {
        private IRoleRepository roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public IActionResult Index()
        {
            return View(Helpers.MappingHelper.ToRoleViewModels(roleRepository.GetAll()));
        }

        public IActionResult Remove(string roleName)
        {
            roleRepository.Remove(roleName);
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
            {
                ModelState.AddModelError("", "Такая роль уже существует");
                return View();
            }
            if (!ModelState.IsValid)
                return View();
            roleRepository.Add(newRole);
            return RedirectToAction(nameof(Index));
        }
    }
}
