using System.Collections;

namespace OnlineShopWebApp.Models
{
    public class Favourities : RepositoryItem, IEnumerable<Product>
    {
        private List<Product> Items;
        public int Count => Items?.Count ?? 0;

        public Favourities(Guid id)
        {
            Id = id;
            Items = new List<Product>();
        }

        public void Add(Product product)
        {
            Items.Add(product);
        }

        public void Remove(Guid id)
        {
            var product = Items.FirstOrDefault(p => p.Id == id);
            if (product is not null)
                Items.Remove(product);
        }

        public bool Contains(Product product)
        {
            return Items.Contains(product);
        }

        public IEnumerator<Product> GetEnumerator()
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
