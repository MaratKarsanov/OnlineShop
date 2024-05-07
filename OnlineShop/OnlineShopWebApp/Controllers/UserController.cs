using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Repositories.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository userRepository;

        public UserController(IUserRepository userRepository,
            IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            if (roleRepository.GetAll().FirstOrDefault(r => r.Name == "Administrator") is null)
            {
                roleRepository.Add(new Role() { Name = "Administrator" });
                roleRepository.Add(new Role() { Name = "User" });
            }
        }

        public IActionResult Index()
        {
            var userLogin = Request.Cookies["userLogin"];
            var user = userRepository.TryGetByLogin(userLogin);
            if (user is null)
                return View(null);
            return View(Helpers.MappingHelper.ToUserViewModel(user));
        }
    }
}