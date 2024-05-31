using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        Order TryGetOrderById(Guid orderId);
        void Add(Order order);
        void UpdateStatus(OrderStatus newStatus, Guid orderId);
        //void Add(string login, List<CartItem> items, DeliveryData deliveryData);
    }
}
