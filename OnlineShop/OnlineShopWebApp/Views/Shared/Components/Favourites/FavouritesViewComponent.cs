using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Repositories.Interfaces;

namespace OnlineShopWebApp.Views.Shared.Components.Favourites
{
    public class FavouritesViewComponent : ViewComponent
    {
        private readonly IFavouritesRepository favouritesRepository;

        public FavouritesViewComponent(IFavouritesRepository favouritesRepository)
        {
            this.favouritesRepository = favouritesRepository;
        }

        public IViewComponentResult Invoke()
        {
            var userLogin = Request.Cookies["userLogin"];
            var favourities = favouritesRepository.TryGetByUserName(userLogin);
            return View("Favourites", favourities?.Count ?? 0);
        }
    }
}
