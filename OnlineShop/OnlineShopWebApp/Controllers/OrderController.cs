using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private ICartRepository cartRepository;
        private IOrderRepository orderRepository;

        public OrderController(ICartRepository cartRepository,
            IOrderRepository orderRepository)
        {
            this.cartRepository = cartRepository;
            this.orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(DeliveryData personalData)
        {
            if (!ModelState.IsValid)
                return View(nameof(Index));
            var cart = cartRepository.TryGetByUserId(Constants.UserId);
            var newOrder = new Order()
            {
                UserId = Constants.UserId,
                Items = cart.Items,
                PersonalData = personalData
            };
            orderRepository.Add(newOrder);
            cartRepository.Remove(Constants.UserId);
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}