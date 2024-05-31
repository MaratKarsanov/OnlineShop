﻿using Microsoft.EntityFrameworkCore;
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

        public List<Order> GetAll()
        {
            return databaseContext.Orders
                .Include(o => o.DeliveryData)
                .Include(o => o.Items)
                .ThenInclude(ci => ci.Product)
                .ToList();
        }

        public void Add(Order order)
        {
            databaseContext.Orders.Add(order);
            databaseContext.SaveChanges();
        }

        public void UpdateStatus(OrderStatus newStatus, Guid orderId)
        {
            var order = databaseContext.Orders
                .FirstOrDefault(o => o.Id == orderId);
            if (order is null)
                throw new NullReferenceException("Заказа с таким id нет в базе данных");
            order.Status = newStatus;
            databaseContext.SaveChanges();
        }

        public Order TryGetOrderById(Guid orderId)
        {
            return databaseContext.Orders
                .Include(o => o.DeliveryData)
                .Include(o => o.Items)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefault(o => o.Id == orderId);
        }
    }
}
