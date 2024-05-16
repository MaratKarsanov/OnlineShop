using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShopWebApp.Areas.Administrator.Models;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area(Constants.AdministratorRoleName)]
    [Authorize(Roles = Constants.AdministratorRoleName)]
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View(Helpers.MappingHelper.ToRoleViewModels(roleManager.Roles));
        }

        public IActionResult Remove(string roleName)
        {
            var role = roleManager.FindByNameAsync(roleName).Result;
            if (role is not null)
                roleManager.DeleteAsync(role).Wait();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(RoleViewModel newRole)
        {
            var result = roleManager.CreateAsync(new IdentityRole() { Name = newRole.Name}).Result;
            if (result.Succeeded)
                return RedirectToAction(nameof(Index));
            else
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(newRole);
        }
    }
}
