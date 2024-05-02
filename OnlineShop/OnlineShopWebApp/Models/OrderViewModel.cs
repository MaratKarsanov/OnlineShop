using OnlineShop.Db.Models;

namespace OnlineShopWebApp.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<CartItemViewModel> Items { get; set; }
        public decimal TotalCost => Items.Sum(ci => ci.TotalCost);
        public DeliveryDataViewModel DeliveryData { get; set; }
        public DateTime CreationTime { get; set; }
        public OrderStatus Status { get; set; }
    }
}
