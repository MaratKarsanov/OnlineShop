namespace OnlineShopWebApp.Models
{
    public class Order : RepositoryItem
    {
        public List<CartItem> Products { get; }
        public User User { get; }
        public string Address { get; }
        public string EMail { get; }
        public string PhoneNumber { get; }
        public string Comments { get; }

        public Order(List<CartItem> products,
            User user, 
            string address,
            string email,
            string phoneNumber,
            string comments) : base()
        {
            Products = products;
            User = user;
            Address = address;
            EMail = email;
            PhoneNumber = phoneNumber;
            Comments = comments;
        }

        public override string ToString()
        {
            return $"User name: {User.Name}\nAddress: {Address}\nE-mail: {EMail}\nPhone number: {PhoneNumber}";
        }
    }
}
