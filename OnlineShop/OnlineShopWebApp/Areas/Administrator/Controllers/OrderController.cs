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

        public IActionResult Index()
        {
            //return View(Helpers.MappingHelper.ToOrderViewModels(orderRepository.GetAll()));
            return View(mapper.Map<List<OrderViewModel>>(orderRepository.GetAll()));
        }

        [HttpGet]
        public IActionResult Edit(Guid orderId)
        {
            var order = orderRepository.TryGetOrderById(orderId);
            return View(mapper.Map<OrderViewModel>(order));
        }

        [HttpPost]
        public IActionResult UpdateStatus(Guid orderId, OrderStatus status)
        {
            orderRepository.UpdateStatus(status, orderId);
            return RedirectToAction(nameof(Index));
        }
    }
}
