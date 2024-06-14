using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();
        Task<Order> TryGetOrderByIdAsync(Guid orderId);
        Task AddAsync(Order order);
        Task UpdateStatusAsync(OrderStatus newStatus, Guid orderId);
    }
}
