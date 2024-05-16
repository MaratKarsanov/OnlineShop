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

        public OrderController(ICartRepository cartRepository,
            IOrderRepository orderRepository)
        {
            this.cartRepository = cartRepository;
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
