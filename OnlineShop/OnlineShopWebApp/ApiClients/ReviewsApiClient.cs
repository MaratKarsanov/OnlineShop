using OnlineShopWebApp.ApiModels;

namespace OnlineShopWebApp.ApiClients
{
    public class ReviewsApiClient
    {
        private readonly HttpClient _httpClient;

        public ReviewsApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ReviewApi");
        }

        public async Task<List<ReviewApiModel>> GetByProductIdAsync(Guid productId)
        {
            var reviews = await _httpClient
                .GetFromJsonAsync<List<ReviewApiModel>>($"Review/GetReviewsByProductId?productId={productId}");
            return reviews;
        }

        public async Task<ReviewApiModel> GetByIdAsync(Guid reviewId)
        {
            var review = await _httpClient
                .GetFromJsonAsync<ReviewApiModel>($"Review/GetReview?reviewId={reviewId}");
            return review;
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
