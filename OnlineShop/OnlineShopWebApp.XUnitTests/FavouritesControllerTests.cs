using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Controllers;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Models;
using System.Security.Claims;

namespace OnlineShopWebApp.XUnitTests
{
    public class FavouritesControllerTests
    {
        private Mock<IProductRepository> mockProductsRepository;
        private Mock<IFavouritesRepository> mockFavouritesRepository;
        private Mock<IMapper> mockMapper;
        private FavouritesController favouritesController;

        public FavouritesControllerTests()
        {
            mockProductsRepository = new Mock<IProductRepository>();
            mockMapper = new Mock<IMapper>();
            mockFavouritesRepository = new Mock<IFavouritesRepository>();
            favouritesController = new FavouritesController(
                mockProductsRepository.Object,
                mockFavouritesRepository.Object,
                mockMapper.Object
            );
            var context = new DefaultHttpContext();
            context.User = new ClaimsPrincipal(new ClaimsIdentity([new Claim(ClaimTypes.Name, "testuser@example.com")]));
            favouritesController.ControllerContext = new ControllerContext()
            {
                HttpContext = context,
            };
        }

        [Fact]
        public async Task Index_ReturnsViewResult_WithProductViewModels()
        {
            // Arrange
            var favourites = new Favourites();
            var favouriteProducts = favourites.Items;
            var favouriteProductsViewModels = favouriteProducts.ToProductViewModels();

            mockFavouritesRepository
                .Setup(r => r.TryGetByUserNameAsync("testuser@example.com"))
                .ReturnsAsync(favourites);
            mockMapper
                .Setup(m => m.Map<List<ProductViewModel>>(It.IsAny<List<Product>>()))
                .Returns((List<Product> p) => p.Select(pr => new ProductViewModel() { Id = pr.Id, Name = pr.Name, Description = pr.Description })
                .ToList());

            // Act
            var result = await favouritesController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<ProductViewModel>>(viewResult.Model);
            Assert.Equal(favouriteProductsViewModels, model);
        }

        [Fact]
        public async Task Add_ReturnsRedirectToIndex()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var product = new Product() { Id = productId };

            mockProductsRepository
                .Setup(r => r.TryGetByIdAsync(productId))
                .ReturnsAsync(product);
            mockFavouritesRepository
                .Setup(r => r.AddProductAsync(product, "testuser@example.com"))
                .Returns(Task.CompletedTask);

            // Act
            var result = await favouritesController.Add(productId);

            // Assert
            var viewResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameof(favouritesController.Index), viewResult.ActionName);
        }

        [Fact]
        public async Task Remove_ReturnsRedirectToIndex()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var product = new Product() { Id = productId };

            mockProductsRepository
                .Setup(r => r.TryGetByIdAsync(productId))
                .ReturnsAsync(product);
            mockFavouritesRepository
                .Setup(r => r.RemoveProductAsync(product, "testuser@example.com"))
                .Returns(Task.CompletedTask);

            // Act
            var result = await favouritesController.Remove(productId);

            // Assert
            var viewResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameof(favouritesController.Index), viewResult.ActionName);
        }
    }
}
