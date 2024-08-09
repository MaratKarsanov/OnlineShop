using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories.Interfaces
{
    public interface IImagesRepository
    {
        Task<List<Image>> TryGetImagesByProductIdAsync(Guid productId);
    }
}
