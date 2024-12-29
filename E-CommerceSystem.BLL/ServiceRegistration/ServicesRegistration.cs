
using E_CommerceSystem.BLL.Servicess.Implementations;
using E_CommerceSystem.BLL.Servicess.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace E_CommerceSystem.BLL.ServiceRegistration
{
    public static class ServicesRegistration
    {
        public static void Registers(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IShippingService, ShippingService>();
        }
    }
}
