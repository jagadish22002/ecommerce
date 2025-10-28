using ecommerce.Data.Interfaces;
using ecommerce.Data.Services;
using ecommerce.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ecommerce.Services
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMerchantService, MerchantService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ILoginService, LoginService>();

            // You can add other services here later (e.g., ProductService, OrderService)

            return services;
        }
    }
}
