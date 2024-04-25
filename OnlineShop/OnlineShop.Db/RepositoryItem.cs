namespace OnlineShop.Db
{
    public abstract class RepositoryItem
    {
        public Guid Id { get; set; }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
