using System.Collections;

namespace OnlineShopWebApp.Models
{
    public class FavouritesViewModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<ProductViewModel> Items { get; set; }
        public int Count => Items?.Count ?? 0;

        public FavouritesViewModel()
        {
            Items = new List<ProductViewModel>();
        }

        public void Add(ProductViewModel product)
        {
            Items.Add(product);
        }

        public void Remove(Guid id)
        {
            var product = Items.FirstOrDefault(p => p.Id == id);
            if (product is not null)
                Items.Remove(product);
        }

        public bool Contains(ProductViewModel product)
        {
            return Items.Contains(product);
        }
    }
}
