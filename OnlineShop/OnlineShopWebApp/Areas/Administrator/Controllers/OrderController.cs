using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;
using Serilog;

namespace OnlineShopWebApp.Areas.Administrator.Controllers
{
    [Area(Constants.AdministratorRoleName)]
    [Authorize(Roles = Constants.AdministratorRoleName)]
    public class OrderController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(
            ICartRepository cartRepository,
            IOrderRepository orderRepository,
            IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<List<OrderViewModel>>(await _orderRepository.GetAllAsync()));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid orderId)
        {
            try
            {
                var order = await _orderRepository.TryGetOrderByIdAsync(orderId);
                return View(_mapper.Map<OrderViewModel>(order));
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(Guid orderId, OrderStatus status)
        {
            try
            {
                await _orderRepository.UpdateStatusAsync(status, orderId);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }
    }
}
