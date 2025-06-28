using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;
using Serilog;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            return View(new AutorizationData() { ReturnUrl = returnUrl ?? "/Home" });
        }

        [HttpPost]
        public async Task<IActionResult> Login(AutorizationData autorizationData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(
                        autorizationData.UserName,
                        autorizationData.Password,
                        autorizationData.LockoutEnabled,
                        false);
                    if (result.Succeeded)
                    {
                        return Redirect(autorizationData.ReturnUrl ?? "/Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Неправильный логин или пароль");
                    }
                }
                return View(autorizationData);
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Register(string returnUrl)
        {
            return View(new RegistrationData() { ReturnUrl = returnUrl ?? "/Home" });
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationData registrationData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new User()
                    {
                        Email = registrationData.UserName,
                        UserName = registrationData.UserName,
                        PhoneNumber = registrationData.PhoneNumber
                    };
                    var result = await _userManager.CreateAsync(user, registrationData.Password);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, false);
                        await _userManager.AddToRoleAsync(user, Constants.UserRoleName);
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
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
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