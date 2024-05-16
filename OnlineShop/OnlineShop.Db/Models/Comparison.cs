namespace OnlineShop.Db.Models
{
    public class Comparison
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<Product> Items { get; set; }

        public override int GetHashCode()
        {
            return UserId.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Comparison)
                return false;
            var objAsComparison = (Comparison)obj;
            return objAsComparison.UserId == UserId;
        }
    }
}
