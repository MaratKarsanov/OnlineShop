using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Views.Shared.Components.Favourites
{
    public class FavouritesViewComponent : ViewComponent
    {
        private readonly IRepository<Favourities> favouritiesRepository;

        public FavouritesViewComponent(IRepository<Favourities> favouritiesRepository)
        {
            this.favouritiesRepository = favouritiesRepository;
        }

        public IViewComponentResult Invoke()
        {
            var favourities = favouritiesRepository.TryGetElementById(Constants.UserId);
            return View("Favourites", favourities?.Count ?? 0);
        }
    }
}
