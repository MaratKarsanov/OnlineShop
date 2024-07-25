using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Controllers;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Redis;
using System.Security.Claims;

namespace OnlineShopWebApp.XUnitTests
{
    public class HomeControllerTests
    {
        private Mock<IProductRepository> mockProductsRepository;
        private Mock<IFavouritesRepository> mockFavouritesRepository;
        private Mock<IComparisonRepository> mockComparisonRepository;
        private Mock<IMapper> mockMapper;
        private Mock<IRedisCacheService> mockRedisCacheService;
        private HomeController homeController;

        public HomeControllerTests()
        {
            mockProductsRepository = new Mock<IProductRepository>();
            mockMapper = new Mock<IMapper>();
            mockRedisCacheService = new Mock<IRedisCacheService>();
            mockFavouritesRepository = new Mock<IFavouritesRepository>();
            mockComparisonRepository = new Mock<IComparisonRepository>();
            homeController = new HomeController(
                mockProductsRepository.Object,
                mockFavouritesRepository.Object,
                mockComparisonRepository.Object,
                mockMapper.Object,
                mockRedisCacheService.Object
            );
            var context = new DefaultHttpContext();
            context.User = new ClaimsPrincipal(new ClaimsIdentity([new Claim(ClaimTypes.Name, "testuser@example.com")]));
            homeController.ControllerContext = new ControllerContext()
            {
                HttpContext = context,
            };
        }

        [Fact]
        public async Task Index_ReturnsViewResult_WithAListOfProductViewModels()
        {
            // Arrange
            var products = new List<Product>()
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Ahmad Tea Ceylon"
                }
            };
            var productViewModels = new List<ProductViewModel>()
            {
                new ProductViewModel
                {
                    Id = products[0].Id,
                    Name = products[0].Name
                }
            };

            MoqSetup(products);

            // Act
            var result = await homeController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<ProductViewModel>>(viewResult.Model);
            Assert.Single(model);
            Assert.Equal("Ahmad Tea Ceylon", model[0].Name);
        }

        [Fact]
        public async Task Index_ReturnsViewResult_WithASearchedListOfProductViewModels()
        {
            // Arrange
            var searchString = "Ahmad";
            var products = new List<Product>()
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Ahmad Tea Ceylon"
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Ahmad Tea Pear Strudel"
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Curtis Sunny Lemon"
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Azer Tea",
                    Description = "AhMaD"
                }
            };
            var foundedProductsShould = products
                .Where(p => p.Name.ToLower().Contains(searchString.ToLower()) || p.Description.ToLower().Contains(searchString.ToLower()))
                .ToList();
            var foundedProductViewModelsShould = foundedProductsShould
                .Select(p => new ProductViewModel() { Id = p.Id, Name = p.Name, Description = p.Description })
                .ToList();

            MoqSetup(products);

            // Act
            var result = await homeController.Index(searchString);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<ProductViewModel>>(viewResult.Model);
            Assert.Equal(foundedProductsShould.Count, model.Count);
            Assert.Equal("Ahmad Tea Ceylon", model[0].Name);
            Assert.Equal("Ahmad Tea Pear Strudel", model[1].Name);
            Assert.Equal("Azer Tea", model[2].Name);
        }

        [Fact]
        public async Task Index_ReturnsViewResult_WithAPaginatedListOfProductViewModels()
        {
            // Arrange
            var products = new List<Product>();
            var productViewModels = new List<ProductViewModel>();
            for (var i = 0; i < 100; i++)
            {
                var id = Guid.NewGuid();
                products.Add(new Product() { Id = id, Name = (i + 1).ToString() });
                productViewModels.Add(new ProductViewModel() { Id = id, Name = (i + 1).ToString() });
            }

            MoqSetup(products);

            // Act
            var result = await homeController.Index("", 4);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<ProductViewModel>>(viewResult.Model);
            Assert.Equal(Constants.PageSize, model.Count);
            Assert.Equal(Constants.PageSize * 3 + 1, int.Parse(model[0].Name));
        }

        private void MoqSetup(List<Product> products)
        {
            mockRedisCacheService
                .Setup(r => r.TryGetAsync(It.IsAny<string>()))
                .ReturnsAsync(string.Empty);
            mockProductsRepository
                .Setup(r => r.GetAllAsync())
                .ReturnsAsync(products);
            mockFavouritesRepository
                .Setup(f => f.AddFavouritesAsync(It.IsAny<string>()))
                .ReturnsAsync(new Favourites());
            mockComparisonRepository
                .Setup(f => f.AddComparisonAsync(It.IsAny<string>()))
                .ReturnsAsync(new Comparison());
            mockMapper
                .Setup(m => m.Map<ProductViewModel>(It.IsAny<Product>()))
                .Returns((Product p) => new ProductViewModel { Id = p.Id, Name = p.Name, Description = p.Description });
            mockMapper
                .Setup(m => m.Map<List<ProductViewModel>>(It.IsAny<List<Product>>()))
                .Returns((List<Product> p) => p.Select(pr => new ProductViewModel() { Id = pr.Id, Name = pr.Name, Description = pr.Description })
                .ToList());
        }
    }
}