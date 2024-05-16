using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, 
            SignInManager<User> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new AutorizationData() { ReturnUrl = returnUrl ?? "/Home" });
        }

        [HttpPost]
        public IActionResult Login(AutorizationData autorizationData)
        {
            if (ModelState.IsValid)
            {
                var result = signInManager.PasswordSignInAsync(autorizationData.UserName, 
                    autorizationData.Password, 
                    autorizationData.LockoutEnabled, 
                    false)
                    .Result;
                if (result.Succeeded)
                    return Redirect(autorizationData.ReturnUrl ?? "/Home");
                else
                    ModelState.AddModelError("", "Неправильный логин или пароль");
            }
            return View(autorizationData);
        }

        public IActionResult Register(string returnUrl)
        {
            return View(new RegistrationData() { ReturnUrl = returnUrl ?? "/Home" });
        }

        [HttpPost]
        public IActionResult Register(RegistrationData registrationData)
        {
            if (ModelState.IsValid)
            {
                User user = new User() 
                { 
                    Email = registrationData.UserName, 
                    UserName = registrationData.UserName, 
                    PhoneNumber = registrationData.PhoneNumber 
                };
                var result = userManager.CreateAsync(user, registrationData.Password).Result;
                if (result.Succeeded)
                {
                    signInManager.SignInAsync(user, false).Wait();
                    userManager.AddToRoleAsync(user, Constants.UserRoleName).Wait();
                    return Redirect(registrationData.ReturnUrl ?? "/Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(registrationData);
        }

        public IActionResult Logout()
        {
            signInManager.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }
    }
}