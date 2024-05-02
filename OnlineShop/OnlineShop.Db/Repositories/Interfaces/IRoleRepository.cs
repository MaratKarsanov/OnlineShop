namespace OnlineShop.Db.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        public List<Role> GetAll();
        public Role TryGetByName(string name);
        public void Add(Role role);
        public void Remove(string name);
    }
}
