namespace OnlineShop.Db.Repositories.Interfaces
{
    public interface IRepository<T>
        where T : RepositoryItem
    {
        public List<T> GetAll();
        public T TryGetElementById(Guid id);
        public void Add(T element);
        public void Remove(Guid id);
        public bool Contains(T element);
    }
}
