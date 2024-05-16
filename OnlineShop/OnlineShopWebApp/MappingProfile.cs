using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Administrator.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Cart, CartViewModel>().ReverseMap();
            CreateMap<CartItem, CartItemViewModel>().ReverseMap();
            CreateMap<Comparison, ComparisonViewModel>().ReverseMap();
            CreateMap<DeliveryData, DeliveryDataViewModel>().ReverseMap();
            CreateMap<Favourites, FavouritesViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<IdentityRole, RoleViewModel>().ReverseMap();
            CreateMap<string, RoleViewModel>()
                .ForMember(r => r.Name, o => o.MapFrom(s => s));
        }
    }
}
