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
            return View("Index");
        }

        [HttpPost]
        public IActionResult Add(Order newOrder)
        {
            var products = cartRepository.TryGetElementById(Constants.UserId).ToList();
            newOrder.Products = products;
            orderRepository.Add(newOrder);
            cartRepository.Remove(Constants.UserId);
            return View("Success", newOrder);
        }
    }
}
