namespace OnlineShopWebApp.Models
{
    public class CartItemViewModel
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public ProductViewModel Product { get; set; }
        public decimal TotalCost => Product.Cost * Amount;
    }
}