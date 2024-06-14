using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;

namespace OnlineShop.Db.Repositories
{
    public class OrderDbRepository : IOrderRepository
    {
        private readonly DatabaseContext databaseContext;
        public OrderDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await databaseContext.Orders
                .Include(o => o.DeliveryData)
                .Include(o => o.Items)
                .ThenInclude(ci => ci.Product)
                .ToListAsync();
        }

        public async Task AddAsync(Order order)
        {
            await databaseContext.Orders.AddAsync(order);
            await databaseContext.SaveChangesAsync();
        }

        public async Task UpdateStatusAsync(OrderStatus newStatus, Guid orderId)
        {
            var order = await databaseContext.Orders
                .FirstOrDefaultAsync(o => o.Id == orderId);
            if (order is null)
                throw new NullReferenceException("Заказа с таким id нет в базе данных");
            order.Status = newStatus;
            await databaseContext.SaveChangesAsync();
        }

        public async Task<Order> TryGetOrderByIdAsync(Guid orderId)
        {
            return await databaseContext.Orders
                .Include(o => o.DeliveryData)
                .Include(o => o.Items)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }
    }
}
