namespace OnlineShopWebApp
{
    public abstract class RepositoryItem
    {
        public Guid Id { get; protected set; }
        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
