using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class OrderController : Controller
    {
        private IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
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
