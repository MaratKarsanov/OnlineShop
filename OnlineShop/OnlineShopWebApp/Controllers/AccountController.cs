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

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(string returnUrl)
        {
            return View(new AutorizationData() { ReturnUrl = returnUrl ?? "/Home" });
        }

        [HttpPost]
        public async Task<IActionResult> Login(AutorizationData autorizationData)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(autorizationData.UserName,
                    autorizationData.Password,
                    autorizationData.LockoutEnabled,
                    false);
                if (result.Succeeded)
                    return Redirect(autorizationData.ReturnUrl ?? "/Home");
                else
                    ModelState.AddModelError("", "Неправильный логин или пароль");
            }
            return View(autorizationData);
        }

        public async Task<IActionResult> Register(string returnUrl)
        {
            return View(new RegistrationData() { ReturnUrl = returnUrl ?? "/Home" });
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationData registrationData)
        {
            if (ModelState.IsValid)
            {
                var user = new User() 
                { 
                    Email = registrationData.UserName, 
                    UserName = registrationData.UserName, 
                    PhoneNumber = registrationData.PhoneNumber 
                };
                var result = await userManager.CreateAsync(user, registrationData.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    await userManager.AddToRoleAsync(user, Constants.UserRoleName);
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

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}