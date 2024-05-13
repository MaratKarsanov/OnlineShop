using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;
using Serilog;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private ICartRepository cartRepository;
        private IOrderRepository orderRepository;
        private IUserRepository userRepository;
        private IRoleRepository roleRepository;

        public OrderController(ICartRepository cartRepository,
            IOrderRepository orderRepository,
            IUserRepository userRepository,
            IRoleRepository roleRepository)
        {
            this.cartRepository = cartRepository;
            this.orderRepository = orderRepository;
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
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
                    UserName = Request.Cookies["userLogin"],
                    PasswordHash = "marmar".GetHashCode().ToString(),
                    Name = "Marat",
                    Surname = "Karsanov",
                    Address = "Vatutina 37",
                    PhoneNumber = "9187080533"
                });
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(DeliveryDataViewModel deliveryDataVm)
        {
            if (!ModelState.IsValid)
                return View(nameof(Index));
            var login = Request.Cookies["userLogin"];
            var cart = cartRepository.TryGetByLogin(login);
            var deliveryData = Helpers.MappingHelper.ToDeliveryData(deliveryDataVm);
            userRepository.AddDelivery(login, deliveryData);
            var newOrder = new Order()
            {
                Login = login,
                Items = cart.Items,
                DeliveryData = deliveryData
            };
            orderRepository.Add(newOrder);
            cartRepository.Remove(login);
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}