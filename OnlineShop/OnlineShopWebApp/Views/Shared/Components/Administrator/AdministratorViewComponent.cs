using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Areas.Administrator.Models;

namespace OnlineShopWebApp.Views.Shared.Components.Administrator
{
    public class AdministratorViewComponent : ViewComponent
    {
        private readonly IUserRepository userRepository;

        public AdministratorViewComponent(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IViewComponentResult Invoke()
        {
            var userLogin = Request.Cookies["userLogin"];
            var user = userRepository.TryGetByLogin(userLogin);
            if (user is null)
                return View("Administrator", new RoleViewModel());
            return View("Administrator", Helpers.MappingHelper.ToRoleViewModel(user.Role));
        }
    }
}
