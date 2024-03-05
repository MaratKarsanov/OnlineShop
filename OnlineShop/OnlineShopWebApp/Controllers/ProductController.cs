using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        public string Index(Guid id)
        {
            if (id == default)
                return "Укажите id!";
            var product = Repositories.ProductRepository.TryGetElementById(id);
            if (product is not null)
                return product.ToString() + $"\nDescription: {product.Description}";
            return "Товар с таким id не найден:(";
        }
    }
}