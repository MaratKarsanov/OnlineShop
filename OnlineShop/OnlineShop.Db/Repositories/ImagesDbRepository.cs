using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;

namespace OnlineShop.Db.Repositories
{
    public class ImagesDbRepository : IImagesRepository
    {
        private readonly DatabaseContext databaseContext;

        public ImagesDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<List<Image>> TryGetImagesByProductIdAsync(Guid productId)
        {
            return await databaseContext.Images
                .Include(i => i.Product)
                .Where(i => i.ProductId == productId)
                .ToListAsync();
        }
    }
}
