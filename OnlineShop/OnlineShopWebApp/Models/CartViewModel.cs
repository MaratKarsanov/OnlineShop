using System.Collections;

namespace OnlineShopWebApp.Models
{
    public class CartViewModel :  IEnumerable<CartItemViewModel>
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<CartItemViewModel> Items;
        public int Count => Items.Count;
        public decimal TotalCost => Items?.Sum(i => i.TotalCost) ?? 0;
        public int Amount => Items?.Sum(i => i.Amount) ?? 0;

        public IEnumerator<CartItemViewModel> GetEnumerator()
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