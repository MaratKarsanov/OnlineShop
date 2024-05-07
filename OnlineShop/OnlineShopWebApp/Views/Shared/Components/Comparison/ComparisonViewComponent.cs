using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Repositories.Interfaces;

namespace OnlineShopWebApp.Views.Shared.Components.Comparison
{
    public class ComparisonViewComponent : ViewComponent
    {
        private readonly IComparisonRepository comparisonRepository;

        public ComparisonViewComponent(IComparisonRepository comparisonRepository)
        {
            this.comparisonRepository = comparisonRepository;
        }

        public IViewComponentResult Invoke()
        {
            var userLogin = Request.Cookies["userLogin"];
            var comparison = comparisonRepository.TryGetByUserId(userLogin);
            var productsCount = comparison?.Items.Count ?? 0;
            return View("Comparison", productsCount);
        }
    }
}
