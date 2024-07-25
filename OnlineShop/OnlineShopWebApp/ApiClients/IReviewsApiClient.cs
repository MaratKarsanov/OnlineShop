using OnlineShopWebApp.ApiModels;

namespace OnlineShopWebApp.ApiClients
{
    public interface IReviewsApiClient
    {
        Task<List<ReviewApiModel>> GetByProductIdAsync(Guid productId);
        Task<ReviewApiModel> AddAsync(AddReviewApiModel addReviewApiModel);
        Task<bool> DeleteAsync(Guid reviewId);
        Task<ReviewApiModel> GetByIdAsync(Guid reviewId);
    }
}
