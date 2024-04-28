namespace OnlineShopWebApp.Models
{
    public class ComparisonViewModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<ComparisonItemViewModel> Items { get; set; }
    }
}
