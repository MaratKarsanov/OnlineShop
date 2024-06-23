namespace OnlineShopWebApp.ApiModels
{
    public class ReviewApiModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public string? Text { get; set; }
        public int Grade { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
