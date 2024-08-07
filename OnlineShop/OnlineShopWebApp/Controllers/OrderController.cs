﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private ICartRepository cartRepository;
        private IOrderRepository orderRepository;
        private UserManager<User> userManager;
        private IMapper mapper;

        public OrderController(ICartRepository cartRepository,
            IOrderRepository orderRepository,
            UserManager<User> userManager,
            IMapper mapper)
        {
            this.cartRepository = cartRepository;
            this.orderRepository = orderRepository;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(DeliveryDataViewModel deliveryDataVm)
        {
            if (!ModelState.IsValid)
                return View(nameof(Index));
            var userName = User.Identity.Name;
            var cart = await cartRepository.TryGetByLoginAsync(userName);
            var deliveryData = mapper.Map<DeliveryData>(deliveryDataVm);
            var newOrder = new Order()
            {
                UserName = userName,
                Items = cart.Items,
                DeliveryData = deliveryData
            };
            await orderRepository.AddAsync(newOrder);
            await cartRepository.RemoveAsync(userName);
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}