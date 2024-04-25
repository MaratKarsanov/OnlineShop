using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Db
{
    public interface ICartRepository
    {
        void Add(Product product, string userId);
        void Clear(string userId);
        void DecreaseAmount(Guid productId, string userId);
        Cart TryGetByUserId(string userId);
    }
}
