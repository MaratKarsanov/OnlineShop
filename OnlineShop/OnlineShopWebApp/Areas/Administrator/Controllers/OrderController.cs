using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area(Constants.AdministratorRoleName)]
    [Authorize(Roles = Constants.AdministratorRoleName)]
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
            return View(Helpers.MappingHelper.ToOrderViewModels(orderRepository.GetAll()));
        }

        [HttpGet]
        public IActionResult Edit(Guid orderId)
        {
            var order = orderRepository.TryGetOrderById(orderId);
            return View(Helpers.MappingHelper.ToOrderViewModel(order));
        }

        [HttpPost]
        public IActionResult UpdateStatus(Guid orderId, OrderStatus status)
        {
            orderRepository.UpdateStatus(status, orderId);
            return RedirectToAction(nameof(Index));
        }
    }
}
