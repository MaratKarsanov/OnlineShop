using OnlineShopWebApp.ApiModels;
using Serilog;

namespace OnlineShopWebApp.ApiClients
{
    public class ReviewsApiClient : IReviewsApiClient
    {
        private readonly HttpClient _httpClient;

        public ReviewsApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ReviewApi");
        }

        public async Task<List<ReviewApiModel>> TryGetByProductIdAsync(Guid productId)
        {
            try
            {
                var reviews = await _httpClient
                    .GetFromJsonAsync<List<ReviewApiModel>>($"Review/GetReviewsByProductId?productId={productId}");
                return reviews;
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return null;
            }
        }

        public async Task<ReviewApiModel> TryGetByIdAsync(Guid reviewId)
        {
            try
            {
                var review = await _httpClient
                    .GetFromJsonAsync<ReviewApiModel>($"Review/GetReview?reviewId={reviewId}");
                return review;
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
                return null;
            }
        }

        public async Task<bool> DeleteAsync(Guid reviewId)
        {
            var response = await _httpClient.DeleteAsync($"Review/DeleteReview?reviewId={reviewId}");
            return response.IsSuccessStatusCode;
        }

        public async Task<ReviewApiModel> AddAsync(AddReviewApiModel addReviewApiModel)
        {
            var response = await _httpClient.PostAsJsonAsync("Review/AddReview", addReviewApiModel);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ReviewApiModel>();
        }
    }
}
