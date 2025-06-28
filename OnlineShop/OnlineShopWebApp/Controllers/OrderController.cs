using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;
using Serilog;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public OrderController(
            ICartRepository cartRepository,
            IOrderRepository orderRepository,
            UserManager<User> userManager,
            IMapper mapper)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(DeliveryDataViewModel deliveryDataVm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(nameof(Index));
                }
                var userName = User.Identity.Name;
                var cart = await _cartRepository.TryGetByLoginAsync(userName);
                var deliveryData = _mapper.Map<DeliveryData>(deliveryDataVm);
                var newOrder = new Order()
                {
                    UserName = userName,
                    Items = cart.Items,
                    DeliveryData = deliveryData
                };
                await _orderRepository.AddAsync(newOrder);
                await _cartRepository.RemoveAsync(userName);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }
    }
}