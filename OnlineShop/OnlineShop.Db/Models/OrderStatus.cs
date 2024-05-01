using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db.Models
{
    public enum OrderStatus
    {
        [Display(Name = "Создан")]
        Created,

        [Display(Name = "Обработан")]
        Processed,

        [Display(Name = "В пути")]
        Delivering,

        [Display(Name = "Отменен")]
        Cancelled,

        [Display(Name = "Доставлен")]
        Delivered
    }
}
