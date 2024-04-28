namespace OnlineShopWebApp
{
    public abstract class RepositoryItem
    {
        public Guid Id { get; set; }
        public RepositoryItem()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
