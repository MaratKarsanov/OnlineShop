using System.Collections;

namespace OnlineShopWebApp.Models
{
    public class Favourities : RepositoryItem, IEnumerable<ProductViewModel>
    {
        private List<ProductViewModel> Items;
        public int Count => Items?.Count ?? 0;

        public Favourities(Guid id)
        {
            Id = id;
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

        public IEnumerator<ProductViewModel> GetEnumerator()
        {
            foreach (var item in Items)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
