using AutoMapper;
using E_CommerceSystem.DTOs.AppUserDTO;
using E_CommerceSystem.DTOs.CategoryDTO;
using E_CommerceSystem.DTOs.OrderDTO;
using E_CommerceSystem.DTOs.OrderItemDTO;
using E_CommerceSystem.DTOs.PaymentDTO;
using E_CommerceSystem.DTOs.ProductDTO;
using E_CommerceSystem.DTOs.ShippingDTO;
using E_CommerceSystem.Entities.Entities;
using E_CommerceSystem.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.BLL.AutoMapper
{
    public class MapperPro:Profile
    {
        public MapperPro()
        {
            CreateMap<Category, CategoryGetDTO>().ReverseMap();//.ForMember(dest => dest.ChildrenIds, opt => opt.MapFrom(src => src.Children.Select(c => c.Id).ToList()))
                                                              //.ForMember(dest => dest.ProductIds, opt => opt.MapFrom(src => src.Products.Select(p => p.Id).ToList()));
            CreateMap<Category, CategoryCreateDTO>().ReverseMap();
            CreateMap<Category, CategoryUpdateDTO>().ReverseMap();

            CreateMap<Order, OrderGetDTO>().ReverseMap();
            CreateMap<Order, OrderCreateDTO>().ReverseMap();
            CreateMap<Order, OrderUpdateDTO>().ReverseMap();

            CreateMap<Product, ProductGetDTO>().ReverseMap();
            CreateMap<Product, ProductCreateDTO>().ReverseMap();
            CreateMap<Product, ProductUpdateDTO>().ReverseMap();

            CreateMap<OrderItem, OrderItemGetDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemCreateDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemUpdateDTO>().ReverseMap();

            CreateMap<Payment, PaymentGetDTO>().ReverseMap();
            CreateMap<Payment, PaymentCreateDTO>().ReverseMap();
            CreateMap<Payment, PaymentUpdateDTO>().ReverseMap();

            CreateMap<Shipping, ShippingGetDTO>().ReverseMap();
            CreateMap<Shipping, ShippingCreateDTO>().ReverseMap();
            CreateMap<Shipping, ShippingUpdateDTO>().ReverseMap();

           // CreateMap<AppUser, UserGetDTO>().ReverseMap();
          //  CreateMap<AppUser, UserCreateDTO>().ReverseMap();
          // CreateMap<AppUser, UserUpdateDTO>().ReverseMap();

        }

    }
}
