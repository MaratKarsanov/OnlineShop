using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository userRepository;
        private IComparisonRepository comparisonRepository;
        private IFavouritesRepository favouritesRepository;
        private IProductRepository productRepository;
        private ICartRepository cartRepository;
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;

        public AccountController(IUserRepository userRepository,
            IComparisonRepository comparisonRepository,
            IFavouritesRepository favouritesRepository,
            IProductRepository productRepository,
            ICartRepository cartRepository,
            UserManager<User> userManager, 
            SignInManager<User> signInManager)
        {
            this.userRepository = userRepository;
            this.favouritesRepository = favouritesRepository;
            this.comparisonRepository = comparisonRepository;
            this.productRepository = productRepository;
            this.cartRepository = cartRepository;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            return View("Autorization", new AutorizationData() { ReturnUrl = returnUrl ?? "/Home" });
        }

        [HttpPost]
        public IActionResult Login(AutorizationData autorizationData)
        {
            //if (!ModelState.IsValid)
            //    return RedirectToAction(nameof(Index));
            //var user = userRepository
            //    .GetAll()
            //    .FirstOrDefault(u => u.Login == autorizationData.Login);
            //if (user is null)
            //{
            //    ModelState.AddModelError("", "Пользователя с таким логином не существует!");
            //    return View(nameof(Index));
            //}
            //if (autorizationData.Password != user.Password)
            //{
            //    ModelState.AddModelError("", "Введен неверный пароль!");
            //    return View(nameof(Index));
            //}
            //var cookieOptions = new CookieOptions();
            //if (autorizationData.RememberMe)
            //    cookieOptions.Expires = DateTime.Now.AddMonths(1);
            //Response.Cookies.Append("userLogin", autorizationData.Login, cookieOptions);
            //var favourites = favouritesRepository.TryGetByUserId(autorizationData.Login);
            //if (favourites is null)
            //    favourites = favouritesRepository.AddFavourites(autorizationData.Login);
            //var comparison = comparisonRepository.TryGetByUserId(autorizationData.Login);
            //if (comparison is null)
            //    comparison = comparisonRepository.AddComparison(autorizationData.Login);
            //var cart = cartRepository.TryGetByLogin(autorizationData.Login);
            //if (cart is null)
            //    cart = cartRepository.AddCart(autorizationData.Login);
            //var favouriteProducts = favourites.Items.ToHashSet();
            //var comparisonProducts = comparison.Items.ToHashSet();
            //productRepository.UpdateInFavouritesCondition(favouriteProducts);
            //productRepository.UpdateInComparisonCondition(comparisonProducts);
            //return RedirectToAction("Index", "Home");
            if (ModelState.IsValid)
            {
                var result = signInManager.PasswordSignInAsync(autorizationData.UserName, 
                    autorizationData.Password, 
                    autorizationData.RememberMe, 
                    false)
                    .Result;
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

        public IActionResult Register(string returnUrl)
        {
            return View("Registration", new RegistrationData() { ReturnUrl = returnUrl ?? "/Home" });
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

        //public IActionResult Logout()
        //{
        //    productRepository.UpdateInFavouritesCondition(new HashSet<Product>());
        //    productRepository.UpdateInComparisonCondition(new HashSet<Product>());
        //    var cookieOptions = new CookieOptions()
        //    {
        //        Expires = DateTime.Now.AddMonths(-1)
        //    };
        //    Response.Cookies.Append("userLogin", string.Empty, cookieOptions);
        //    return RedirectToAction("Index", "Home");
        //}

        public IActionResult Logout()
        {
            signInManager.SignOutAsync().Wait();
            return RedirectToAction("Index", "Home");
        }
    }
}