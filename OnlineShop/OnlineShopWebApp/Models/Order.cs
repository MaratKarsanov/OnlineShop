namespace OnlineShopWebApp.Models
{
    public class Order : RepositoryItem
    {
        public List<CartItemViewModel> Products { get; set; }
        public decimal TotalCost => Products.Sum(ci => ci.TotalCost);
        public PersonalData PersonalData { get; set; }
        public DateTime CreationTime { get; }
        public OrderStatus Status { get; set; }

        public Order() // без этого конструктора не передаются данные из представления, не трогать!!!
        {
            Products = new List<CartItemViewModel>();
            CreationTime = DateTime.Now;
            Status = OrderStatus.Created;
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
        }
    }
}
