using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using OnlineShop.Db.Repositories.Interfaces;

namespace OnlineShop.Db.Repositories
{
    public class RoleDbRepository : IRoleRepository
    {
        private readonly DatabaseContext databaseContext;

        public RoleDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(Role role)
        {
            databaseContext.Roles.Add(role);
            databaseContext.SaveChanges();
        }

        public List<Role> GetAll()
        {
            return databaseContext.Roles.ToList();
        }

        public void Remove(string name)
        {
            var role = TryGetByName(name);
            if (role is null)
                return;
            databaseContext.Roles.Remove(role);
            databaseContext.SaveChanges();
        }

        public Role TryGetByName(string name)
        {
            return databaseContext.Roles
                .FirstOrDefault(r => r.Name == name);
        }
    }
}
