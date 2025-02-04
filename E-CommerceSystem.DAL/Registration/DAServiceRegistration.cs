using E_CommerceSystem.DAL.Abstract.ICategoryRepository;
using E_CommerceSystem.DAL.Abstract.IOrderItemRepository;
using E_CommerceSystem.DAL.Abstract.IOrderRepository;
using E_CommerceSystem.DAL.Abstract.IPaymentRepository;
using E_CommerceSystem.DAL.Abstract.IProductRepository;
using E_CommerceSystem.DAL.Abstract.IRepository;
using E_CommerceSystem.DAL.Abstract.IShippingRepository;
using E_CommerceSystem.DAL.Abstract.UnitOfWork;
using E_CommerceSystem.DAL.Concrete.CategoryRepository;
using E_CommerceSystem.DAL.Concrete.OrderItemRepository;
using E_CommerceSystem.DAL.Concrete.OrderRepository;
using E_CommerceSystem.DAL.Concrete.PaymentRepository;
using E_CommerceSystem.DAL.Concrete.ProductRepository;
using E_CommerceSystem.DAL.Concrete.Repository;
using E_CommerceSystem.DAL.Concrete.ShippingRepository;
using E_CommerceSystem.DAL.Concrete.UnitOfWork;
using E_CommerceSystem.DAL.Context;
using E_CommerceSystem.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.DAL.Registration
{
    public static class DAServiceRegistration
    {
        public static void DAServiceRegister(this IServiceCollection services ,IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); //todo yeniden bax
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IShippingRepository, ShippingRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddIdentityCore<AppUser>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
            })
           .AddRoles<IdentityRole>()
           .AddEntityFrameworkStores<ECommerceSystemContex>();
        }

    }
}

