﻿using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Collections.Immutable;
using System.Data;

namespace OnlineShopWebApp.Controllers
{
    public class AdministratorController : Controller
    {
        private IRepository<Product> productRepository;
        private IRepository<Role> roleRepository;

        public AdministratorController(
            IEnumerable<IRepository<Product>> productRepositories,
            IRepository<Role> roleRepository)
        {
            productRepository = productRepositories.First();
            this.roleRepository = roleRepository;
        }

        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Roles()
        {
            return View(roleRepository);
        }

        public IActionResult Products()
        {
            return View(productRepository.OrderBy(p => p.Name));
        }

        [HttpGet]
        public IActionResult EditProduct(Guid productId)
        {
            if (!ModelState.IsValid)
                return View();
            var product = productRepository.TryGetElementById(productId);
            return View(product);
        }

        [HttpGet]
        public IActionResult AddProduct(Guid productId)
        {
            if (!ModelState.IsValid)
                return View();
            var product = productRepository.TryGetElementById(productId);
            return View(product);
        }

        public IActionResult RemoveProduct(Guid productId)
        {
            productRepository.Remove(productId);
            return RedirectToAction("Products");
        }

        [HttpPost]
        public IActionResult EditProduct(Guid productId, Product newProduct)
        {
            var product = productRepository.TryGetElementById(productId);  
            product.Name = newProduct.Name;
            product.Cost = newProduct.Cost;
            product.Description = newProduct.Description;
            product.ImageLink = Constants.ImageLink;
            return RedirectToAction("Products");
        }

        [HttpPost]
        public IActionResult AddProduct(Product newProduct)
        {
            newProduct.Id = Guid.NewGuid();
            newProduct.ImageLink = Constants.ImageLink;
            productRepository.Add(newProduct);
            return RedirectToAction("Products");
        }

        public IActionResult RemoveRole(Guid roleId)
        {
            roleRepository.Remove(roleId);
            return RedirectToAction("Roles");
        }

        [HttpGet]
        public IActionResult AddRole(Guid roleId)
        {
            if (!ModelState.IsValid)
                return View();
            var role = roleRepository.TryGetElementById(roleId);
            return View(role);
        }

        [HttpPost]
        public IActionResult AddRole(Role newRole)
        {
            if (roleRepository.Where(r => r.Name == newRole.Name).Count() > 0)
                ModelState.AddModelError("", "Такая роль уже существует");
            if (!ModelState.IsValid)
                return View();
            newRole.Id = Guid.NewGuid();
            roleRepository.Add(newRole);
            return RedirectToAction("Roles");
        }
    }
}
