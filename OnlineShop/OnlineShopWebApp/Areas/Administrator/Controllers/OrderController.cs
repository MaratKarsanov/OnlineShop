using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area(Constants.AdministratorRoleName)]
    [Authorize(Roles = Constants.AdministratorRoleName)]
    public class OrderController : Controller
    {
        private ICartRepository cartRepository;
        private IOrderRepository orderRepository;
        private IMapper mapper;

        public OrderController(ICartRepository cartRepository,
            IOrderRepository orderRepository,
            IMapper mapper)
        {
            this.cartRepository = cartRepository;
            this.mapper = mapper;
            this.orderRepository = orderRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(mapper.Map<List<OrderViewModel>>(await orderRepository.GetAllAsync()));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid orderId)
        {
            var order = await orderRepository.TryGetOrderByIdAsync(orderId);
            return View(mapper.Map<OrderViewModel>(order));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(Guid orderId, OrderStatus status)
        {
            await orderRepository.UpdateStatusAsync(status, orderId);
            return RedirectToAction(nameof(Index));
        }
    }
}
