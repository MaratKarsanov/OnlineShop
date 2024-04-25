namespace OnlineShop.Db.Models
{
    public class CartItem : RepositoryItem
    {
        //public Guid Id { get; set; }
        public int Amount { get; set; }
        public Product Product { get; set; }
        public Cart Cart { get; set; }
        public decimal TotalCost => Product.Cost * Amount;
    }
}