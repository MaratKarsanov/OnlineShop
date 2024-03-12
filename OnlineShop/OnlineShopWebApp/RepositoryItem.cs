namespace OnlineShopWebApp
{
    public abstract class RepositoryItem
    {
        public Guid Id { get; protected set; }
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
