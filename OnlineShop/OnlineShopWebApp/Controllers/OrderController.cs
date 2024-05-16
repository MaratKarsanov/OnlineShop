using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private ICartRepository cartRepository;
        private IOrderRepository orderRepository;
        private UserManager<User> userManager;

        public OrderController(ICartRepository cartRepository,
            IOrderRepository orderRepository,
            UserManager<User> userManager)
        {
            this.cartRepository = cartRepository;
            this.orderRepository = orderRepository;
            this.userManager = userManager;
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
            var login = User.Identity.Name;
            var cart = cartRepository.TryGetByLogin(login);
            var deliveryData = Helpers.MappingHelper.ToDeliveryData(deliveryDataVm);
            var user = userManager.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            user.DeliveryDatas.Add(deliveryData);
            userManager.UpdateAsync(user).Wait();
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