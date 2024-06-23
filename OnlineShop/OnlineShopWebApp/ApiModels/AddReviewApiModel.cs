namespace OnlineShopWebApp.ApiModels
{
    public class AddReviewApiModel
    {
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public string? Text { get; set; }
        public int Grade { get; set; }
    }
}
