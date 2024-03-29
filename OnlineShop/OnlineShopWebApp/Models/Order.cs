namespace OnlineShopWebApp.Models
{
    public class Order : RepositoryItem
    {
        public List<CartItem> Products { get; set; }
        public PersonalData PersonalData { get; set; }
        public string Address { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"User name: {PersonalData.Name} {PersonalData.Surname}\nAddress: {Address}\nE-mail: {EMail}\nPhone number: {PhoneNumber}";
        }
    }
}
