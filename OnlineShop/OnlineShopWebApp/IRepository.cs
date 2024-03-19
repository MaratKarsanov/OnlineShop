namespace OnlineShopWebApp
{
    public interface IRepository<T>
    {
        public T TryGetElementById(Guid id);
        public T Add(T element);
        public void Remove(T element);
        public bool Contains(T element);
    }
}
