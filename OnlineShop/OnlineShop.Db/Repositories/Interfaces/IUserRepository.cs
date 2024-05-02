using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User TryGetByLogin(string userId);
        void Add(User user);
        void Remove(string userId);
        void EditData(string login, EditUserData newData);
        void ChangePassword(string login, string newPassword);
        void ChangeRole(string login, string newRoleName);
        //public void AddDelivery(string login, DeliveryData deliveryData);
    }
}
