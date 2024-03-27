using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class OrderController : Controller
    {
        private IRepository<Cart> cartRepository;
        private IRepository<Order> orderRepository;

        public OrderController(IRepository<Cart> cartRepository, IRepository<Order> orderRepository)
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
            var cart = cartRepository.TryGetElementById(Constants.UserId);
            if (cart is null || cart.Count == 0)
                return RedirectToAction("Index");
            newOrder.Products = cart.ToList();
            orderRepository.Add(newOrder);
            cart.Clear();
            return View("Success", newOrder);
        }
    }
}
