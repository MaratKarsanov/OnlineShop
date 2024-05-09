using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;

namespace OnlineShop.Db.Repositories
{
    public class UserDbRepository : IUserRepository
    {
        private readonly DatabaseContext databaseContext;
        private IRoleRepository roleRepository;

        public UserDbRepository(DatabaseContext databaseContext,
            IRoleRepository roleRepository)
        {
            this.databaseContext = databaseContext;
            this.roleRepository = roleRepository;
        }

        public void Add(User user)
        {
            databaseContext.Users.Add(user);
            databaseContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return databaseContext.Users
                .Include(u => u.Role)
                .Include(u => u.DeliveryDatas)
                .ToList();
        }

        public void Remove(string login)
        {
            var user = TryGetByLogin(login);
            if (user is null)
                return;
            databaseContext.Users.Remove(user);
            databaseContext.SaveChanges();
        }

        public void EditData(string login, EditUserData newData)
        {
            var user = TryGetByLogin(login);
            if (user is null)
                return;
            user.Address = newData.Address;
            user.PhoneNumber = newData.PhoneNumber;
            user.Name = newData.Name;
            user.Surname = newData.Surname;
            databaseContext.SaveChanges();
        }

        public void ChangePassword(string login, string newPassword)
        {
            var user = TryGetByLogin(login);
            if (user is null)
                return;
            user.Password = newPassword;
            databaseContext.SaveChanges();
        }

        public void ChangeRole(string login, string newRoleName)
        {
            var user = TryGetByLogin(login);
            var newRole = roleRepository.TryGetByName(newRoleName);
            if (user is null || newRole is null)
                return;
            user.Role = newRole;
            databaseContext.SaveChanges();
        }

        public void AddDelivery(string login, DeliveryData deliveryData)
        {
            var user = TryGetByLogin(login);
            if (user is null)
                return;
            user.DeliveryDatas.Add(deliveryData);
            databaseContext.SaveChanges();
        }

        public User TryGetByLogin(string login)
        {
            return databaseContext.Users
                .Include(u => u.Role)
                .Include(u => u.DeliveryDatas)
                .FirstOrDefault(u => u.Login == login);
        }
    }
}
