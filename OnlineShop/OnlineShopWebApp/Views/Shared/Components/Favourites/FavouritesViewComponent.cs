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
            var favourities = favouritesRepository.TryGetByUserId(Constants.Login);
            return View("Favourites", favourities?.Count ?? 0);
        }
    }
}
