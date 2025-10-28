using Microsoft.Extensions.DependencyInjection;
using ecommerce.Data.Interfaces;
using ecommerce.Data.Repositories;

namespace ecommerce.Data
{
    public static class RepositoryRegistration
    {
        public static IServiceCollection AddDataRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMerchantRepository, MerchantRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
