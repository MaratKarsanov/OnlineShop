using System.Collections;
using System.Linq;

namespace OnlineShopWebApp.Models
{
    public class Cart : RepositoryItem, IEnumerable<CartItem>
    {
        private List<CartItem> Items;
        public Guid UserId { get; }
        public decimal TotalCost => Items.Sum(i => i.TotalCost);

        public Cart(Guid userId)
        {
            UserId = userId;
            Items = new List<CartItem>();
        }

        public Cart(Guid userId, IEnumerable<Product> products) : this(userId)
        {
            foreach (var product in products)
                Add(product);
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
            Items = Items
                .OrderBy(i => i.TotalCost)
                .ToList();
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
            Items = Items
                .OrderBy(i => i.TotalCost)
                .ToList();
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