using System.Collections;

namespace OnlineShop.Db.Models
{
    public class Cart : IEnumerable<CartItem>
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem> Items { get; set; }
        public int Count => Items.Count;
        public decimal TotalCost => Items?.Sum(i => i.TotalCost) ?? 0;
        public int Amount => Items?.Sum(i => i.Amount) ?? 0;

        public Cart()
        {
            Items = new List<CartItem>();
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

        public IEnumerator<CartItem> GetEnumerator()
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