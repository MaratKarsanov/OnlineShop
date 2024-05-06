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
            if (userRepository.GetAll().Count == 0)
            {
                userRepository.Add(new User()
                {
                    Role = roleRepository
                    .GetAll()
                    .FirstOrDefault(r => r.Name == "Administrator"),
                    Login = Constants.Login,
                    Password = "marmar",
                    Name = "Marat",
                    Surname = "Karsanov",
                    Address = "Vatutina 37",
                    PhoneNumber = "9187080533"
                });
            }
        }

        public IActionResult Index()
        {
            var user = userRepository.TryGetByLogin(Constants.Login);
            if (user is null)
                return View(null);
            return View(Helpers.MappingHelper.ToUserViewModel(user));
        }
    }
}
