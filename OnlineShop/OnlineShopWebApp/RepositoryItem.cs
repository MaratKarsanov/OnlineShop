namespace OnlineShopWebApp
{
    public abstract class RepositoryItem
    {
        public Guid Id { get; set; }
        public RepositoryItem()
        {
            Id = Guid.NewGuid();
        }

        public RepositoryItem(Guid id)
        {
            Id = id;
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
