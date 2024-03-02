using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        public string Index(Guid id)
        {
            if (id == default)
                return "Укажите id!";
            foreach (var product in HomeController.Products)
                if (product.Id == id)
                    return product.ToString();
            return "Товар с таким id не найден:(";
        }
    }
}