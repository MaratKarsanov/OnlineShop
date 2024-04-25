using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private ICartRepository cartRepository;
        private IRepository<Order> orderRepository;

        public OrderController(ICartRepository cartRepository, 
            IRepository<Order> orderRepository)
        {
            this.cartRepository = cartRepository;
            this.orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Order newOrder)
        {
            if (!ModelState.IsValid)
                return View(nameof(Index));
            var cart = cartRepository.TryGetByUserId(Constants.UserId);
            newOrder.Products = Helpers.MappingHelper.ToCartViewModels(cart).ToList();
            orderRepository.Add(newOrder);
            cart.Items.Clear();
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}