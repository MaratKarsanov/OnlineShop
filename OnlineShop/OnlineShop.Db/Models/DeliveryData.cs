namespace OnlineShop.Db.Models
{
    public class DeliveryData
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }

        public DeliveryData()
        {
            Name = Surname = Address = EMail = PhoneNumber = "";
        }

        public override string ToString()
        {
            return $"{Surname} {Name}";
        }
    }
}
