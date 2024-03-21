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

        public IActionResult Index(Guid orderId)
        {
            var order = orderRepository.TryGetElementById(orderId);
            if (order is null)
                return View("Index", null);
            return View(order);
        }

        public IActionResult AddOrder(string name, 
            string surname, 
            string address,
            string email, 
            string phoneNumber, 
            string comments)
        {
            var products = cartRepository.TryGetElementById(Constants.UserId).ToList();
            var newOrder = new Order(products,
                new User(Constants.UserId, $"{name} {surname}"),
                address,
                email,
                phoneNumber,
                comments);
            orderRepository.Add(newOrder);
            cartRepository.Remove(cartRepository.TryGetElementById(Constants.UserId));
            return RedirectToAction("Index", new {orderId = newOrder.Id});
        }
    }
}
