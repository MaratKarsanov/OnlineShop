using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Repositories.Interfaces;
using System.Text;

namespace OnlineShop.Db.Repositories
{
    public class DbRepository<T> : IRepository<T>
        where T : RepositoryItem
    {
        private readonly DatabaseContext databaseContext;
        private DbSet<T> dbSet;

        public int Count => dbSet.Count();

        public DbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
            var dbContextPropertyName = typeof(T).Name + "s";
            dbSet = (DbSet<T>)typeof(DatabaseContext)
                .GetProperties()
                .Where(p => p.Name == dbContextPropertyName)
                .First()
                .GetValue(databaseContext);
        }

        public T TryGetElementById(Guid id)
        {
            return dbSet.FirstOrDefault(e => e.Id == id);
        }

        public T Add(T element)
        {
            if (TryGetElementById(element.Id) is null)
                dbSet.Add(element);
            databaseContext.SaveChanges();
            return element;
        }

        public void Clear()
        {
            dbSet.RemoveRange();
            databaseContext.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var element = TryGetElementById(id);
            if (element is not null)
            {
                dbSet.Remove(element);
            }
            databaseContext.SaveChanges();
        }

        public bool Contains(T element)
        {
            return dbSet.Contains(element);
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            foreach (var e in dbSet)
                result.Append(e.ToString() + "\n\n");
            return result.ToString();
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }
    }
}
