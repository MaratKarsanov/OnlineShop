using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.ApiClients;
using OnlineShopWebApp.ApiModels;
using OnlineShopWebApp.Models;
using System.Security.Claims;

namespace OnlineShopWebApp.XUnitTests
{
    public class ProductControllerTests
    {
        private Mock<IProductRepository> mockProductsRepository;
        private Mock<IReviewsApiClient> mockReviewsApiClient;
        private Mock<IFavouritesRepository> mockFavouritesRepository;
        private Mock<IComparisonRepository> mockComparisonRepository;
        private Mock<IMapper> mockMapper;
        private Mock<UserManager<User>> mockUserManager;
        private Controllers.ProductController productController;

        public ProductControllerTests()
        {
            mockProductsRepository = new Mock<IProductRepository>();
            mockReviewsApiClient = new Mock<IReviewsApiClient>();
            mockMapper = new Mock<IMapper>();
            mockFavouritesRepository = new Mock<IFavouritesRepository>();
            mockComparisonRepository = new Mock<IComparisonRepository>();
            mockUserManager = new Mock<UserManager<User>>(Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
            productController = new Controllers.ProductController(
                mockProductsRepository.Object,
                mockFavouritesRepository.Object,
                mockComparisonRepository.Object,
                mockMapper.Object,
                mockReviewsApiClient.Object, 
                mockUserManager.Object
            );
            var context = new DefaultHttpContext();
            context.User = new ClaimsPrincipal(new ClaimsIdentity([new Claim(ClaimTypes.Name, "testuser@example.com")]));
            productController.ControllerContext = new ControllerContext()
            {
                HttpContext = context,
            };
        }

        [Fact]
        public async Task Index_ReturnsViewResult_WithProductViewModel()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var product = new Product() 
            { 
                Id = productId, 
                Name = "Ahmad Tea Ceylon"
            };
            var reviews = new List<ReviewApiModel>() 
            { 
                new ReviewApiModel() 
                { 
                    Id = Guid.NewGuid(), 
                    ProductId = productId, 
                    Text = "Тестовый отзыв", 
                    Grade = 5 
                } 
            };

            mockProductsRepository
                .Setup(r => r.TryGetByIdAsync(productId))
                .ReturnsAsync(product);
            mockReviewsApiClient
                .Setup(r => r.GetByProductIdAsync(productId))
                .ReturnsAsync(reviews);
            mockMapper
                .Setup(m => m.Map<ProductViewModel>(It.IsAny<Product>()))
                .Returns((Product p) => new ProductViewModel { Id = p.Id, Name = p.Name, Description = p.Description });
            mockMapper
                .Setup(m => m.Map<List<ProductViewModel>>(It.IsAny<List<Product>>()))
                .Returns((List<Product> p) => p.Select(pr => new ProductViewModel() { Id = pr.Id, Name = pr.Name, Description = pr.Description })
                .ToList());
            mockFavouritesRepository
                .Setup(f => f.AddFavouritesAsync(It.IsAny<string>()))
                .ReturnsAsync(new Favourites());
            mockComparisonRepository
                .Setup(f => f.AddComparisonAsync(It.IsAny<string>()))
                .ReturnsAsync(new Comparison());

            // Act
            var result = await productController.Index(productId);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ProductViewModel>(viewResult.Model);
            Assert.Equal(product.Id, model.Id);
            Assert.Equal(reviews.Count, model.Reviews.Count);
        }

        [Fact]
        public async Task AddReview_ReturnsUnauthorized_WhenUserIsNull()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var viewModel = new ProductViewModel();

            mockUserManager
                .Setup(u => u.GetUserAsync(null))
                .ReturnsAsync((User)null);

            // Act
            var result = await productController.AddReview(new AddReviewApiModel() 
            { 
                ProductId = productId, 
                Text = "Тестовый отзыв", 
                Grade = 5 
            });

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedResult>(result);
            Assert.Equal(StatusCodes.Status401Unauthorized, unauthorizedResult.StatusCode);
        }
    }
}
