using System.Collections;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Cart : RepositoryItem, IEnumerable<CartItem>
    {
        private List<CartItem> Items;
        public decimal TotalCost => Items.Sum(i => i.TotalCost);

        public Cart(Guid id)
        {
            Id = id;
            Items = new List<CartItem>();
        }

        public void Add(Product product)
        {
            foreach (var item in Items)
                if (item.Product == product)
                {
                    item.Amount++;
                    return;
                }
            Items.Add(new CartItem(1, product));
        }

        public void Remove(Product product)
        {
            foreach (var item in Items)
                if (item.Product == product)
                {
                    if (item.Amount == 1)
                    {
                        Items.Remove(item);
                        return;
                    }
                    item.Amount--;
                    return;
                }
        }

        public static bool operator ==(Cart c1, Cart c2)
        {
            return c1.Id == c2.Id;
        }

        public static bool operator !=(Cart c1, Cart c2)
        {
            return c1.Id != c2.Id;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || !(obj is Cart))
                return false;
            var objAsCart = (Cart)obj;
            return this == objAsCart;
        }

        public IEnumerator<CartItem> GetEnumerator()
        {
            foreach (var item in Items)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}