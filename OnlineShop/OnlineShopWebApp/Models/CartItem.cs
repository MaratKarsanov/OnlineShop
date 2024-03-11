namespace OnlineShopWebApp.Models
{
    public class CartItem
    {
        public Guid Id { get; }
        public int Amount { get; set; }
        public Product Product { get; }
        public decimal TotalCost => Product.Cost * Amount;

        public CartItem(int amount, Product product)
        {
            Id = product.Id;
            Amount = amount;
            Product = product;
        }
    }
}