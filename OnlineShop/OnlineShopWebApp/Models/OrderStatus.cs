using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public enum OrderStatus
    {
        Created,
        Processed,
        Delivering,
        Cancelled,
        Delivered
    }
}
