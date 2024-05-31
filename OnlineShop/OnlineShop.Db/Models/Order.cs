namespace OnlineShop.Db.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<CartItem> Items { get; set; }
        public decimal TotalCost => Items.Sum(ci => ci.TotalCost);
        public DeliveryData DeliveryData { get; set; }
        public DateTime CreationTime { get; set; }
        public OrderStatus Status { get; set; }
        public string UserName { get; set; }

        public Order() // без этого конструктора не передаются данные из представления, не трогать!!!
        {
            Items = new List<CartItem>();
            CreationTime = DateTime.Now;
            Status = OrderStatus.Created;
        }
    }
}
