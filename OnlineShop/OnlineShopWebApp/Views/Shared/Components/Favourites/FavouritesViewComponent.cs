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
            var userName = User.Identity.Name;
            var favourities = favouritesRepository.TryGetByUserNameAsync(userName);
            return View("Favourites", favourities?.Count ?? 0);
        }
    }
}
