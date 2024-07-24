using Moq;
using OnlineShop.Db.Repositories.Interfaces;

namespace OnlineShopWebApp.Tests
{
    public class HomeControllerTests
    {
        private readonly Mock<IProductRepository> mockProductsRepository;
        private readonly Mock<IReviewsApiClient> mockReviewsApiClient;
        private readonly Mock<IMapper> mockMapper;
        private readonly Mock<RedisCacheService> mockRedisCacheService;
        private readonly HomeController homeController;

        public HomeControllerTests()
        {
            mockProductsRepository = new Mock<IProductsRepository>();
            mockReviewsApiClient = new Mock<IReviewsApiClient>();
            mockMapper = new Mock<IMapper>();
            mockRedisCacheService = new Mock<IRedisCacheService>();
            homeController = new HomeController(
                mockProductsRepository.Object,
                mockMapper.Object,
                mockReviewsApiClient.Object,
                mockRedisCacheService.Object
            );
        }

        [Test]
        public async Task Index_ReturnsViewResult_WithAListOfProductViewModels()
        {
            // Arrange
            var products = new List<Product> { new Product { Id = Guid.NewGuid(), Name = "Убить отца" } };
            var productViewModels = new List<ProductViewModel> { new ProductViewModel { Id = products[0].Id, Name = products[0].Name } };

            mockRedisCacheService.Setup(r => r.TryGetAsync(It.IsAny<string>())).ReturnsAsync(string.Empty);
            mockProductsRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(products);
            mockReviewsApiClient.Setup(r => r.GetRatingByProductIdAsync(It.IsAny<Guid>())).ReturnsAsync(new RatingApiModel { ProductId = products[0].Id, AverageGrade = 5, ReviewsCount = 10 });
            mockMapper.Setup(m => m.Map<ProductViewModel>(It.IsAny<Product>())).Returns((Product p) => new ProductViewModel { Id = p.Id, Name = p.Name });

            // Act
            var result = await homeController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<ProductViewModel>>(viewResult.Model);
            Assert.Single(model);
            Assert.AreEqual("Убить отца", model[0].Name);
        }

        [Test]
        public async Task Search_ReturnsViewResult_WithAListOfProductViewModels()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = Guid.NewGuid(), Name = "Убить отца" },
                new Product { Id = Guid.NewGuid(), Name = "Зло, которое творят люди" }
            };
            var findProducts = products.Where(p => p.Name.Contains("Убить")).ToList();
            var productViewModels = findProducts.Select(p => new ProductViewModel { Id = p.Id, Name = p.Name }).ToList();

            mockProductsRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(products);
            mockMapper.Setup(m => m.Map<List<ProductViewModel>>(It.IsAny<List<Product>>())).Returns(productViewModels);

            // Act
            var result = await homeController.Search("Убить");

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<ProductViewModel>>(viewResult.Model);
            Assert.Single(model);
            Assert.Equal("Убить отца", model[0].Name);
        }
    }
}
