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
            if (!ModelState.IsValid)
                return View("Index");
            var cart = cartRepository.TryGetElementById(Constants.UserId);
            newOrder.Products = cart.ToList();
            orderRepository.Add(newOrder);
            cart.Clear();
            return RedirectToAction("Success", new { order = newOrder.ToString() });
        }

        public IActionResult Success(string order)
        {
            return Content(order);
        }
    }
}