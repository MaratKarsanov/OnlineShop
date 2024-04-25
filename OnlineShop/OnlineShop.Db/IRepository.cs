﻿namespace OnlineShop.Db
{
    public interface IRepository<T>
        where T : RepositoryItem
    {
        public List<T> GetAll();
        public T TryGetElementById(Guid id);
        public T Add(T element);
        public void Remove(Guid id);
        public bool Contains(T element);
    }
}
