using AutoMapper;
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
        private IMapper mapper;

        public RoleController(RoleManager<IdentityRole> roleManager,
            IMapper mapper)
        {
            this.roleManager = roleManager;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(mapper.Map<List<RoleViewModel>>(roleManager.Roles));
        }

        public async Task<IActionResult> Remove(string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role is not null)
                await roleManager.DeleteAsync(role);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RoleViewModel newRole)
        {
            var result = await roleManager.CreateAsync(new IdentityRole() { Name = newRole.Name});
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
