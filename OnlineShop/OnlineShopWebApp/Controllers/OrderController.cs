using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;
using Serilog;

namespace OnlineShopWebApp.Controllers
{
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
            return View();
        }

        [HttpPost]
        public IActionResult Add(DeliveryDataViewModel deliveryDataVm)
        {
            if (!ModelState.IsValid)
                return View(nameof(Index));
            var cart = cartRepository.TryGetByUserId(Constants.Login);
            var deliveryData = Helpers.MappingHelper.ToDeliveryData(deliveryDataVm);
            //userRepository.AddDelivery(Constants.Login, deliveryData);
            var newOrder = new Order()
            {
                Login = Constants.Login,
                Items = cart.Items,
                DeliveryData = deliveryData
            };
            //orderRepository.Add(Constants.Login, cart.Items, deliveryData);
            orderRepository.Add(newOrder);
            cartRepository.Remove(Constants.Login);
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}